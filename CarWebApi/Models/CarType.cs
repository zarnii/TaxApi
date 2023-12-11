using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarWebApi.Model;

namespace CarWebApi.Model
{
	/// <summary>
	/// Таблица CarType.
	/// </summary>
	[Table("cartype")]
	public class CarType
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
		public string Name { get; set; }

		/// <summary>
		/// Коэфициент налога в копейках.
		/// </summary>
		[Column("taxcoefficient")]
		public int TaxCoefficient { get; set; }

		/// <summary>
		/// Связующее свойство.
		/// </summary>
		public ICollection<Car> Cars { get; set; } = new List<Car>();
	}
}
