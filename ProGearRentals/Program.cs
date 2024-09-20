using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProGearRentals.Infrastructure.Data;
using ProGearRentals.ModelBinders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);     

builder.Services.AddControllersWithViews(option =>
{
    option.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
    option.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});

builder.Services.AddApplicationServices();

var app = builder.Build();




if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");      
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Equipment Details",
        pattern: "/Equipment/Details/{id}/{info}",
        defaults: new {Controller = "Equipment",Action = "Details"}
    );
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();

});


app.Run();

await app.RunAsync();
