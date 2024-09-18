using System.Text;
using NUnit.Framework;

namespace DefaultNamespace;

public static class BreakCamelCase
{
    public static string Convert(string input) => input.Aggregate(new StringBuilder(), (sb, character) =>
    {
        if (char.IsUpper(character))
            sb.Append(' ');
        sb.Append(character);
        return sb;
    }).ToString();
}

[TestFixture]
public class BreakCamelCaseTests
{
    [TestCase("camelCasing", ExpectedResult = "camel Casing")]
    [TestCase("identifier", ExpectedResult = "identifier")]
    [TestCase("", ExpectedResult = "")]
    public string Convert_ForStringInput_ShouldReturnStringWithSpaces(string input) => BreakCamelCase.Convert(input);
}