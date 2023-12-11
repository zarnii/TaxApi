using CarWebApi.DAL.Interfaces;
using CarWebApi.DAL.DataBaseExceptions;
using CarWebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace CarWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarController : ControllerBase
	{
		private ICarRepository _carRepository;

		public CarController(ICarRepository carRepository)
		{
			_carRepository = carRepository;
		}

		[HttpGet]
		public async Task<ICollection<Car>> GetCars()
		{
			return await _carRepository.GetCars();
		}

		[HttpGet("{id}")]
		public async Task<Car> GetCarById(Guid id)
		{
			return await _carRepository.GetCarById(id);
		}


		[HttpPost]
		public async Task AddCar([FromBody]Car car)
		{
			if (car.Id == Guid.Empty)
			{
				car.Id = Guid.NewGuid();
			}

			try
			{
				await _carRepository.AddCar(car);
			}
			catch(ArgumentNullException ex)
			{
				throw ex;
			}
		}


		[HttpPut]
		public async Task EditCar([FromBody]Car car)
		{
			try
			{
				await _carRepository.EditCar(car);
			}
			catch(ArgumentNullException ex)
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
