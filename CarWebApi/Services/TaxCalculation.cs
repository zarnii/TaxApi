using CarWebApi.Model;
using CarWebApi.Services.Interfaces;

namespace CarWebApi.Services
{
    public class TaxCalculation : ITaxCalculation
	{
		private int _monthCountInOneYear = 12;

		public double Calculate(Car car, int holdingPeriod)
		{
			if (car == null)
			{
				throw new ArgumentNullException(nameof(car), "Пустой аргумент.");
			}

			return car.Model.Engine.Power 
				* (car.CarType.TaxCoefficient / 100) 
				* (holdingPeriod / _monthCountInOneYear);
		}
	}
}
