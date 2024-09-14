using NUnit.Framework;

namespace DefaultNamespace;

public static class BinaryAddition
{
    public static string AddBinary(int a, int b) => (a + b).ToString("B");
}

[TestFixture]
public class BinaryAdditionTests
{
    [TestCase(1, 1, ExpectedResult = "10")]
    [TestCase(5, 9, ExpectedResult = "1110")]
    public string AddBinary_ForTwoIntegerInputs_ShouldReturnItsSumAsBinary(int a, int b) =>
        BinaryAddition.AddBinary(a, b);
}