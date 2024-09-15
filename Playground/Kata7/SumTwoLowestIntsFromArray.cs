using NUnit.Framework;

namespace DefaultNamespace;

/// <summary>
/// Create a function that returns the sum of the two lowest positive numbers given an array of minimum 4 positive integers.
/// No floats or non-positive integers will be passed.
/// </summary>
public static class SumTwoLowestIntsFromArray
{
    public static int Sum(int[] ints) => ints.Order().Take(2).Sum();
}

[TestFixture]
public class SumTwoLowestIntsFromArrayTests
{
    [TestCase(new int[] {1, 2, 3, 4, 5}, ExpectedResult = 3)]
    [TestCase(new int[] {9, 81, -5, -14, 32}, ExpectedResult = -19)]
    [TestCase(new int[] {0, 0, 1, 1, -1, 2}, ExpectedResult = -1)]
    [TestCase(new int[] {10, 20, 5}, ExpectedResult = 15)]
    public int SumTwoLowestIntsFromArray_WhenProvidedArrayOfInts_ShouldSumTwoLowestInts(int[] values) =>
        SumTwoLowestIntsFromArray.Sum(values);
}