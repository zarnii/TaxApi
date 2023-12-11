using CarWebApi.DAL.Interfaces;
using CarWebApi.Model;
using Microsoft.EntityFrameworkCore;
using CarWebApi.DAL.DataBaseExceptions;

namespace CarWebApi.DAL.Repositories
{
    /// <summary>
    /// Обработчик таблицы Driver.
    /// </summary>
    public class DriverRepository : IDriverRepository
	{
		/// <summary>
		/// Контекст данных приложения.
		/// </summary>
		private ApplicationContext _dbContext;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="connectionString">Строка подключения.</param>
		public DriverRepository(string connectionString)
		{
			if (String.IsNullOrEmpty(connectionString))
			{
				throw new ArgumentNullException(nameof(connectionString), "Пустая строка подключения.");
			}

			_dbContext = new ApplicationContext(connectionString);
		}

		/// <summary>
		/// Получение всех водителей.
		/// </summary>
		/// <returns>Коллекция водителей.</returns>
		public async Task<ICollection<Driver>> GetDrivers()
		{
			using (_dbContext)
			{
				return await _dbContext.Drivers
					.Include(d => d.DriverLicenses)
					.ToListAsync();
			}
		}

		/// <summary>
		/// Получение водителя по Id.
		/// </summary>
		/// <param name="id">Id водителя.</param>
		/// <returns>Водителя.</returns>
		public async Task<Driver> GetDriverById(Guid id)
		{
			using (_dbContext)
			{
				var driver = await _dbContext.Drivers
					.Where(d => d.Id == id)
					.Include(d => d.DriverLicenses)
					.FirstOrDefaultAsync();

				return driver;
			}
		}

		/// <summary>
		/// Добавление водителя.
		/// </summary>
		/// <param name="driver">Водитель.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">Пустой добовляемый объект.</exception>
		public async Task AddDriver(Driver driver)
		{
			if (driver == null)
			{
				throw new ArgumentNullException(nameof(driver), "Пустой добовляемый объект.");
			}

			using (_dbContext)
			{
				await _dbContext.Drivers.AddAsync(driver);
				await _dbContext.SaveChangesAsync();
			}
		}

		/// <summary>
		/// Изменение данных водителя.
		/// </summary>
		/// <param name="driver">Водитель.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">Пустой изменяемый объект.</exception>
		/// <exception cref="RecordNotFoundException">Изменяемая запись не найдена.</exception>
		public async Task EditDriver(Driver driver)
		{
			if (driver == null)
			{
				throw new ArgumentNullException(nameof(driver), "Пустой изменяемый объект.");
			}

			using (_dbContext)
			{
				var changeableDriver = await _dbContext.Drivers
					.Where(d => d.Id == driver.Id)
					.FirstOrDefaultAsync();

				if (changeableDriver == null)
				{
					throw new RecordNotFoundException("Запись не найдена.");
				}

				changeableDriver.FirstName = driver.FirstName;
				changeableDriver.SecondName = driver.SecondName;
				changeableDriver.MiddleName = driver.MiddleName;

				await _dbContext.SaveChangesAsync();
			}
		}
	}
}
