using CarWebApi.DAL.DataBaseExceptions;
using CarWebApi.DAL.Interfaces;
using CarWebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace CarWebApi.Controllers
{
	/// <summary>
	/// Контроллер операций над таблицей Driver.
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class DriverController : ControllerBase
	{
		/// <summary>
		/// Обработчик таблицы Driver.
		/// </summary>
		private IDriverRepository _driverRepository;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="driverRepository">Обработчик таблицы Driver.</param>
		public DriverController(IDriverRepository driverRepository)
		{
			_driverRepository = driverRepository;
		}

		/// <summary>
		/// Получение списка всех водителей.
		/// </summary>
		/// <returns>Коллеция объектов Driver.</returns>
		[HttpGet]
		public async Task<ICollection<Driver>> GetDrivers()
		{
			return await _driverRepository.GetDrivers();
		}

		/// <summary>
		/// Получение водителя по Id.
		/// </summary>
		/// <param name="id">Id водителя.</param>
		/// <returns>Объект Driver.</returns>
		[HttpGet("{id}")]
		public async Task<Driver> GetDriverById(Guid id)
		{
			return await _driverRepository.GetDriverById(id);
		}

		/// <summary>
		/// Добовление нового водителя.
		/// </summary>
		/// <param name="driver">Водитель.</param>
		/// <returns></returns>
		[HttpPost]
		public async Task AddDriver([FromBody] Driver driver)
		{
			if (driver.Id == Guid.Empty)
			{
				driver.Id = Guid.NewGuid();
			}

			try
			{
				await _driverRepository.AddDriver(driver);
			}
			catch (ArgumentNullException ex)
			{
				throw ex;
			}

		}

		/// <summary>
		/// Изменение данных водителя.
		/// </summary>
		/// <param name="driver">Водитель.</param>
		/// <returns></returns>
		[HttpPut]
		public async Task EditDriver([FromBody] Driver driver)
		{
			try
			{
				await _driverRepository.EditDriver(driver);
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
