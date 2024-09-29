using System.Text;
using NUnit.Framework;

namespace Playground.Kata4;

public static class HumanTimeFormat
{
    private static readonly int Second = 1;
    private static readonly int Minute = Second * 60;
    private static readonly int Hour = Minute * 60;
    private static readonly int Day = Hour * 24;
    private static readonly int Year = Day * 365;

    private static readonly int[] Units = { Year, Day, Hour, Minute, Second };
    private static readonly string[] Labels = { "year", "day", "hour", "minute", "second" };

    public static string FormatDuration(int seconds)
    {
        if (seconds == 0)
            return "now";

        var components = new List<string>();

        var sb = new StringBuilder();
        for (int i = 0; i < Units.Length; i++)
        {
            var unitValue = seconds / Units[i];
            if (unitValue != 0)
            {
                seconds -= unitValue * Units[i];
                sb.Clear();
                components.Add(
                    sb.Append(unitValue)
                        .Append(' ')
                        .Append(Labels[i])
                        .Append(unitValue > 1 ? "s" : string.Empty).ToString());
            }
        }

        return string.Join(", ", components.SkipLast(1)) + (components.Count > 1 ? " and " : string.Empty) +
               components.Last();
    }
}

[TestFixture]
public class Tests
{
    private static IEnumerable<TestCaseData> TestCaseData
    {
        get
        {
            yield return new TestCaseData(0).Returns("now");
            yield return new TestCaseData(1).Returns("1 second");
            yield return new TestCaseData(62).Returns("1 minute and 2 seconds");
            yield return new TestCaseData(120).Returns("2 minutes");
            yield return new TestCaseData(3662).Returns("1 hour, 1 minute and 2 seconds");
            yield return new TestCaseData(15731080).Returns("182 days, 1 hour, 44 minutes and 40 seconds");
            yield return new TestCaseData(132030240).Returns("4 years, 68 days, 3 hours and 4 minutes");
            yield return new TestCaseData(205851834).Returns("6 years, 192 days, 13 hours, 3 minutes and 54 seconds");
            yield return new TestCaseData(253374061).Returns("8 years, 12 days, 13 hours, 41 minutes and 1 second");
            yield return new TestCaseData(242062374).Returns("7 years, 246 days, 15 hours, 32 minutes and 54 seconds");
            yield return new TestCaseData(101956166).Returns("3 years, 85 days, 1 hour, 9 minutes and 26 seconds");
            yield return new TestCaseData(33243586).Returns("1 year, 19 days, 18 hours, 19 minutes and 46 seconds");
        }
    }

    [Test, TestCaseSource("TestCaseData")]
    public string FormatDurationTests(int input) => HumanTimeFormat.FormatDuration(input);
}