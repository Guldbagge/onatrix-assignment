using Microsoft.EntityFrameworkCore;
using onatrix_assignment.Data;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("umbracoDbDSN");


builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));


builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddDeliveryApi()
    .AddComposers()
    .Build();

WebApplication app = builder.Build();

await app.BootUmbracoAsync();

app.UseHttpsRedirection();

app.UseUmbraco()
    .WithMiddleware(u =>
    {
        u.UseBackOffice();
        u.UseWebsite();
    })
    .WithEndpoints(u =>
    {
        u.UseBackOfficeEndpoints();
        u.UseWebsiteEndpoints();
    });

await app.RunAsync();


//WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

//builder.CreateUmbracoBuilder()
//	.AddBackOffice()
//	.AddWebsite()
//	.AddDeliveryApi()
//	.AddComposers()
//	.Build();

//WebApplication app = builder.Build();

//await app.BootUmbracoAsync();

//app.UseHttpsRedirection();

//app.UseUmbraco()
//	.WithMiddleware(u =>
//	{
//		u.UseBackOffice();
//		u.UseWebsite();
//	})
//	.WithEndpoints(u =>
//	{
//		u.UseBackOfficeEndpoints();
//		u.UseWebsiteEndpoints();
//	});

//await app.RunAsync();
