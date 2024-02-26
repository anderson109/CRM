//importar el espacio de nombres necesario para DBcontext.
using Microsoft.EntityFrameworkCore;
using CRM.API.Properties.Models.EN;

namespace CRM.API.Models.DAL
{
    public class CRMContext : DbContext
    {
        //constructor que toma DBContextOptions como parametro para configurar la conexion a la base de datos.

        public CRMContext(DbContextOptions<CRMContext> options): base(options) 
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }


}