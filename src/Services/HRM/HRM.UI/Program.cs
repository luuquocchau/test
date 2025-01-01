using HRM.UI.Services;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddRazorPages()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

//builder.Services.AddHttpClient<OrganizationService>(client =>
//{
//    client.BaseAddress = new(builder.Configuration["ApiSettings:BaseUrl"]);
//});

builder.Services.AddRefitClient<IOrganizationService>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new(builder.Configuration["ApiSettings:BaseUrl"]!);
    });

builder.Services.AddHttpClient<EmployeeService>(client =>
{
    client.BaseAddress = new(builder.Configuration["ApiSettings:BaseUrl"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
