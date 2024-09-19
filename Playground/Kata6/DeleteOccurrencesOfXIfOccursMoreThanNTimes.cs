using NUnit.Framework;

namespace DefaultNamespace;

public static class DeleteOccurrencesOfXIfOccursMoreThanNTimes
{
    public static int[] Filter(int[] source, int n) => source
        .Aggregate(new { Output = new List<int>(), Counter = new Dictionary<int, int>() }, (state, currentInt) =>
        {
            var numberOfOccurrences = state.Counter.GetValueOrDefault(currentInt);
            if (numberOfOccurrences < n)
            {
                state.Output.Add(currentInt);
                state.Counter[currentInt] = numberOfOccurrences + 1;
            }

            return state;
        }).Output.ToArray();
}

[TestFixture]
public class DeleteOccurrencesOfXIfOccursMoreThanNTimesTests
{
    [TestCase(new int[] { 20, 37, 20, 21 }, 1, ExpectedResult = new int[] { 20, 37, 21 })]
    [TestCase(new int[] { 1, 1, 3, 3, 7, 2, 2, 2, 2 }, 3, ExpectedResult = new int[] { 1, 1, 3, 3, 7, 2, 2, 2 })]
    public int[]
        DeleteOccurrencesOfXIfOccursMoreThanNTimesTests_ForIntArray_ShouldReturnArrayNotContainingItemsOccurringMoreThanNTimes(
            int[] ints, int n) => DeleteOccurrencesOfXIfOccursMoreThanNTimes.Filter(ints, n);
}