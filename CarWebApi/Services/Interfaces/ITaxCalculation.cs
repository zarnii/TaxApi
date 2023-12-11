using CarWebApi.Model;

namespace CarWebApi.Services.Interfaces
{
    public interface ITaxCalculation
    {
        double Calculate(Car car, int holdingPeriod);
    }
}