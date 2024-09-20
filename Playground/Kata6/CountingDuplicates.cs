using NUnit.Framework;

namespace DefaultNamespace;

/// <summary>
/// Write a function that will return the count of distinct case-insensitive
/// alphabetic characters and numeric digits that occur more than once in the input string.
/// The input string can be assumed to contain only alphabets (both uppercase and lowercase) and numeric digits.
/// </summary>
public static class CountingDuplicates
{
    public static int Count(string str) => str.ToLower()
        .Aggregate(new Dictionary<char, int>(), (dict, character) =>
        {
            if (!dict.TryAdd(character, 1))
                dict[character]++;

            return dict;
        })
        .Count((entry) => entry.Value > 1);

    public static int CountV2(string str) => str.ToLower()
        .GroupBy((c) => c)
        .Count((group) => group.Count() > 1);
}

[TestFixture]
public class CountingDuplicatesTests
{
    [TestCase("abcde", ExpectedResult = 0)]
    [TestCase("aabbcde", ExpectedResult = 2)]
    [TestCase("aabBcde", ExpectedResult = 2)]
    [TestCase("indivisibility", ExpectedResult = 1)]
    [TestCase("Indivisibilities", ExpectedResult = 2)]
    [TestCase("aA11", ExpectedResult = 2)]
    [TestCase("ABBA", ExpectedResult = 2)]
    public int Count_ForAnyStringInput_ShouldReturnNumberOfDistinctChars(string input) =>
        CountingDuplicates.Count(input);
}