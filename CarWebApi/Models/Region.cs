using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarWebApi.Model
{
	/// <summary>
	/// Регион номера.
	/// </summary>
	[Table("region")]
	public class Region
	{
		/// <summary>
		/// Id.
		/// </summary>
		[Column("id")]
		[Key]
		public Guid Id { get; set; }

		/// <summary>
		/// Регион.
		/// </summary>
		[Column("region")]
		public int RegionNumber { get; set; }
		
		/// <summary>
		/// Связующее свойство.
		/// </summary>
		public ICollection<CarNumberRegion> CarNumberRegions { get; set; } = new List<CarNumberRegion>();
	}
}
