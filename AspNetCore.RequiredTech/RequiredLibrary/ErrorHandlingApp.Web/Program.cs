var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    //app.UseStatusCodePages("text/plain", "Bir hata var : durum kodu {0}");
    app.UseStatusCodePages(async context =>
    {
        context.HttpContext.Response.ContentType = "text/plain";
        await context.HttpContext.Response.WriteAsync($"Bir hata var. Durum kodu: {context.HttpContext.Response.StatusCode}");
    });
}
else
{
    app.UseHsts();
}
//app.UseExceptionHandler("/Home/Error");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();