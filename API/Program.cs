using API.Extensions;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
//builder.Services.ConfigureRepositoryWrapper();

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

// Configure persistence
builder.Services.configureRepositoryWrapper(builder.Environment, builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//var connectionString = builder.Configuration.GetValue<string>("ConnectionString:CosmosDb:AccountKey");
//var dbName = builder.Configuration.GetValue<string>("ConnectionString:CosmosDb:DbName");

//builder.Services.AddDbContext<RepositoryContext>(options =>
//        options.UseCosmos(
//            connectionString,
//            dbName));

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseDeveloperExceptionPage(); 
    app.UseSwagger();
    app.UseSwaggerUI();
}

else
    app.UseHsts();

// Persistence
// Ensure database for log messages exist
app.EnsureRepositoryContextDatabaseExist();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});
app.UseCors("CorsPolicy");


app.UseAuthorization();

app.MapControllers();

app.Run();


// https://code-maze.com/net-core-web-development-part5/
//https://code-maze.com/net-core-web-development-part5/ 
//DTO
