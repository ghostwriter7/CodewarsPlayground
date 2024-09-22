using System.Numerics;
using NUnit.Framework;

namespace Playground.Kata5;

public static class LastDigitOfALargeNumber
{
    public static int GetLastDigit(BigInteger n1, BigInteger n2)
    {
        if (n2.IsZero)
            return 1;
        var lastDigitOfN1 = GetLastDigitOfBigInteger(n1);
        var cycleLength = RepeatingCycles[lastDigitOfN1].Length;
        var indexInCycle = (int)(n2 % cycleLength);
        return RepeatingCycles[lastDigitOfN1][indexInCycle == 0 ? cycleLength - 1 : indexInCycle - 1];
    }

    static LastDigitOfALargeNumber()
    {
        foreach (var digit in Enumerable.Range(0, 10))
        {
            List<int> cycles = [digit];
            var currentExponent = 2;
            while (true)
            {
                var lastDigit = (int)(Math.Pow(digit, currentExponent) % 10);
                if (lastDigit == digit)
                    break;
                currentExponent++;
                cycles.Add(lastDigit);
            }

            RepeatingCycles.Add(digit, cycles.ToArray());
        }
    }

    private static Dictionary<int, int[]> RepeatingCycles = new();

    private static int GetLastDigitOfBigInteger(BigInteger n) => (int)(n % 10);
}

[TestFixture]
public class LastDigitOfALargeNumberTests
{
    [Test]
    public void GetLastDigitTests()
    {
        Assert.That(LastDigitOfALargeNumber.GetLastDigit(4, 1), Is.EqualTo(4));
        Assert.That(LastDigitOfALargeNumber.GetLastDigit(4, 2), Is.EqualTo(6));
        Assert.That(LastDigitOfALargeNumber.GetLastDigit(9, 7), Is.EqualTo(9));
        Assert.That(LastDigitOfALargeNumber.GetLastDigit(10, BigInteger.Pow(10, 10)), Is.EqualTo(0));
        Assert.That(LastDigitOfALargeNumber.GetLastDigit(BigInteger.Pow(2, 200), BigInteger.Pow(2, 300)),
            Is.EqualTo(6));
        Assert.That(
            LastDigitOfALargeNumber.GetLastDigit(
                BigInteger.Parse("3715290469715693021198967285016729344580685479654510946723"),
                BigInteger.Parse("68819615221552997273737174557165657483427362207517952651")), Is.EqualTo(7));
    }
}