# 3546. Equal Sum Grid Partition I

You are given an `m x n` matrix `grid` of positive integers. Your task is to determine if it is possible to make **either one horizontal or one vertical cut** on the grid such that:

*   Each of the two resulting sections formed by the cut is **non-empty**.
*   The sum of the elements in both sections is **equal**.

Return `true` if such a partition exists; otherwise return `false`.

<br/>

# **Example 1:**

**Input:** grid = \[\[1,4\],\[2,3\]\]

**Output:** true

**Explanation:**

![](ex1.jpg)

A horizontal cut between row 0 and row 1 results in two non-empty sections, each with a sum of 5. Thus, the answer is `true`.

# **Example 2:**

**Input:** grid = \[\[1,3\],\[2,4\]\]

**Output:** false

**Explanation:**

No horizontal or vertical cut results in two non-empty sections with equal sums. Thus, the answer is `false`.

<br/>

# **Constraints:**

*   <code>1 &lt;= m == grid.length &lt;= 10<sup>5</sup></code>
*   <code>1 &lt;= n == grid[i].length &lt;= 10<sup>5</sup></code>
*   <code>2 &lt;= m * n &lt;= 10<sup>5</sup></code>
*   <code>1 &lt;= grid[i][j] &lt;= 10<sup>5</sup></code> 

<br/>

<details>
<summary>Hint 1</summary>
There are two types of cuts: a <code>horizontal</code> cut or a <code>vertical</code> cut.
</details>

<details>
<summary>Hint 2</summary>
For a <code>horizontal</code> cut at row <code>r</code> (0 <= r grid into rows 0...r vs. r+1...m-1 and compare their sums.
</details>

<details>
<summary>Hint 3</summary>
For a <code>vertical</code> cut at column <code>c</code> (0 <= c < n - 1), split <code>grid</code> into columns 0...c vs. c+1...n-1 and compare their sums.
</details>

<details>
<summary>Hint 4</summary>
Brute‑force all possible <code>r</code> and <code>c</code> cuts; if any yields equal section sums, return <code>true</code>.
</details>