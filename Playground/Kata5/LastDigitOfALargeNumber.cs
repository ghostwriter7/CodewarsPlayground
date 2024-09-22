using System.Numerics;
using NUnit.Framework;

namespace Playground.Kata5;

public static class LastDigitOfALargeNumber
{
    public static int GetLastDigit(BigInteger a, BigInteger b)
    {
        return -1;
    }
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