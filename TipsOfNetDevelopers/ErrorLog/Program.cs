using DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);

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

app.Use(async (context, next) =>
{
	try
	{
		await next(context);
	}
	catch (Exception ex)
	{
		AppDbContext _context = new AppDbContext();
		DataAccess.Models.ErrorLog errorLog = new()
		{
			MethodName = context.Request.Path.Value,
			Trace = ex.StackTrace,
			CreatedDate = DateTime.Now
		};

		await _context.ErrorLoggers.AddAsync(errorLog);
		await _context.SaveChangesAsync();

		context.Response.ContentType = "text/plain";
		await context.Response.WriteAsync(ex.Message);
	}
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
