using CarWebApi.Model;

namespace CarWebApi.Models
{
	public class TaxReport
	{
		public string DriverLastName { get; set; }

		public string DriverFirstName { get; set; }

		public string DriverMiddleName { get; set; }

		public string CarBrand { get; set; }

		public string CarModel { get; set; }

		public int CarAge { get; set; }

		public int CarPower { get; set; }

		public double TaxSum { get; set; }
	}
}
