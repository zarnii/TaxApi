using CarWebApi.DAL.Interfaces;
using CarWebApi.Services.Interfaces;
using CarWebApi.Services;
using CarWebApi.DAL.Repositories;
using CarWebApi.SerializationOption;
using System.Text.Json.Serialization;

namespace CarWebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Configuration.AddJsonFile("dbConfig.json");

			// Игнорирование цикла в JSON.
			builder.Services.AddControllers()
				.AddJsonOptions(options =>
				{
					options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
					options.JsonSerializerOptions.WriteIndented = true;
					options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
				});

			var connectionString = "connectionString";

			// Добавление сервисов.
			builder.Services.AddTransient<IDriverRepository, DriverRepository>(
				x => new DriverRepository(x.GetService<IConfiguration>()[connectionString])
			);
			builder.Services.AddTransient<IBrandRepository, BrandRepository>(
				x => new BrandRepository(x.GetService<IConfiguration>()[connectionString])
			);
			builder.Services.AddTransient<IModelRepository, ModelRepository>(
				x => new ModelRepository(x.GetService<IConfiguration>()[connectionString])
			);
			builder.Services.AddTransient<ICarRepository, CarRepository>(
				x => new CarRepository(x.GetService<IConfiguration>()[connectionString])
			);
			builder.Services.AddTransient<IDriverCarRepository, DriverCarRepository>(
				x => new DriverCarRepository(x.GetService<IConfiguration>()[connectionString])
			);
			builder.Services.AddSingleton<ITaxCalculation, TaxCalculation>();

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
		}
	}
}