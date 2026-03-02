# 1536. Minimum Swaps to Arrange a Binary Grid

Given an `n x n` binary `grid`, in one step you can choose two **adjacent rows** of the grid and swap them.

A grid is said to be **valid** if all the cells above the main diagonal are **zeros**.

Return _the minimum number of steps_ needed to make the grid valid, or **\-1** if the grid cannot be valid.

The main diagonal of a grid is the diagonal that starts at cell `(1, 1)` and ends at cell `(n, n)`.

<br/>

# **Example 1:**

![](ex1.jpg)

**Input:** grid = \[\[0,0,1\],\[1,1,0\],\[1,0,0\]\]

**Output:** 3

# **Example 2:**

![](ex2.jpg)

**Input:** grid = \[\[0,1,1,0\],\[0,1,1,0\],\[0,1,1,0\],\[0,1,1,0\]\]

**Output:** -1

**Explanation:** All rows are similar, swaps have no effect on the grid.

# **Example 3:**

![](ex3.jpg)

**Input:** grid = \[\[1,0,0\],\[1,1,0\],\[1,1,1\]\]

**Output:** 0

<br/>

# **Constraints:**

*   `n == grid.length` `== grid[i].length`
*   `1 <= n <= 200`
*   `grid[i][j]` is either `0` or `1`

<br/>

<details>
<summary>Hint 1</summary>
<p>For each row of the grid calculate the most right 1 in the grid in the array maxRight.</p>
</details>

<details>
<summary>Hint 2</summary>
<p>To check if there exist answer, sort maxRight and check if maxRight[i] ≤ i for all possible i's.</p>
</details>

<details>
<summary>Hint 3</summary>
<p>If there exist an answer, simulate the swaps.</p>
</details>