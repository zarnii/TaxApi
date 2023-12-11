using System.ComponentModel.DataAnnotations.Schema;

namespace CarWebApi.Model
{
	/// <summary>
	/// Номер машины без региона.
	/// </summary>
	[Table("carnumber")]	
	public class CarNumber
	{
		/// <summary>
		/// Id.
		/// </summary>
		[Column("id")]
		public Guid Id { get; set; }

		/// <summary>
		/// Номер.
		/// </summary>
		[Column("number")]
		public string? Number { get; set; }

		/// <summary>
		/// Связующее свойство.
		/// </summary>
		public ICollection<CarNumberRegion> CarNumberRegions { get; set; } = new List<CarNumberRegion>();
	}
}
