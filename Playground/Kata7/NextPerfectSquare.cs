using NUnit.Framework;

namespace DefaultNamespace;

/// <summary>
/// Finds the next integral perfect square after the one passed as a parameter.
/// Recall that an integral perfect square is an integer n such that sqrt(n) is also an integer.
/// </summary>
public static class NextPerfectSquare
{
    public static long Get(long input)
    {
        var sqrt = Math.Sqrt(input);
        if (sqrt * sqrt != input)
            return -1;

        var nextInt = (long) sqrt  + 1;
        
        return nextInt * nextInt;
    }
}

[TestFixture]
public class NextPerfectSquareTests
{
    [TestCase(10, ExpectedResult = -1)]
    [TestCase(144, ExpectedResult = 169)]
    [TestCase(81, ExpectedResult = 100)]
    [TestCase(4503599627370497L, ExpectedResult = -1)]
    public long Get_ForIntInput_ShouldReturnNextIntPerfectSquare(long input) => NextPerfectSquare.Get(input);
}