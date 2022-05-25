using FeatureFlags.DataLayer;
using FeatureFlags.DataLayer.Entities.Base;
using FeatureFlags.RepositoryLayer;
using FeatureFlags.RepositoryLayer.Base;
using FeatureFlags.ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IRepository<BaseEntity>, Repository<BaseEntity>>();
builder.Services.AddScoped<IFeatureFlagRepository, FeatureFlagRepository>();
builder.Services.AddScoped<IFeatureFlagService, FeatureFlagService>();

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
