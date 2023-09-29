using Microsoft.EntityFrameworkCore;
using TodoListApp.BusinessLogic;
using TodoListApp.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Services to the container.
builder.Services.AddControllersWithViews();

// DbContext and the connection string configuration.
builder.Services.AddDbContext<TodoListContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// TodoManager service.
builder.Services.AddTransient<TodoManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. Need to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
