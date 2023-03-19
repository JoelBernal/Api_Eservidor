using api_librerias_paco.Context;
using api_librerias_paco.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<LibroClienteService>();

// Add services to the container.
builder.Services.AddDbContext<LibreriaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibreriaContext")));

builder.Services.AddTransient<LibreriaContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
                      policy  =>
                      {
                        policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                          /* policy.WithOrigins("http://example.com",
                                              "http://www.contoso.com"); */
                      });
});


//var app = builder.Build();

// Configure the HTTP request pipeline.+


// [Newtonsoft.Json.JsonProperty(PropertyName="properties.token")]
// public string Token { get; set; }

builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRouting();

app.UseAuthorization();

app.UseCors("MyAllowSpecificOrigins");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

// Configure the HTTP request pipeline.


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//