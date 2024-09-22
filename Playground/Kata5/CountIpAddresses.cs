using NUnit.Framework;
using System.Net;
using System.Numerics;

namespace Playground.Kata5;

public static class CountIpAddresses
{
    public static long IpsBetween(string start, string end) => IpToLong(end) - IpToLong(start);

    private static long IpToLong(string start) => (long)start.Split('.')
            .Select((octet, index) => (octet: int.Parse(octet), index))
            .Aggregate(BigInteger.One,
                (total, tuple) =>
                    BigInteger.Add(total, BigInteger.Multiply(tuple.octet, (int)Math.Pow(256, 3 - tuple.index))));
}

[TestFixture]
public class CountIpAddressesTests
{
    [Test]
    public void IpsBetweenTests()
    {
        Assert.That(CountIpAddresses.IpsBetween("10.0.0.0", "10.0.0.50"), Is.EqualTo(50));
        Assert.That(CountIpAddresses.IpsBetween("20.0.0.10", "20.0.1.0"), Is.EqualTo(246));
        Assert.That(CountIpAddresses.IpsBetween("0.0.0.0", "255.255.255.255"), Is.EqualTo((1L << 32) - 1L));
    }
}