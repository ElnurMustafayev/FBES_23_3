namespace MyApp.WebApi.Services;

using MyApp.WebApi.Services.Base;

public class CalcService : ICalcService
{
    public decimal Sum(decimal left, decimal right)
    {
        return left + right;
    }

    public decimal Divide(decimal left, decimal right)
    {
        if(right == 0) {
            throw new ArgumentException("Delitel ne mojet bit 0!", nameof(right));
        }

        return left / right;
    }
}