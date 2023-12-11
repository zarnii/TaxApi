using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarWebApi.Model
{
	/// <summary>
	/// Номер машины с регионом.
	/// </summary>
	[Table("carnumberregion")]
	public class CarNumberRegion
	{
		/// <summary>
		/// Id.
		/// </summary>
		[Column("id")]
		[Key]
		public Guid Id { get; set; }

		/// <summary>
		/// Id номера машины без региона.
		/// </summary>
		[Column("carnumber")]
		public Guid CarNumberId { get; set; }

		/// <summary>
		/// Навигационное свойтсво номера машины без региона.
		/// </summary>
		public CarNumber? CarNumber { get; set; }

		/// <summary>
		/// Id региона.
		/// </summary>
		[Column("region")]
		public Guid RegionId { get; set; }
		
		/// <summary>
		/// Навишационное свойство региона.
		/// </summary>
		public Region? Region { get; set; }

		/// <summary>
		/// Связующее свойство.
		/// </summary>
		public Car? Car { get; set; }
	}
}
