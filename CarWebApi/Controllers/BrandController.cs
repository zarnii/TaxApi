using CarWebApi.DAL.Interfaces;
using CarWebApi.DAL.DataBaseExceptions;
using CarWebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace CarWebApi.Controllers
{
	/// <summary>
	/// Контроллер операций над таблицей Brand.
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class BrandController : ControllerBase
	{
		/// <summary>
		/// Обработчик таблицы Brand.
		/// </summary>
		private IBrandRepository _brandRepository;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="brandRepository">Обработчик таблицы Brand.</param>
		public BrandController(IBrandRepository brandRepository)
		{
			_brandRepository = brandRepository;
		}

		/// <summary>
		/// Получение коллекции марак авто.
		/// </summary>
		/// <returns>Коллекция марак авто.</returns>
		[HttpGet]
		public async Task<ICollection<Brand>> GetBrands()
		{
			return await _brandRepository.GetBrands();
		}

		/// <summary>
		/// Получение марки авто по Id.
		/// </summary>
		/// <param name="id">Id марки авто.</param>
		/// <returns>Марка авто.</returns>
		[HttpGet("{id}")]
		public async Task<Brand> GetBrandById(Guid id)
		{
			return await _brandRepository.GetBrandById(id);
		}

		/// <summary>
		/// Добавление марки авто.
		/// </summary>
		/// <param name="brand">Добавляемая марка.</param>
		/// <returns></returns>
		[HttpPost]
		public async Task AddBrand([FromBody] Brand brand)
		{
			if (brand.Id == Guid.Empty)
			{
				brand.Id = Guid.NewGuid();
			}

			try
			{
				await _brandRepository.AddBrand(brand);
			}
			catch (ArgumentNullException ex)
			{
				throw ex;
			}
		}

		/// <summary>
		/// Изменение марки авто.
		/// </summary>
		/// <param name="brand">Марка авто.</param>
		/// <returns></returns>
		[HttpPut]
		public async Task EditBrand([FromBody] Brand brand)
		{
			try
			{
				await _brandRepository.EditBrand(brand);
			}
			catch (ArgumentNullException ex)
			{
				throw ex;
			}
			catch (RecordNotFoundException ex)
			{
				throw ex;
			}
		}
	}	
}
