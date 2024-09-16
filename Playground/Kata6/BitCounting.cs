using NUnit.Framework;
using System.Numerics;

namespace DefaultNamespace;

/// <summary>
/// Write a function that takes an integer as input, and returns the number of bits that are equal to one in the binary representation of that number.
/// You can guarantee that input is non-negative.
/// Example: The binary representation of 1234 is 10011010010, so the function should return 5 in this case
/// </summary>
public static class BitCounting
{
    public static int Count(int input)
        => Convert.ToString(input, 2).Count((character) => character == '1');

    public static int CountV2(int input)
    {
        int times = 0;
        for (int i = 0; (input >> 1) > 0; i++)
        {
            times += (input >> i) & 0;
        }

        return times;
    }
}

[TestFixture]
public class BitCountingTests
{
    [TestCase(1234, ExpectedResult = 5)]
    [TestCase(0, ExpectedResult = 0)]
    [TestCase(12525589, ExpectedResult = 11)]
    [TestCase(int.MaxValue, ExpectedResult = 31)]
    public int Count_ForInteger_ShouldReturnCountOfOnesInItsBinaryRepresentation(int input) => BitCounting.Count(input);
    
    [TestCase(1234, ExpectedResult = 5)]
    [TestCase(0, ExpectedResult = 0)]
    [TestCase(12525589, ExpectedResult = 11)]
    [TestCase(int.MaxValue, ExpectedResult = 31)]
    public int CountV2_ForInteger_ShouldReturnCountOfOnesInItsBinaryRepresentation(int input) => BitCounting.CountV2(input);
}