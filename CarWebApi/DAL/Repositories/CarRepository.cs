using CarWebApi.DAL.Interfaces;
using CarWebApi.DAL.DataBaseExceptions;
using CarWebApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CarWebApi.DAL.Repositories
{
	/// <summary>
	/// Обработчик таблицы Car.
	/// </summary>
	public class CarRepository : ICarRepository
	{
		/// <summary>
		/// Контекст данных приложения.
		/// </summary>
		private ApplicationContext _dbContext;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="connectionString">Строка подключения.</param>
		/// <exception cref="ArgumentNullException">Пустая строка подключения.</exception>
		public CarRepository(string connectionString)
		{
			if (String.IsNullOrEmpty(connectionString))
			{
				throw new ArgumentNullException(nameof(connectionString), "Пустая строка подключения.");
			}

			_dbContext = new ApplicationContext(connectionString);
		}

		/// <summary>
		/// Получение коллекции машин.
		/// </summary>
		/// <returns>Коллекция машин.</returns>
		public async Task<ICollection<Car>> GetCars()
		{
			using (_dbContext)
			{
				return await _dbContext.Cars
					.Include(c => c.Brand)
					.Include(c => c.Model)
						.ThenInclude(m => m.Engine)
					.Include(c => c.CarNumberRegion)
						.ThenInclude(cnr => cnr.CarNumber)
					.Include(c => c.CarNumberRegion)
						.ThenInclude(cnr => cnr.Region)
					.ToArrayAsync();
			}
		}

		/// <summary>
		/// Получение машины по Id.
		/// </summary>
		/// <param name="id">Id машины.</param>
		/// <returns>Машина.</returns>
		public async Task<Car> GetCarById(Guid id)
		{
			using (_dbContext)
			{
				return await _dbContext.Cars
					.Where(c => c.Id == id)
					.Include(c => c.Brand)
					.Include(c => c.CarType)
					.Include(c => c.Model)
						.ThenInclude(m => m.Engine)
					.Include(c => c.CarNumberRegion)
						.ThenInclude(cnr => cnr.CarNumber)
					.Include(c => c.CarNumberRegion)
						.ThenInclude(cnr => cnr.Region)
					.FirstOrDefaultAsync();
			}
		}

		/// <summary>
		/// Добавление машины.
		/// </summary>
		/// <param name="car">Машина.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">Пустой добовляемый объект.</exception>
		public async Task AddCar(Car car)
		{
			if (car == null)
			{
				throw new ArgumentNullException(nameof(car), "Пустой добовляемый объект.");
			}

			using (_dbContext)
			{
				await _dbContext.Cars.AddAsync(car);
				await _dbContext.SaveChangesAsync();
			}
		}

		/// <summary>
		/// Изменение машины.
		/// </summary>
		/// <param name="car">Машина.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">Пустой изменяемый объект.</exception>
		/// <exception cref="RecordNotFoundException">Запись не найдена.</exception>
		public async Task EditCar(Car car)
		{
			if (car == null)
			{
				throw new ArgumentNullException(nameof(car), "Пустой изменяемый объект.");
			}

			using (_dbContext)
			{
				var changeableCar = await _dbContext.Cars
					.Where(c => c.Id == car.Id)
					.Include(c => c.Brand)
					.Include(c => c.CarType)
					.Include(c => c.Model)
						.ThenInclude(m => m.Engine)
					.Include(c => c.CarNumberRegion)
						.ThenInclude(cnr => cnr.CarNumber)
					.Include(c => c.CarNumberRegion)
						.ThenInclude(cnr => cnr.Region)
					.FirstOrDefaultAsync();

				if (changeableCar == null)
				{
					throw new RecordNotFoundException("Запись не найдена.");
				}

				changeableCar.BrandId = car.BrandId;
				changeableCar.ModelId = car.ModelId;
				changeableCar.CarNumberRegionId = car.CarNumberRegionId;
				changeableCar.CreationYear = car.CreationYear;

				await _dbContext.SaveChangesAsync();
			}
		}	
	}
}
