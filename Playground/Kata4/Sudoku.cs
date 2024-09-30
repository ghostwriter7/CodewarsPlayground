﻿using NUnit.Framework;

namespace Playground.Kata4;

public class Sudoku(int[][] sudoku)
{
    private readonly int[][] _sudoku = sudoku;

    public bool IsValid()
    {
        return false;
    }
}

[TestFixture]
public class SudokuTests
{
    private static IEnumerable<TestCaseData> Sudokus
    {
        get
        {
            yield return new TestCaseData<int[][]>([
                [1, 2, 3, 4, 5, 6, 7, 8, 9],
                [1, 2, 3, 4, 5, 6, 7, 8, 9],
                [1, 2, 3, 4, 5, 6, 7, 8, 9],

                [1, 2, 3, 4, 5, 6, 7, 8, 9],
                [1, 2, 3, 4, 5, 6, 7, 8, 9],
                [1, 2, 3, 4, 5, 6, 7, 8, 9],

                [1, 2, 3, 4, 5, 6, 7, 8, 9],
                [1, 2, 3, 4, 5, 6, 7, 8, 9],
                [1, 2, 3, 4, 5, 6, 7, 8, 9]
            ]).Returns(false);
            yield return new TestCaseData<int[][]>([
                [1, 2, 3, 4, 5],
                [1, 2, 3, 4],
                [1, 2, 3, 4],
                [1]
            ]).Returns(false);
            yield return new TestCaseData<int[][]>([
                [7, 8, 4, 1, 5, 9, 3, 2, 6],
                [5, 3, 9, 6, 7, 2, 8, 4, 1],
                [6, 1, 2, 4, 3, 8, 7, 5, 9],

                [9, 2, 8, 7, 1, 5, 4, 6, 3],
                [3, 5, 7, 8, 4, 6, 1, 9, 2],
                [4, 6, 1, 9, 2, 3, 5, 8, 7],

                [8, 7, 6, 3, 9, 4, 2, 1, 5],
                [2, 4, 3, 5, 6, 1, 9, 7, 8],
                [1, 9, 5, 2, 8, 7, 6, 3, 4]
            ]).Returns(true);
            yield return new TestCaseData<int[][]>([
                [1, 4, 2, 3],
                [3, 2, 4, 1],
                [4, 1, 3, 2],
                [2, 3, 1, 4]
            ]).Returns(true);
        }
    }

    [Test, TestCaseSource("Sudokus")]
    public bool IsValidTests(int[][] sudoku) => new Sudoku(sudoku).IsValid();
}