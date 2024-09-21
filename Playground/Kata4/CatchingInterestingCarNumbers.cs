using NUnit.Framework;

namespace Playground.Kata4;

public static class CatchingInterestingCarNumbers
{
    public static int IsInteresting(int number, List<int> awesomePhrases)
    {
        return -1;
    }
}

[TestFixture]
public class CatchingInterestingCarNumbersTests
{
    [Test]
    public void ShouldWorkTest()
    {
        Assert.That(0, Is.EqualTo(CatchingInterestingCarNumbers.IsInteresting(3, new List<int>() { 1337, 256 })));
        Assert.That(1, Is.EqualTo(CatchingInterestingCarNumbers.IsInteresting(1336, new List<int>() { 1337, 256 })));
        Assert.That(2, Is.EqualTo(CatchingInterestingCarNumbers.IsInteresting(1337, new List<int>() { 1337, 256 })));
        Assert.That(0, Is.EqualTo(CatchingInterestingCarNumbers.IsInteresting(11208, new List<int>() { 1337, 256 })));
        Assert.That(1, Is.EqualTo(CatchingInterestingCarNumbers.IsInteresting(11209, new List<int>() { 1337, 256 })));
        Assert.That(2, Is.EqualTo(CatchingInterestingCarNumbers.IsInteresting(11211, new List<int>() { 1337, 256 })));
    }
}