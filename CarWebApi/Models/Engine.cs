using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWebApi.Model
{
	/// <summary>
	/// Двигатель.
	/// </summary>
	[Table("engine")]
	public class Engine
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
		[Column("power")]
		public int Power { get; set; }

		public ICollection<Model> Models { get; set; } = new List<Model>();
	}
}
