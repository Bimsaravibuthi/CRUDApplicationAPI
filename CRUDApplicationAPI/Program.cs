using CRUDApplicationAPI.Services.Department;
using CRUDApplicationAPI.Services.Employee;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => 
    {  
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); 
    });
});

builder.Services.AddScoped<IDepartmentRepository, DepartmentService>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeService>();

// Add services to the container.

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

app.MapControllers();

app.Run();
