namespace MyApp.WebApi.Services.Base;

public interface ICalcService
{
    decimal Sum(decimal left, decimal right);
    decimal Divide(decimal left, decimal right);
}