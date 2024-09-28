using System.Text;
using NUnit.Framework;

namespace Playground.Kata6;

public class IndexedCapitalization
{
    public static string Capitalize(string s, List<int> idxs) => s
        .Select((character, index) => (character, index))
        .Aggregate(new StringBuilder(s.Length), (sb, tuple) =>
        {
            sb.Append(idxs.Contains(tuple.index) ? char.ToUpper(tuple.character) : tuple.character);
            return sb;
        }).ToString();

    public static string CapitalizeV2(string s, List<int> idxs) => string.Concat(
        s.Select((c, i) => idxs.Contains(i) ? char.ToUpper(c) : c)
    );
}

[TestFixture]
public class IndexedCapitalizationTests
{
    private static IEnumerable<TestCaseData> TestCases
    {
        get
        {
            yield return new TestCaseData("abcdef", new List<int> { 1, 2, 5 }).Returns("aBCdeF");
            yield return new TestCaseData("abcdef", new List<int> { 1, 2, 5, 100 }).Returns("aBCdeF");
            yield return new TestCaseData("abcdef", new List<int> { 1, 100, 2, 5 }).Returns("aBCdeF");
            yield return new TestCaseData("codewars", new List<int> { 1, 3, 5, 50 }).Returns("cOdEwArs");
            yield return new TestCaseData("abracadabra", new List<int> { 2, 6, 9, 10 }).Returns("abRacaDabRA");
            yield return new TestCaseData("codewarriors", new List<int> { 5 }).Returns("codewArriors");
            yield return new TestCaseData("indexinglessons", new List<int> { 0 }).Returns("Indexinglessons");
        }
    }

    [Test, TestCaseSource("TestCases")]
    public string Test(string s, List<int> idxs) => IndexedCapitalization.Capitalize(s, idxs);
}