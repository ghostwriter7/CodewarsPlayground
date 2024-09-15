using System.Text;
using NUnit.Framework;

namespace DefaultNamespace;

/// <summary>
/// Write a function that accepts an array of 10 integers (between 0 and 9),
/// that returns a string of those numbers in the form of a phone number.
/// "(123) 456-7890"
/// </summary>
public static class CreatePhoneNumber
{
    public static string Create(int[] digits) => long.Parse(string.Concat(digits)).ToString("(000) 000-0000");
}

[TestFixture]
public class CreatePhoneNumberTests
{
    [TestCase(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }, ExpectedResult = "(111) 111-1111")]
    [TestCase(new int[] { 0, 0, 7, 6, 6, 6, 1, 2, 3, 4 }, ExpectedResult = "(007) 666-1234")]
    public string Create_For10Integers_ShouldReturnPhoneNumber(int[] digits) => CreatePhoneNumber.Create(digits);
}