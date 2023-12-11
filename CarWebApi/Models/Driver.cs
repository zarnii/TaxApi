using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarWebApi.Model
{
	/// <summary>
	/// Водитель.
	/// </summary>
	[Table("driver")]
	public class Driver
	{
		/// <summary>
		/// Id.
		/// </summary>
		[Column("id")]
		[Key]
		public Guid Id { get; set; }

		/// <summary>
		/// Фамилия.
		/// </summary>
		[Column("secondname")]
		public string? SecondName { get; set; }

		/// <summary>
		/// Имя.
		/// </summary>
		[Column("firstname")]
		public string? FirstName { get; set; }

		/// <summary>
		/// Отчество.
		/// </summary>
		[Column("middlename")]
		public string? MiddleName { get; set; }

		/// <summary>
		/// Связующее свойство.
		/// </summary>
		public ICollection<DriverLicense> DriverLicenses { get; set; } = new List<DriverLicense>();

		/// <summary>
		/// Связующее свойтво.
		/// </summary>
		public ICollection<DriverCar> DriverСars { get; set; } = new List<DriverCar>();
	}
}
