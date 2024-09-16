using NUnit.Framework;

namespace DefaultNamespace;

/// <summary>
/// Implement the function unique_in_order which takes as argument a sequence and returns a list of items without any elements
/// with the same value next to each other and preserving the original order of elements.
/// </summary>
public static class UniqueInOrder
{
    public static IEnumerable<T> Get<T>(IEnumerable<T> items)
    {
        T current = default;
        foreach (var item in items)
        {
            if (!item.Equals(current))
            {
                current = item;
                yield return current;
            }
        }
            
    }
}

[TestFixture]
public class UniqueInOrderTests
{
    [TestCase(new int[] { 1, 1, 2, 2, 3, 3, 3, 2, 2 }, ExpectedResult = new int[] { 1, 2, 3, 2 })]
    public IEnumerable<T>
        Get_ForAnyEnumerable_ShouldReturnEnumerableWithoutSiblingDuplicates<T>(IEnumerable<T> items) =>
        UniqueInOrder.Get(items);
}