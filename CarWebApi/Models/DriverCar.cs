using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWebApi.Model
{
	/// <summary>
	/// Связь Водитель-Машина.
	/// </summary>
	[Table("drivercar")]
	public class DriverCar
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
		/// Id машины.
		/// </summary>
		[Column("car")]
		public Guid CarId { get; set; }

		public Car? Car { get; set; }

		/// <summary>
		/// Период владения в течении года в месяцах.
		/// </summary>
		[Column("holdingperiod")]
		public int HoldingPariod { get; set; }
	}
}
