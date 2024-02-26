// importa los espacios de nombres necesarios para el proyecto.
using CRM.API.Properties.Endpoints;
using CRM.API.Models.DAL;
using Microsoft.EntityFrameworkCore;
using CRM.API.Properties.Models.DAL;

//crea un nuevo constructor de la aplicacion web.
var builder = WebApplication.CreateBuilder(args);

//agrega servicios para habilitar la generacion de documentacion de API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configura y agrega uun contexto de base de datos para entity framework core

builder.Services.AddDbContext<CRMContext>(options =>
      options.UseSqlServer(builder.Configuration.GetConnectionString("Conn"))
    );
//agrega una instancia de la clase customerDAL como un servicio para la inyeccion de dependencias.
builder.Services.AddScoped<CustomerDAL>();

//construye la aplicacion web
var app = builder.Build();
 
//agrega los puntos finales relaciionados con los clientes ala aplicacion
app.AddCustomerEndpoints();

//verifica si la aplicacion se esta ejecutando en un entorno de desarrollo.
if(app.Environment.IsDevelopment())
{
    //habilita el uso de swagger para la documentacion de la api
    app.UseSwagger();
    app.UseSwaggerUI();
}

//agrega middleware para redirigir las solicitudes http a https
app.UseHttpsRedirection();

//ejecuta la aplicacion
app.Run();