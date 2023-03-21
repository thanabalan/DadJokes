var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("RapidApi", x =>
{
    x.BaseAddress = new System.Uri("https://dad-jokes.p.rapidapi.com/");
    x.DefaultRequestHeaders.Add("X-RapidAPI-Key", builder.Configuration["RapidAPI:Key"]);
    x.DefaultRequestHeaders.Add("X-RapidAPI-Host", builder.Configuration["RapidAPI:Host"]);
 });
;
var app = builder.Build();

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
