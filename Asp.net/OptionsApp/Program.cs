using OptionsApp.Options;
using OptionsApp.Repositories;
using OptionsApp.Repositories.Base;

const string connectionStringName = "ProductDb";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();

// builder.Services.AddScoped<ProductOptions>(sp => {
//     var options = builder.Configuration
//             .GetSection("ProductOptions")
//             .Get<ProductOptions>();

//     if(options == null) {
//         throw new Exception($"{nameof(ProductOptions)} not found!");
//     }

//     return options;
// });

var options = builder.Configuration
        .GetSection("ProductOptions");

builder.Services.Configure<ProductOptions>(options);



builder.Services.AddOptions<ProductDbOptions>()
    .Configure(options => {
        options.ConnectionString = Environment.GetEnvironmentVariable(connectionStringName) 
            ?? builder.Configuration.GetConnectionString(connectionStringName)
            ?? throw new Exception($"Connection string {connectionStringName} not found!");
    });





builder.Services.AddScoped<ProductRepositoryBase, ProductSqlRepository>(); 

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();