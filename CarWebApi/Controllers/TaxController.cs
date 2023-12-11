using CarWebApi.DAL.Interfaces;
using CarWebApi.Models;
using CarWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TaxController : ControllerBase
	{
		private IDriverCarRepository _driverCarRepository;

		private ITaxCalculation _taxCalculation;

		public TaxController(IDriverCarRepository driverCarRepository, ITaxCalculation taxCalculation)
		{
			_driverCarRepository = driverCarRepository;
			_taxCalculation = taxCalculation;
		}

		[HttpGet]
		public async Task<ICollection<TaxReport>> GetReports()
		{
			var driverCars = await _driverCarRepository.GetGriverCars();

			if (driverCars == null)
			{
				return null;
			}

			var taxList = new List<TaxReport>();

			foreach (var driverCar in driverCars)
			{
				var tax = _taxCalculation.Calculate(driverCar.Car, driverCar.HoldingPariod);

				taxList.Add(new TaxReport()
				{
					DriverLastName = driverCar.Driver.SecondName,
					DriverFirstName = driverCar.Driver.FirstName,
					DriverMiddleName = driverCar.Driver.MiddleName,
					CarBrand = driverCar.Car.Brand.Name,
					CarModel = driverCar.Car.Model.Name,
					CarAge = DateTime.Now.Year - driverCar.Car.CreationYear.Year,
					CarPower = driverCar.Car.Model.Engine.Power,
					TaxSum = tax
				});
			}

			return taxList;
		}
	}
}
