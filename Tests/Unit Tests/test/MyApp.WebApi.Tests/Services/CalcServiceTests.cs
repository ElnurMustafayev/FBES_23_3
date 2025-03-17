using MyApp.WebApi.Services;

namespace MyApp.WebApi.Tests.Services;

public class CalcServiceTests
{
    private readonly CalcService service;

    public CalcServiceTests()
    {
        this.service = new CalcService();
    }

    [Fact]
    public void Tests1() {
        var result = this.service.Sum(5, 2);
        Assert.Equal(7, result);
    }

    [Theory]
    [InlineData(2, 5, 7)]
    [InlineData(0, 0, 0)]
    [InlineData(-3, -4, -7)]
    [InlineData(-3, 10, 7)]
    public void Tests2(decimal num1, decimal num2, decimal expectedResult) {
        var result = this.service.Sum(num1, num2);
        Assert.Equal(expectedResult, result);
    }

    [Fact]
    public void Tests3() {
        Assert.Throws<ArgumentException>(() => this.service.Divide(5, 0));
    }
}