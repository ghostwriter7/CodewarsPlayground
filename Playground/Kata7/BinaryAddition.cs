using System.Text;
using NUnit.Framework;

namespace DefaultNamespace;

public static class BinaryAddition
{
    public static string AddBinary(int a, int b) => Convert.ToString(a + b, 2);

    public static string AddBinaryLowLevel(int a, int b)
    {
        var result = a + b;
        var binaryDigits = new Stack<string>();
        do
        {
            binaryDigits.Push((result % 2).ToString());
            result /= 2;
        } while (result != 0);

        return string.Join("", binaryDigits);
    }
}

[TestFixture]
public class BinaryAdditionTests
{
    [TestCase(1, 1, ExpectedResult = "10")]
    [TestCase(5, 9, ExpectedResult = "1110")]
    public string AddBinary_ForTwoIntegerInputs_ShouldReturnItsSumAsBinary(int a, int b) =>
        BinaryAddition.AddBinary(a, b);

    [TestCase(1, 1, ExpectedResult = "10")]
    [TestCase(5, 9, ExpectedResult = "1110")]
    [TestCase(-1, 1, ExpectedResult = "0")]
    public string AddBinaryLowLevel_ForTwoIntegerInputs_ShouldReturnItsSumAsBinary(int a, int b) =>
        BinaryAddition.AddBinaryLowLevel(a, b);
}