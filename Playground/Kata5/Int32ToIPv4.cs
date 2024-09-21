using NUnit.Framework;

namespace Playground.Kata5;

public static class Int32ToIPv4
{
    public static string UInt32ToIP(uint ip)
    {
        return null;
    }
}

[TestFixture]
public class Int32ToIPv4Tests
{
    [Test]
    public void Test()
    {
        Assert.That("128.114.17.104", Is.EqualTo(Int32ToIPv4.UInt32ToIP(2154959208)));
        Assert.That("0.0.0.0", Is.EqualTo(Int32ToIPv4.UInt32ToIP(0)));
        Assert.That("128.32.10.1", Is.EqualTo(Int32ToIPv4.UInt32ToIP(2149583361)));
    }
}