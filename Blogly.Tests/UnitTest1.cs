namespace Blogly.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // arrange
        int firstNum = 2;
        int secondNum = 3;

        // act
        int sum = firstNum + secondNum;

        // assert
        Assert.Equal(5, sum);
    }
}