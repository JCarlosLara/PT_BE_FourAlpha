var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Comprobar si necesito los CORS para montar la API en el somee
string MyCors = "MyCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyCors,
                        builder =>
                        {
                            builder.WithOrigins("*");
                        });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyCors);

app.MapControllers();

app.Run();
