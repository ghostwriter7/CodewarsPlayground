using NUnit.Framework;

namespace DefaultNamespace;

public static class VowelCount
{
    private static char[] vowels = ['a', 'e', 'i', 'o', 'u'];
    public static int GetVowelCount(string str) => str.Count(vowels.Contains);
}

[TestFixture]
public class VowelCountTest
{
    [TestCase("hello", ExpectedResult = 2)]
    [TestCase("world", ExpectedResult = 1)]
    [TestCase("this is some funky sentence", ExpectedResult = 8)]
    public int GetVowelCount_ForSentence_ShouldReturnCountOfVowels(string sentence) =>
        VowelCount.GetVowelCount(sentence);

}