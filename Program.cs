using Microsoft.EntityFrameworkCore;
using SafeLinkApi.Data;
using SafeLinkApi.Services;
using SafeLinkApi.Converters; // Para o conversor DateTime pt-BR
using Swashbuckle.AspNetCore.Filters; // Necessário para AddSwaggerExamplesFromAssemblyOf

var builder = WebApplication.CreateBuilder(args);

// ============================================================================
// CONFIGURAÇÃO DO BANCO DE DADOS (Oracle)
// ============================================================================
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));

// ============================================================================
// INJEÇÃO DE DEPENDÊNCIA DOS SERVIÇOS
// ============================================================================
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<RegiaoService>();
builder.Services.AddScoped<AlertaService>();
builder.Services.AddScoped<EventoNaturalService>();
builder.Services.AddScoped<PrevisaoRiscoService>();
builder.Services.AddScoped<RelatoUsuarioService>();

// ============================================================================
// CONFIGURAÇÃO DO CONTROLLERS E FORMATO JSON pt-BR
// ============================================================================
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Adiciona o conversor customizado para aceitar datas no formato dd/MM/yyyy HH:mm:ss
        options.JsonSerializerOptions.Converters.Add(new DateTimePtBrConverter());
    });

// ============================================================================
// CONFIGURAÇÃO DO SWAGGER E EXEMPLOS
// ============================================================================
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();         // Ativa suporte a [SwaggerOperation], etc.
    c.ExampleFilters();            // Ativa suporte para exemplos customizados via IExamplesProvider
});

builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();

// ============================================================================
// CONFIGURAÇÃO DO PIPELINE DA APLICAÇÃO
// ============================================================================
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
