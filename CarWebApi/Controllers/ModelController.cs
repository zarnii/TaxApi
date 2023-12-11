using CarWebApi.DAL.Interfaces;
using CarWebApi.DAL.DataBaseExceptions;
using Microsoft.AspNetCore.Mvc;

namespace CarWebApi.Controllers
{
	/// <summary>
	/// Контроллер таблицы Model.
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class ModelController : ControllerBase
	{
		/// <summary>
		/// Обработчик таблицы Model.
		/// </summary>
		private IModelRepository _modelRepository;

		/// <summary>
		/// Контроллер.
		/// </summary>
		/// <param name="modelRepository">Обработчик таблицы Model.</param>
		public ModelController(IModelRepository modelRepository)
		{
			_modelRepository = modelRepository;
		}

		/// <summary>
		/// Получение коллекции моделей авто.
		/// </summary>
		/// <returns>Коллекция моделей авто.</returns>
		[HttpGet]
		public async Task<ICollection<Model.Model>> GetModels()
		{
			return await _modelRepository.GetModels();
		}

		/// <summary>
		/// Получение модели авто по Id.
		/// </summary>
		/// <param name="Id">Id авто.</param>
		/// <returns>Модель.</returns>
		[HttpGet("{id}")]
		public async Task<Model.Model> GetModelById(Guid Id)
		{
			return await _modelRepository.GetModelById(Id);
		}

		/// <summary>
		/// Добавление модели авто.
		/// </summary>
		/// <param name="model">Добовляемая модель.</param>
		/// <returns></returns>
		[HttpPost]
		public async Task AddModel([FromBody] Model.Model model)
		{
			if (model.Id == Guid.Empty)
			{
				model.Id = Guid.NewGuid();
			}

			try
			{
				await _modelRepository.AddModel(model);
			}
			catch (ArgumentNullException ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Изменение модели авто.
		/// </summary>
		/// <param name="model">Модель.</param>
		/// <returns></returns>
		[HttpPut]
		public async Task EditModel([FromBody] Model.Model model)
		{
			try
			{
				await _modelRepository.EditModel(model);
			}
			catch (ArgumentNullException ex)
			{
				throw ex;
			}
			catch(RecordNotFoundException ex)
			{
				throw ex;
			}
		}
	}
}
