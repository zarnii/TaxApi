using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarWebApi.Model
{
	/// <summary>
	/// Марка машины.
	/// </summary>
	[Table("brand")]
	public class Brand
	{
		/// <summary>
		/// Id.
		/// </summary>
		[Column("id")]
		[Key]
		public Guid Id { get; set; }

		/// <summary>
		/// Название.
		/// </summary>
		[Column("name")]
		public string? Name { get; set; }

		public ICollection<Car> Cars { get; set; } = new List<Car>();
	}
}
