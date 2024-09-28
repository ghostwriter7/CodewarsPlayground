using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Playground.Kata7;

public static class SpiralingBox
{
    public static int[,] CreateBox(int width, int height)
    {
        var box = new int[height, width];
        var current = 1;
        int top = 0, bottom = height - 1;
        int left = 0, right = width - 1;

        while (true)
        {
            if (left <= right)
                for (var i = left; i <= right; i++)
                    box[top, i] = box[bottom, i] = current;
            
            if (top <= bottom)
                for (var i = top; i <= bottom; i++)
                    box[i, left] = box[i, right] = current;

            top++; left++; right--; bottom--;

            if (left > right || top > bottom)
                break;
            
            current++;
        }
        
        return box;
    }
}

[TestFixture]
public class SpiralingBoxTests
{
    [Test]
    public void CreateBoxTest()
    {
        int[,] box_7_8 =
        {
            { 1, 1, 1, 1, 1, 1, 1 },
            { 1, 2, 2, 2, 2, 2, 1 },
            { 1, 2, 3, 3, 3, 2, 1 },
            { 1, 2, 3, 4, 3, 2, 1 },
            { 1, 2, 3, 4, 3, 2, 1 },
            { 1, 2, 3, 3, 3, 2, 1 },
            { 1, 2, 2, 2, 2, 2, 1 },
            { 1, 1, 1, 1, 1, 1, 1 }
        };

        int[,] box_8_7 =
        {
            { 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 2, 2, 2, 2, 2, 2, 1 },
            { 1, 2, 3, 3, 3, 3, 2, 1 },
            { 1, 2, 3, 4, 4, 3, 2, 1 },
            { 1, 2, 3, 3, 3, 3, 2, 1 },
            { 1, 2, 2, 2, 2, 2, 2, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1 }
        };

        int[,] box_4_2 = { { 1, 1, 1, 1 }, { 1, 1, 1, 1 } };

        int[,] box_2_4 = { { 1, 1 }, { 1, 1 }, { 1, 1 }, { 1, 1 } };

        CollectionAssert.AreEqual(box_7_8, SpiralingBox.CreateBox(7, 8));

        CollectionAssert.AreEqual(box_8_7, SpiralingBox.CreateBox(8, 7));

        CollectionAssert.AreEqual(box_4_2, SpiralingBox.CreateBox(4, 2));

        CollectionAssert.AreEqual(box_2_4, SpiralingBox.CreateBox(2, 4));
    }
}