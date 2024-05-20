using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyAppContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<MyAppContext>();
        SeedData(dbContext);
    }
    catch (Exception ex)
    {
        // Handle any exceptions here
        Console.WriteLine("An error occurred while seeding the database.");
        Console.WriteLine(ex.Message);
    }
}


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


static void SeedData(MyAppContext dbContext)
{
    // Check if there's already data in the database
    if (!dbContext.Person.Any())
    {
        // Seed data for the Person entity
        dbContext.Person.AddRange(
            new Person { Name = "saxeli1", Age = 30 },
            new Person { Name = "saxeli2", Age = 25 },
            new Person { Name = "saxeli3", Age = 35 }
        );

        // Save changes to the database
        dbContext.SaveChanges();
    }
}

