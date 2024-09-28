using System.Net;
using NUnit.Framework;

namespace Playground.Kata6;

public class IPValidation
{
    public static bool IsValidIp(string ipAddress)
    {
        var segments = ipAddress.Split('.').ToArray();

        if (segments.Length != 4)
            return false;

        return segments.All((segment) =>
        {
            if (segment.StartsWith('0') && segment.Length > 1 || segment.Any(char.IsWhiteSpace))
                return false;
            
            if (!int.TryParse(segment, out var result))
                return false;
            return result is >= 0 and <= 255;
        });
    }
}

[TestFixture]
public class IPValidationTests
{
    private static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData("0.0.0.0").Returns(true);
            yield return new TestCaseData("12.255.56.1").Returns(true);
            yield return new TestCaseData("137.255.156.100").Returns(true);
            yield return new TestCaseData("").Returns(false);
            yield return new TestCaseData("abc.def.ghi.jkl").Returns(false);
            yield return new TestCaseData("123.456.789.0").Returns(false);
            yield return new TestCaseData("12.34.56").Returns(false);
            yield return new TestCaseData("12.34.56.00").Returns(false);
            yield return new TestCaseData("12.34.56.7.8").Returns(false);
            yield return new TestCaseData("12.34.256.78").Returns(false);
            yield return new TestCaseData("1234.34.56").Returns(false);
            yield return new TestCaseData("pr12.34.56.78").Returns(false);
            yield return new TestCaseData("12.34.56.78sf").Returns(false);
            yield return new TestCaseData("12.34.56 .1").Returns(false);
            yield return new TestCaseData("12.34.56.-1").Returns(false);
            yield return new TestCaseData("123.045.067.089").Returns(false);
            
        }
    }

    [Test, TestCaseSource("TestCases")]
    public static bool IsValidIpTests(string ip) => IPValidation.IsValidIp(ip);
}