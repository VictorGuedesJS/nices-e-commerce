using Loja.Application;
using Loja.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Em dev o front usa o proxy do Vite; o CORS cobre chamadas diretas ao back.
const string FrontendCors = "Frontend";
var origensPermitidas = builder.Configuration.GetSection("Cors:Origins").Get<string[]>() ?? [];
builder.Services.AddCors(options => options.AddPolicy(FrontendCors, policy =>
    policy.WithOrigins(origensPermitidas).AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors(FrontendCors);
app.UseAuthorization();
app.MapControllers();

app.Run();

// Torna Program visível para testes (arquitetura e integração).
public partial class Program;
