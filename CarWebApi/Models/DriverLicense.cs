using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWebApi.Model
{
	/// <summary>
	/// Водительские права.
	/// </summary>
	[Table("driverlicense")]
	public class DriverLicense
	{
		/// <summary>
		/// Id.
		/// </summary>
		[Column("id")]
		[Key]
		public Guid Id { get; set; }

		/// <summary>
		/// Id водителя.
		/// </summary>
		[Column("driver")]
		public Guid DriverId { get; set; }

		/// <summary>
		/// Связующее свойство.
		/// </summary>
		public Driver? Driver { get; set; }

		/// <summary>
		/// Дата начала действия прав.
		/// </summary>
		[Column("datestart")]
		public DateTime DateStart { get; set; }

		/// <summary>
		/// Дата окончания действия прав.
		/// </summary>
		[Column("dateend")]
		public DateTime DateEnd { get; set; }
	}
}
