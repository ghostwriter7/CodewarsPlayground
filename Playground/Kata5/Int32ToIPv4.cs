using System.Text;
using NUnit.Framework;

namespace Playground.Kata5;

public static class Int32ToIPv4
{
    /// <summary>
    /// Given:   01001000 01101100 10010010 10001101
    /// IP >> 24 00000000 00000000 00000000 01001000
    ///          00000000 00000000 00000000 01001000 & 0xFF -> which is 11111111
    /// Gives:                              01001000
    /// </summary>
    
    public static string UInt32ToIP(uint ip) => $"{ip >> 24 & 0xFF}.{ip >> 16 & 0xFF}.{ip >> 8 & 0xFF}.{ip & 0xFF}";
}

[TestFixture]
public class Int32ToIPv4Tests
{
    [Test]
    public void Test()
    {
        Assert.That(Int32ToIPv4.UInt32ToIP(2154959208), Is.EqualTo("128.114.17.104"));
        Assert.That(Int32ToIPv4.UInt32ToIP(0), Is.EqualTo("0.0.0.0"));
        Assert.That(Int32ToIPv4.UInt32ToIP(2149583361), Is.EqualTo("128.32.10.1"));
        Assert.That(Int32ToIPv4.UInt32ToIP(1214839181), Is.EqualTo("72.104.249.141"));
    }
}