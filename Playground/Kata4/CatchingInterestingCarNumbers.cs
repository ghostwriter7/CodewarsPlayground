using NUnit.Framework;

namespace Playground.Kata4;

public static class CatchingInterestingCarNumbers
{
    public static int IsInteresting(int number, List<int> awesomePhrases)
    {
        if (IsInterestingNumber(number, awesomePhrases))
            return 2;

        if (IsInterestingNumber(number + 1, awesomePhrases) || IsInterestingNumber(number + 2, awesomePhrases))
            return 1;

        return 0;
    }

    private static bool IsInterestingNumber(int number, List<int> awesomePhrases)
    {
        if (number < 100)
            return false;

        var digits = number.ToString();

        if (digits.Skip(1).All(digit => digit == '0'))
            return true;

        if (digits.All(digit => digit == digits[0]))
            return true;

        if (digits.SequenceEqual(digits.Reverse()))
            return true;
        
        var intDigits = digits
            .Select((digit, index) => (digit: int.Parse(digit.ToString()), index))
            .ToArray();

        if (IsIncrementalSequence() || IsDecrementalSequence())
            return true;

        if (awesomePhrases.Any(awesomePhrase => awesomePhrase == number))
            return true;

        return false;

        bool IsDecrementalSequence() => intDigits
            .Skip(1)
            .All(tuple => tuple.digit + 1 == intDigits.ElementAt(tuple.index - 1).digit);

        bool IsDecrementalSequenceV2() => "9876543210".Contains(digits);
        bool IsIncrementalSequenceV2() => "1234567890".Contains(digits);
        
        bool IsIncrementalSequence() =>
            intDigits.Skip(1)
                .All(tuple =>
                {
                    if (tuple.digit == 0)
                        return intDigits.ElementAt(tuple.index - 1).digit == 9;
                    return tuple.digit - 1 == intDigits.ElementAt(tuple.index - 1).digit;
                });
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
        Assert.That(2, Is.EqualTo(CatchingInterestingCarNumbers.IsInteresting(67890, new List<int>())));
    }
}