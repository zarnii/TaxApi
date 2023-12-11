using CarWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CarWebApi.DAL
{
	/// <summary>
	/// Контекст данных приложения.
	/// </summary>
	public class ApplicationContext: DbContext
	{
		#region fields
		/// <summary>
		/// Строка подключения к базе данных.
		/// </summary>
		private string _connectionString;
		#endregion

		#region properties
		public DbSet<Brand> Brands { get; set; } = null!;
		public DbSet<CarNumber> CarNumbers { get; set; } = null!;
		public DbSet<Region> Regions { get; set; } = null!;
		public DbSet<Engine> Engines { get; set; } = null!;
		public DbSet<Model.Model> Models { get; set; } = null!;
		public DbSet<CarNumberRegion> CarNumberRegions { get; set; } = null!;
		public DbSet<Car> Cars { get; set; } = null!;
		public DbSet<Driver> Drivers { get; set; } = null!;
		public DbSet<DriverLicense> DriverLicenses { get; set; } = null!;
		public DbSet<DriverCar> DriverCars { get; set; } = null!;
		#endregion

		#region constructor
		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="connectionString">Строка подкоючения.</param>
		/// <exception cref="ArgumentNullException">Пустая строка подключения к базе данных.</exception>
		public ApplicationContext(string connectionString) 
		{
			if (String.IsNullOrEmpty(connectionString))
			{
				throw new ArgumentNullException(nameof(connectionString), "Пустая строка подключения к базе данных.");
			}

			_connectionString = connectionString;

			Database.EnsureCreated();
		}
		#endregion

		#region methods
		/// <summary>
		/// Конфигурация подключения.
		/// </summary>
		/// <param name="optionsBuilder"></param>
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql(_connectionString);
		}

		/// <summary>
		/// Создание связей между таблицами.
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Выстраиватеся связь м-к-м между CarNumber-Region.
			modelBuilder.Entity<CarNumberRegion>()
				.HasOne(cn => cn.CarNumber)
				.WithMany(c => c.CarNumberRegions)
				.HasForeignKey(cn => cn.CarNumberId);

			modelBuilder.Entity<CarNumberRegion>()
				.HasOne(cn => cn.Region)
				.WithMany(r => r.CarNumberRegions)
				.HasForeignKey(cn => cn.RegionId);


			// Один ко многим Brand-Car.
			modelBuilder.Entity<Brand>()
				.HasMany(e => e.Cars)
				.WithOne(e => e.Brand)
				.HasForeignKey(e => e.BrandId);

			// Один ко многим Engine-Model.
			modelBuilder.Entity<Engine>()
				.HasMany(e => e.Models)
				.WithOne(e => e.Engine)
				.HasForeignKey(e => e.EngineId);

			// Один ко многим Model-Car.
			modelBuilder.Entity<Model.Model>()
				.HasMany(e => e.Cars)
				.WithOne(e => e.Model)
				.HasForeignKey(e => e.ModelId);

			// Один к одному Car-CarNumberRegion.
			modelBuilder.Entity<Car>()
				.HasOne(c => c.CarNumberRegion)
				.WithOne(cnr => cnr.Car)
				.HasForeignKey<Car>(c => c.CarNumberRegionId);

			modelBuilder.Entity<Car>()
				.HasOne(c => c.CarType)
				.WithMany(ct => ct.Cars)
				.HasForeignKey(c => c.CarTypeId);

			// Один ко многим Driver-DriverLicense.
			modelBuilder.Entity<Driver>()
				.HasMany(e => e.DriverLicenses)
				.WithOne(e => e.Driver)
				.HasForeignKey(e => e.DriverId);

			// Выстраиватеся связь м-к-м между Driver-Car.
			modelBuilder.Entity<DriverCar>()
				.HasOne(e => e.Driver)
				.WithMany(e => e.DriverСars)
				.HasForeignKey(e => e.DriverId);

			modelBuilder.Entity<DriverCar>()
				.HasOne(e => e.Car)
				.WithMany(e => e.DriverCars)
				.HasForeignKey(e => e.CarId);
		}
		#endregion
	}
}
