var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("companies.json", optional: false, reloadOnChange: true);
builder.Configuration.AddXmlFile("companies.xml", optional: false, reloadOnChange: true);
builder.Configuration.AddIniFile("companies.ini", optional: false, reloadOnChange: true);
builder.Configuration.AddJsonFile("myinfo.json", optional: false, reloadOnChange: true);


builder.Services.AddControllersWithViews();
builder.Services.AddTransient<CompanyAnalyzerService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
