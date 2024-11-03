

using psymed_platform.Shared.Infrastructure.Persistence.EFC.Configuration;

var builder = WebApplication.CreateBuilder(args);

//TODO: falta Cofigurar la coneccion con el Mysql 
//Nota de sihuar no se logro me sale un error con el mysql :( y en el properties ya configure el puerto eso falta cambiarlo


// Agrega controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();   

var app = builder.Build();

// Habilita Swagger en modo de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();