using LeetCodeDaily.Core;
using System.Runtime.CompilerServices;

namespace _37.Sudoku_Solver;

public partial class Solution
{
    [ResultGenerator]
    public bool SolveSudoku(char[][] board)
    {
        Sudoku state = new(board);
        state.Solve();
        return true;
    }

    private class Sudoku
    {
        private int cell;
        private int col;
        private int row;
        private int block;

        private readonly char[][] board;
        private readonly bool[,] rowUsed;
        private readonly bool[,] colUsed;
        private readonly bool[,] blockUsed;
        private readonly bool[] notEmpty;

        public Sudoku(char[][] board)
        {
            this.board = board;
            rowUsed = new bool[9, 10];
            colUsed = new bool[9, 10];
            blockUsed = new bool[9, 10];
            notEmpty = new bool[81];
            Init();
        }

        private void Init()
        {
            SetCell(0);

            // mark the preset fields as 'not empty'
            // and prefill the state
            while (cell < 81)
            {
                if (board[row][col] != '.')
                {
                    notEmpty[cell] = true;
                    Set(board[row][col] - '0');
                }

                IncrementCell();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void IncrementCell()
        {
            SetCell(cell + 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void DecrementCell()
        {
            SetCell(cell - 1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void SetCell(int cell)
        {
            this.cell = cell;
            row = cell / 9;
            col = cell % 9;
            block = (row / 3) * 3 + (col / 3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool Check(int val)
        {
            return !rowUsed[row, val]
                && !colUsed[col, val]
                && !blockUsed[block, val];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Set(int val)
        {
            rowUsed[row, val] = true;
            colUsed[col, val] = true;
            blockUsed[block, val] = true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void Reset(int val)
        {
            rowUsed[row, val] = false;
            colUsed[col, val] = false;
            blockUsed[block, val] = false;
        }

        public void Solve()
        {
            SetCell(0);

            while (cell < 81)
            {
                if (notEmpty[cell])
                {
                    IncrementCell();
                    continue;
                }

                int candidate = 1;

                while (candidate < 10 && !Check(candidate)) { candidate++; }

                if (candidate < 10)
                {
                    board[row][col] = (char)(candidate + '0');
                    Set(candidate);
                    IncrementCell();
                    continue;
                }

                // no valid option left -> backtrack
                BackTrack();
            }
        }

        private void BackTrack()
        {
            while (cell > 0)
            {
                DecrementCell();

                if (notEmpty[cell])
                {
                    continue;
                }

                int candidate = board[row][col] - '0';

                Reset(candidate);

                candidate++;

                while (candidate < 10 && !Check(candidate)) { candidate++; }

                if (candidate < 10)
                {
                    board[row][col] = (char)(candidate + '0');
                    Set(candidate);
                    IncrementCell();
                    break;
                }
            }
        }
    }
}

// Fastest C# submittion using bitmasks and MRV heuristic
public partial class Solution
{
    private static readonly int[] POPCOUNT = BuildPopcount();      // [0..511]
    private static readonly int[] BIT_TO_DIGIT = BuildBitToDigit(); // maps (1<<k) -> k

    private const int FULL = 0x1FF; // 9 bits set (digits 1..9)

    [ResultGenerator(ApproachIndex = 1)]
    public bool SolveSudokuFast(char[][] board)
    {
        int[] rows = new int[9];
        int[] cols = new int[9];
        int[] boxes = new int[9];
        List<int> empties = new List<int>(81);

        // Build masks and collect empty cells
        for (int r = 0; r < 9; r++)
        {
            for (int c = 0; c < 9; c++)
            {
                char ch = board[r][c];
                if (ch == '.')
                {
                    empties.Add(r * 9 + c);
                    continue;
                }

                int bit = 1 << (ch - '1');
                int b = (r / 3) * 3 + (c / 3);

                rows[r] |= bit;
                cols[c] |= bit;
                boxes[b] |= bit;
            }
        }

        // Backtracking with MRV (choose cell with fewest candidates each step)
        Solve(0, board, empties, rows, cols, boxes);

        return true;
    }

    private static bool Solve(int k, char[][] board, List<int> empties,
                              int[] rows, int[] cols, int[] boxes)
    {
        if (k == empties.Count) return true; // solved

        // Pick the next position using MRV (minimum remaining values)
        int bestIdx = -1, bestMask = 0, bestCount = 10;

        for (int i = k; i < empties.Count; i++)
        {
            int pos = empties[i];
            int r = pos / 9, c = pos % 9, b = (r / 3) * 3 + (c / 3);

            // Candidates = digits not used in row/col/box
            int used = rows[r] | cols[c] | boxes[b];
            int cand = (~used) & FULL; // keep only 9 bits

            int cnt = POPCOUNT[cand];
            if (cnt == 0) return false;        // dead end early
            if (cnt < bestCount)               // better MRV choice
            {
                bestCount = cnt;
                bestMask = cand;
                bestIdx = i;
                if (cnt == 1) break;           // can't do better
            }
        }

        // Swap the chosen empty cell into position k
        (empties[k], empties[bestIdx]) = (empties[bestIdx], empties[k]);

        int posK = empties[k];
        int rK = posK / 9, cK = posK % 9, bK = (rK / 3) * 3 + (cK / 3);
        int candMask = bestMask;

        // Try candidates, one bit at a time (iterate low-set-bit trick)
        while (candMask != 0)
        {
            int bit = candMask & -candMask;           // isolate LSB
            int d = BIT_TO_DIGIT[bit];                // 0..8
            char ch = (char)('1' + d);

            // place
            board[rK][cK] = ch;
            rows[rK] |= bit;
            cols[cK] |= bit;
            boxes[bK] |= bit;

            if (Solve(k + 1, board, empties, rows, cols, boxes))
                return true;

            // undo
            board[rK][cK] = '.';
            rows[rK] &= ~bit;
            cols[cK] &= ~bit;
            boxes[bK] &= ~bit;

            candMask ^= bit; // remove tried bit
        }

        // backtrack: restore order (optional for correctness, not needed)
        // (empties[k], empties[bestIdx]) = (empties[bestIdx], empties[k]);
        return false;
    }


    private static int[] BuildPopcount()
    {
        var pc = new int[512];
        for (int m = 0; m < 512; m++)
        {
            int x = m, cnt = 0;
            while (x != 0) { x &= (x - 1); cnt++; }
            pc[m] = cnt;
        }
        return pc;
    }

    private static int[] BuildBitToDigit()
    {
        var map = new int[512];
        for (int k = 0; k < 9; k++) map[1 << k] = k;
        return map;
    }
}