using NUnit.Framework;

namespace DefaultNamespace;

/// <summary>
/// Write a function, persistence, that takes in a positive parameter num and returns its multiplicative persistence,
/// which is the number of times you must multiply the digits in num until you reach a single digit.
/// </summary>
public static class PersistentBugger
{
    public static int Persist(long n)
    {
        var counter = 0;
        var currentNumber = n;

        int Reduce(long input) =>
            input.ToString()
                .Aggregate(1, (total, currentDigit) => total * int.Parse(currentDigit.ToString()));

        while (currentNumber > 9)
        {
            currentNumber = Reduce(currentNumber);
            counter++;
        }

        return counter;
    }
}

[TestFixture]
public class PersistentBuggerTests
{
    [TestCase(39, ExpectedResult = 3)]
    [TestCase(999, ExpectedResult = 4)]
    [TestCase(4, ExpectedResult = 0)]
    public int
        Persist_ForAValidNumber_ShouldReturnNumberOfMultiplicationsRequiredToReduceItToSingleDigit(long number) =>
        PersistentBugger.Persist(number);
}