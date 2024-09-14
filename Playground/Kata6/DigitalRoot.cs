using NUnit.Framework;

namespace DefaultNamespace;

public static class DigitalRoot
{
    public static int Get(long n)
    {
        var value = n.ToString()
            .Sum(character => int.Parse(character.ToString()));

        if (value.ToString().Length > 1)
            return Get(value);
        return value;
    }
}

[TestFixture]
public class DigitalRootTests
{
    [TestCase(123456, ExpectedResult = 3)]
    [TestCase(999, ExpectedResult = 9)]
    [TestCase(10001, ExpectedResult = 2)]
    public int Get_ForLongNumber_ShouldReturnItsDigitalRoot(long value)
    {
        return DigitalRoot.Get(value);
    }
}