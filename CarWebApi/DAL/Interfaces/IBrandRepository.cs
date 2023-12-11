using CarWebApi.Model;

namespace CarWebApi.DAL.Interfaces
{
	public interface IBrandRepository
	{
		Task<ICollection<Brand>> GetBrands();

		Task<Brand> GetBrandById(Guid id);

		Task AddBrand(Brand brand);

		Task EditBrand(Brand brand);
	}
}
