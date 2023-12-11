using CarWebApi.DAL.Interfaces;
using CarWebApi.DAL.DataBaseExceptions;
using Microsoft.EntityFrameworkCore;

namespace CarWebApi.DAL.Repositories
{
	/// <summary>
	/// Обработчик таблицы Model.
	/// </summary>
	public class ModelRepository : IModelRepository
	{
		/// <summary>
		/// Констекст данных приложения.
		/// </summary>
		private ApplicationContext _dbContext;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="connectionString">Строка подключения.</param>
		/// <exception cref="ArgumentNullException">Пустая строка подключения.</exception>
		public ModelRepository(string connectionString)
		{
			if (String.IsNullOrEmpty(connectionString))
			{
				throw new ArgumentNullException(nameof(connectionString), "Пустая строка подключения.");
			}

			_dbContext = new ApplicationContext(connectionString);
		}

		/// <summary>
		/// Получение всех поделей авто.
		/// </summary>
		/// <returns>Коллекцию моделей.</returns>
		public async Task<ICollection<Model.Model>> GetModels()
		{
			using (_dbContext)
			{
				return await _dbContext.Models
					.Include(m => m.Engine)
					.ToListAsync();
			}
		}

		/// <summary>
		/// Получение модели авто по Id.
		/// </summary>
		/// <param name="id">Id модели.</param>
		/// <returns>Модель.</returns>
		public async Task<Model.Model> GetModelById(Guid id)
		{
			using (_dbContext)
			{
				return await _dbContext.Models
					.Where(m => m.Id == id)
					.Include(m => m.Engine)
					.FirstOrDefaultAsync();
			}
		}

		/// <summary>
		/// Добавление модели авто.
		/// </summary>
		/// <param name="model">Модель.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">Пустой добовляемый объект.</exception>
		public async Task AddModel(Model.Model model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model), "Пустой добовляемый объект.");
			}

			using (_dbContext)
			{
				await _dbContext.Models.AddAsync(model);
				await _dbContext.SaveChangesAsync();
			}
		}

		/// <summary>
		/// Изменение модели авто.
		/// </summary>
		/// <param name="model">Модель.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">Пустой обновляемый объект.</exception>
		/// <exception cref="RecordNotFoundException">Запись не найдена.</exception>
		public async Task EditModel(Model.Model model)
		{
			if (model == null)
			{
				throw new ArgumentNullException(nameof(model), "Пустой обновляемый объект.");
			}

			using (_dbContext)
			{
				var changeableModel = await _dbContext.Models
					.Where(m => m.Id == model.Id)
					.Include(m => m.Engine)
					.FirstOrDefaultAsync();

				if (changeableModel == null)
				{
					throw new RecordNotFoundException("Запись не найдена.");
				}

				changeableModel.Name = model.Name;
				changeableModel.EngineId = model.EngineId;	

				await _dbContext.SaveChangesAsync();
			}
		}
	}
}
