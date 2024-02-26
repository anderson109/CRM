using CRM.API.Properties.Models.DAL;
using CRM.API.Properties.Models.EN;
using CRM.DTOs.CustomerDTOs;

namespace CRM.API.Properties.Endpoints
{
    public static class CustomerEndPoint
    {
        //metodo para configurar los endpoints relacionados con los clientes
        public static void AddCustomerEndpoints(this WebApplication app)
        {
            //configurar un endpoint de tipo POST para buscar clientes
            app.MapPost("/customer/search", async (SearchQueryCustomerDTO customerDTO, CustomerDAL customerDAL) =>
            {
                //crear un objeto 'customer' a partir de los datos proporcionados
                var customer = new Customer
                {
                    Name = customerDTO.Name_like != null ? customerDTO.Name_like : string.Empty,
                    LastName = customerDTO.LastName_Like != null ? customerDTO.LastName_Like : string.Empty,
                };
                //iniciar una lista de clientes y una variable para contar las filas
                var customers = new List<Customer>();
                int countRow = 0;

                // verificar si se debe enviar la cantidad de filas
                if (customerDTO.SendRowCount == 2)
                {
                    // realizar una busquedad de clientes y contar las filas
                    customers = await customerDAL.Search(customer, skip: customerDTO.Skip, take: customerDTO.Take);
                    if (customers.Count > 0)
                        countRow = await customerDAL.CountSearch(customer);
                }
                else
                {
                    customers = await customerDAL.Search(customer, skip: customerDTO.Skip, take: customerDTO.Take);
                }
                // crear un objeto 'searchResultCustomeDTO' para almacenar los resultados
                var costumerResult = new SearchResultCustomerDTO
                {
                    Data = new List<SearchResultCustomerDTO.CustomerDTO>(),
                    CountRow = countRow
                };

                //Mapear los resultados a objetos 'customerDTO' y agregarlos al resultado
                customers.ForEach(s => {
                    costumerResult.Data.Add(new SearchResultCustomerDTO.CustomerDTO
                    {
                        Id = s.Id,
                        Name = s.Name,
                        LastName = s.LastName,
                        Address = s.Address,
                    });

                });

                // devolver los resultados
                return costumerResult;
            });

            //configurar un edpoint de tipo GET para obtener un cliente por ID
            app.MapGet("/customer/{id}", async (int id, CustomerDAL customerDAL) =>
            {
                // obtener un cliente por ID
                var customer = await customerDAL.GetById(id);

                //crear un objeto 'GetIdResultCustomerDTO para almacenar el resultado
                var customerResult = new GetIdResultCustomerDTO
                {
                    Id = customer.Id,
                    Name = customer.Name,
                    LastName= customer.LastName,
                    Address = customer.Address,
                };

                //verificar si se encontro el cliente y devolver la respuesta correspondiente
                if(customerResult.Id > 0)
                    return Results.Ok(customerResult);
                else
                    return Results.NotFound(customerResult);
            });

            // configurar un edpoint de tipo de post para crear un nuevo clientee
            app.MapPost("/customer", async (CreateCustomerDTO customerDTO, CustomerDAL customerDAL) =>
            {
                //crear un objeto 'customer' a partir de los datos proporcionados

                var customer = new Customer
                {
                    Name = customerDTO.Name,
                    LastName = customerDTO.LastName, 
                    Address = customerDTO.Address,
                };

                // intentar crear el cliente y devolver el resultado correspondiente
                int result = await customerDAL.Create(customer);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);

            });

            // configurar en endpoint un tipo de dato de put para editar un cliente existente
            app.MapPut("/customer", async (EditCustomerDTO customerDTO, CustomerDAL customerDAL) =>
            {
                // crear un objeto 'customer' a partir de los datos proporcionados
                var customer = new Customer
                {
                    Id= customerDTO.Id,
                    Name = customerDTO.Name,
                    LastName = customerDTO.LastName,
                    Address = customerDTO.Address,
                };

                // intentar editar el cliente y devolver el resultado correspondiente
                int result = await customerDAL.Edit(customer);
                if (result !=0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

            //configurar un endpoint de tipo delete para eliminar un cliente por ID
            app.MapDelete("/customer/{id}", async (int id, CustomerDAL customerDAL) =>
            {
                //intentar eliminar el cliente y devolver el resultadi correspondiente
                int result = await customerDAL.Delete(id);
                if(result !=0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });
        }
    }
}
