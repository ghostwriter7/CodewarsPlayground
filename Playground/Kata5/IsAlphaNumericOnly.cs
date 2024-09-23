using NUnit.Framework;

namespace Playground.Kata5;

/// <summary>
/// You have to validate if a user input string is alphanumeric.
/// The given string is not nil/null/NULL/None, so you don't have to check that.
/// The string has the following conditions to be alphanumeric:
/// At least one character ("" is not valid)
/// Allowed characters are uppercase / lowercase latin letters and digits from 0 to 9
/// No whitespaces / underscore
/// </summary>
public class IsAlphaNumericOnly
{
    public static bool Check(string str)
    {
        return false;
    }
}

[TestFixture]
public class IsAlphaNumericOnlyTests
{
    private static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData("Mazinkaiser").Returns(true);
            yield return new TestCaseData("hello world_").Returns(false);
            yield return new TestCaseData("PassW0rd").Returns(true);
            yield return new TestCaseData("     ").Returns(false);
        }
    }

    [Test, TestCaseSource(nameof(TestCases))]
    public bool Test(string str) => IsAlphaNumericOnly.Check(str);
}