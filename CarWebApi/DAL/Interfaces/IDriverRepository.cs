using CarWebApi.Model;

namespace CarWebApi.DAL.Interfaces
{
    public interface IDriverRepository
    {
        Task<ICollection<Driver>> GetDrivers();

        Task<Driver> GetDriverById(Guid id);

        Task AddDriver(Driver driver);

        Task EditDriver(Driver driver);
	}
}