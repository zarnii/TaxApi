using CarWebApi.Model;

namespace CarWebApi.DAL.Interfaces
{
	public interface IDriverCarRepository
	{
		Task<ICollection<DriverCar>> GetGriverCars();
	}
}
