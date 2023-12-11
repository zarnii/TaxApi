using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarWebApi.Model
{
	/// <summary>
	/// Модель машины.
	/// </summary>
	[Table("model")]	
	public class Model
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

		/// <summary>
		/// Мощность в л.с.
		/// </summary>
		[Column("engine")]
		public Guid EngineId { get; set; }

		public Engine? Engine { get; set; }

		public ICollection<Car> Cars { get; set; } = new List<Car>();
	}
}
