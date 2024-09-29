using NUnit.Framework;

namespace Playground.Kata4;

public static class HumanTimeFormat
{
    public static string FormatDuration(int seconds)
    {
        return null;
    }
}

[TestFixture]
public class Tests {

    private IEnumerable<TestCaseData> TestCaseData
    {
        get
        {
            yield return new TestCaseData(HumanTimeFormat.FormatDuration(0)).Returns("now");
            yield return new TestCaseData(HumanTimeFormat.FormatDuration(1)).Returns("1 second");
            yield return new TestCaseData(HumanTimeFormat.FormatDuration(62)).Returns("1 minute and 2 seconds");
            yield return new TestCaseData(HumanTimeFormat.FormatDuration(120)).Returns("2 minutes");
            yield return new TestCaseData(HumanTimeFormat.FormatDuration(3662)).Returns("1 hour, 1 minute and 2 seconds");
            yield return new TestCaseData(HumanTimeFormat.FormatDuration(15731080)).Returns("182 days, 1 hour, 44 minutes and 40 seconds");
            yield return new TestCaseData(HumanTimeFormat.FormatDuration(132030240)).Returns("4 years, 68 days, 3 hours and 4 minutes");
            yield return new TestCaseData(HumanTimeFormat.FormatDuration(205851834)).Returns("6 years, 192 days, 13 hours, 3 minutes and 54 seconds");
            yield return new TestCaseData(HumanTimeFormat.FormatDuration(253374061)).Returns("8 years, 12 days, 13 hours, 41 minutes and 1 second");
            yield return new TestCaseData(HumanTimeFormat.FormatDuration(242062374)).Returns("7 years, 246 days, 15 hours, 32 minutes and 54 seconds");
            yield return new TestCaseData(HumanTimeFormat.FormatDuration(101956166)).Returns("3 years, 85 days, 1 hour, 9 minutes and 26 seconds");
            yield return new TestCaseData(HumanTimeFormat.FormatDuration(33243586)).Returns("1 year, 19 days, 18 hours, 19 minutes and 46 seconds");
        }
    }

    [Test, TestCaseSource("TestCaseData")]
    public string FormatDurationTests(int input) => HumanTimeFormat.FormatDuration(input);
}