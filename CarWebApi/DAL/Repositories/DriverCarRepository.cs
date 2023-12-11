using CarWebApi.DAL.Interfaces;
using CarWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace CarWebApi.DAL.Repositories
{
	/// <summary>
	/// Обработчик таблицы CarDriver.
	/// </summary>
	public class DriverCarRepository : IDriverCarRepository
	{
		/// <summary>
		/// Контекст данных приложения.
		/// </summary>
		private ApplicationContext _dbContext;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="connectionString"></param>
		/// <exception cref="ArgumentNullException"></exception>
		public DriverCarRepository(string connectionString)
		{
			if (String.IsNullOrEmpty(connectionString))
			{
				throw new ArgumentNullException(nameof(connectionString), "Пустая строка подключения.");
			}

			_dbContext= new ApplicationContext(connectionString);
		}

		/// <summary>
		/// Получение всех записей из таблицы.
		/// </summary>
		/// <returns></returns>
		public async Task<ICollection<DriverCar>> GetGriverCars()
		{
			using (_dbContext)
			{
				return await _dbContext.DriverCars
					.Include(dc => dc.Driver)
					.Include(dc => dc.Car)
						.ThenInclude(c => c.Brand)
					.Include(dc => dc.Car)
						.ThenInclude(c => c.Model)
							.ThenInclude(m => m.Engine)
					.Include(dc => dc.Car)
						.ThenInclude(c => c.CarType)
					.ToListAsync();
			}
		}
	}
}
