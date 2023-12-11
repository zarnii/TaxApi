using CarWebApi.Model;

namespace CarWebApi.DAL.Interfaces
{
	public interface ICarRepository
	{
		Task<ICollection<Car>> GetCars();

		Task<Car> GetCarById(Guid id);

		Task AddCar(Car car);

		Task EditCar(Car car);
	}
}
