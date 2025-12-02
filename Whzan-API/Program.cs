using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Whzan_API.EF.Context;
using Whzan_API.Services.Abstraction;
using Whzan_API.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddCors(options => options.AddPolicy("developmentCORS", policy =>
{
    policy
    .WithOrigins(
        "http://localhost:4200",
            "https://localhost:4200",
            "http://localhost:5173",
            "https://localhost:5173",
            "https://localhost:7057",
            "http://localhost:5182",
            "http://ec2-3-135-204-109.us-east-2.compute.amazonaws.com:5000",
            "https://d26jd7lozgfhgl.cloudfront.net")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials();
}));

//builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WhzanCatalogDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WhzanCatalogDBConnection")));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductBusinessLogic, ProductBusinessLogic>();
builder.Services.AddScoped<IFavouriteRepository, FavouriteRepository>();
builder.Services.AddScoped<IFavouriteBusinessLogic, FavouriteBusinessLogic>();
builder.Services.AddScoped<IWatchedRepository, WatchedRepository>();
builder.Services.AddScoped<IWatchedBusinessLogic, WatchedBusinessLogic>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IImageBusinessLogic, ImageBusinessLogic>();
builder.Services.AddScoped<ITagRepository, TagRepository>();
builder.Services.AddScoped<ITagBusinessLogic, TagBusinessLogic>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseCors("developmentCORS");

    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // OPTIONAL: also expose swagger in production
    app.UseCors("developmentCORS");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "images")),
    RequestPath = "/images"
});

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
