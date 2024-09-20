using NUnit.Framework;

namespace DefaultNamespace;

/// <summary>
/// You are given an array(list) strarr of strings and an integer k.
/// Your task is to return the first longest string consisting of k consecutive strings taken in the array.
/// </summary>
public static class LongestConsecutives
{
    public static string GetLongest(string[] strings, int k)
    {
        var numberOfWords = strings.Length;
        var numberOfPossibleCombinations = numberOfWords - (k - 1);
        var combinations = new List<string>();
        for (var i = 0; i < numberOfPossibleCombinations; i++)
            combinations.Add(string.Join("", strings[i..(i + k)]));
        return combinations.MaxBy(combo => combo.Length) ?? string.Empty;
    }
    
}

[TestFixture]
public class LongestConsecutivesTests
{
    [TestCase(new string[] { "zone", "abigail", "theta", "form", "libe", "zas", "theta", "abigail" }, 2,
        ExpectedResult = "abigailtheta")]
    [TestCase(new string[] { "zone", "abigail", "theta", "form", "libe", "zas", "theta", "abigail" }, 2,
        ExpectedResult = "abigailtheta")]
    [TestCase(new String[] { "zone", "abigail", "theta", "form", "libe", "zas", "theta", "abigail" }, 2,
        ExpectedResult = "abigailtheta")]
    [TestCase(new String[] { "ejjjjmmtthh", "zxxuueeg", "aanlljrrrxx", "dqqqaaabbb", "oocccffuucccjjjkkkjyyyeehh" }, 1,
        ExpectedResult = "oocccffuucccjjjkkkjyyyeehh")]
    [TestCase(new String[] { }, 3, ExpectedResult = "")]
    [TestCase(new String[] { "itvayloxrp", "wkppqsztdkmvcuwvereiupccauycnjutlv", "vweqilsfytihvrzlaodfixoyxvyuyvgpck" },
        2, ExpectedResult = "wkppqsztdkmvcuwvereiupccauycnjutlvvweqilsfytihvrzlaodfixoyxvyuyvgpck")]
    [TestCase(new String[] { "wlwsasphmxx", "owiaxujylentrklctozmymu", "wpgozvxxiu" }, 2,
        ExpectedResult = "wlwsasphmxxowiaxujylentrklctozmymu")]
    public string
        GetLongest_ForAListOfStringsAndPostiveKFactor_ShouldReturnTheLongestPossibleStringToBeConstructedFromKConsecutiveStrings(
            string[] strings, int k)
        => LongestConsecutives.GetLongest(strings, k);
}