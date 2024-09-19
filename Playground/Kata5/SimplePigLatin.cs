using System.Text;
using NUnit.Framework;

namespace Playground.Kata5;

public static class SimplePigLatin
{
    public static string PigIt(string input) => input
        .Split(' ')
        .Aggregate(new StringBuilder(), (sb, word) =>
        {
            if (sb.Length > 0) sb.Append(' ');
            return word.Length > 1 ? sb.Append(word[1..]).Append(word[0]).Append("ay") : sb.Append(word);
        }).ToString();

    public static string PigItV2(string input) => string.Join(' ', input.Split()
        .Select(word => word.Any(char.IsPunctuation) ? word : $"{word[1..]}{word[0]}ay"));
}

[TestFixture]
public class SimplePigLatinTests
{
    [TestCase("Pig latin is cool", ExpectedResult = "igPay atinlay siay oolcay")]
    [TestCase("Hello world !", ExpectedResult = "elloHay orldway !")]
    public string PigIt_ForValidStringInput_ShouldReturnValueInPigLatinLang(string input) =>
        SimplePigLatin.PigIt(input);
}