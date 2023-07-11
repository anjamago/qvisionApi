using Application.inyect;
using Infrastructure.Inyect;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
var isDeveloper = builder.Environment.IsDevelopment();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication()
    .AddInfrastructure(config);

var AllowSpecificOrigins = "_myQvisionTest";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins(
                "http://localhost:4200",
                "http://www.contoso.com"
                )
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();
app.AppContextMigrate();
app.UseCors(AllowSpecificOrigins);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();