using CarWebApi.DAL.Interfaces;
using CarWebApi.DAL.DataBaseExceptions;
using CarWebApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace CarWebApi.DAL.Repositories
{
	/// <summary>
	/// Обработчик таблицы Brand.
	/// </summary>
	public class BrandRepository : IBrandRepository
	{
		/// <summary>
		/// Контекст данных приложения.
		/// </summary>
		private ApplicationContext _dbContext;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="connectionString">Строка подключения.</param>
		public BrandRepository(string connectionString)
		{
			if (String.IsNullOrEmpty(connectionString))
			{
				throw new ArgumentNullException(nameof(connectionString), "Пустая строка подключения.");
			}

			_dbContext = new ApplicationContext(connectionString);
		}

		/// <summary>
		/// Получение коллекции всех марак.
		/// </summary>
		/// <returns>Коллекция марак машин.</returns>
		[HttpGet]		
		public async Task<ICollection<Brand>> GetBrands()
		{
			using (_dbContext)
			{
				return await _dbContext.Brands
					.ToListAsync();
			}
		}

		/// <summary>
		/// Получение марки по Id.
		/// </summary>
		/// <param name="id">Id марки.</param>
		/// <returns>Экземпляр марки авто.</returns>
		[HttpGet("{id}")]
		public async Task<Brand> GetBrandById(Guid id)
		{
			using (_dbContext)
			{
				return await _dbContext.Brands
					.Where(b => b.Id == id)
					.FirstOrDefaultAsync();
			}
		}

		/// <summary>
		/// Добавление новой марки.
		/// </summary>
		/// <param name="brand">Марка авто.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">Пустой добовляемый объект.</exception>
		[HttpPost]
		public async Task AddBrand(Brand brand)
		{
			if (brand == null)
			{
				throw new ArgumentNullException(nameof(brand), "Пустой добовляемый объект.");
			}

			using (_dbContext)
			{
				await _dbContext.Brands.AddAsync(brand);
				await _dbContext.SaveChangesAsync();
			}
		}

		/// <summary>
		/// Изменение марки авто.
		/// </summary>
		/// <param name="brand">Изменяемая марка авто.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">Пустой изменяемый объект.</exception>
		/// <exception cref="RecordNotFoundException">Запись не найдена.</exception>
		[HttpPut]
		public async Task EditBrand(Brand brand)
		{
			if (brand == null)
			{
				throw new ArgumentNullException(nameof(brand), "Пустой изменяемый объект.");
			}

			using (_dbContext)
			{
				var changeableBrand = await _dbContext.Brands
					.Where(b => b.Id == brand.Id)
					.FirstOrDefaultAsync();

				if (changeableBrand == null)
				{
					throw new RecordNotFoundException("Запись не найдена.");
				}

				changeableBrand.Name = brand.Name;
				await _dbContext.SaveChangesAsync();
			}	
		}
	}
}
