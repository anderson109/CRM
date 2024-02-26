var builder = WebApplication.CreateBuilder(args); // crea un contructor de aplicaciones web

//agrega servicios al contenedor de dependencias.
builder.Services.AddControllersWithViews(); // agrega servicios para controladores y vistas

//configurar y agrega un cliente HTTP con nombre "CRMAPI"
builder.Services.AddHttpClient("CRMAPI", c =>
{
    //configura la direccion base del cliente http desde la configuracion
    c.BaseAddress = new Uri(builder.Configuration["UrlsAPI:CRM"]);
    //puedes configurar otras opciones del httpclient aqui segun sea necesario
});

var app = builder.Build(); // crea una instancia de la aplicacion web

//configurar el pipeline de solicitudes http.
if (!app.Environment.IsDevelopment())
{
    //maneja excepciones en caso de errores y redirige a la accion "Error" en el controlador "Home"
    app.UseExceptionHandler("/Home/Error");
    //el valor HSTS predeterminado es de 30 dias. puedes cambiarlo para escenarios de produccion
    app.UseHsts();
}

app.UseHttpsRedirection(); // redirige las solicitudes http a https
app.UseStaticFiles(); // habilita el uso de archivos estaticos como css, JavaScript, imagenes, etc.

app.UseRouting(); // configura el enrutamiento de solicitudes

app.UseAuthorization(); //habilita la autorizacion para proteger rutas y acciones de controladores

//mapea la ruta predeterminada de controlador y accion
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); //inicia la aplicacion web
