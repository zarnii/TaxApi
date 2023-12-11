namespace CarWebApi.DAL.Interfaces
{
	public interface IModelRepository
	{
		Task<ICollection<Model.Model>> GetModels();

		Task<Model.Model> GetModelById(Guid id);

		Task AddModel(Model.Model model);

		Task EditModel (Model.Model model);
	}
}
