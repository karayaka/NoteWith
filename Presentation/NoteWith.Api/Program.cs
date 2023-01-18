using NoteWith.Infrastructure.InfrastructureRegistirations;
using NoteWith.Persistence.PersistenceRegistirations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//add datacontext
var cnnc = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddNoteDbContext(cnnc);
//JWT Configirationları eklendi
var secretKey = builder.Configuration["AppSettings:Token"];
builder.Services.AddJWTAuthentication(secretKey);
//mapper serivi eklendi
builder.Services.AddMapper();
//servisler eklendi
builder.Services.AddServices();
//repositoryler eklendi
builder.Services.AddRepositorys();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

