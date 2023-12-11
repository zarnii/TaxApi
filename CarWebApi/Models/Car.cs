using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CarWebApi.Model;

namespace CarWebApi.Model
{
	/// <summary>
	/// Машина.
	/// </summary>
	[Table("car")]
	public class Car
	{
		/// <summary>
		/// Id.
		/// </summary>
		[Column("id")]
		[Key]
		public Guid Id { get; set; }

		/// <summary>
		/// Id марки.
		/// </summary>
		[Column("brand")]
		public Guid BrandId { get; set; }

		/// <summary>
		/// Связующее свойство.
		/// </summary>
		public Brand? Brand { get; set; }

		/// <summary>
		/// Id модели.
		/// </summary>
		[Column("model")]
		public Guid ModelId { get; set; }

		/// <summary>
		/// Связующее свойство.
		/// </summary>
		public Model? Model { get; set; }

		/// <summary>
		/// Id номера с регионом.
		/// </summary>
		[Column("carnumberregion")]
		public Guid CarNumberRegionId { get; set; }

		/// <summary>
		/// Связующее свойство.
		/// </summary>
		public CarNumberRegion? CarNumberRegion { get; set; }


		[Column("creationyear")]
		public DateOnly CreationYear { get; set; }

		[Column("cartype")]
		public Guid CarTypeId { get; set; }

		/// <summary>
		/// Связующее свойство.
		/// </summary>
		public CarType? CarType { get; set; }

		/// <summary>
		/// Связующее свойство.
		/// </summary>
		public ICollection<DriverCar> DriverCars { get; set; } = new List<DriverCar>();
	}
}
