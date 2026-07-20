# 1260. Shift 2D Grid

Given a 2D `grid` of size `m x n` and an integer `k`. You need to shift the `grid` `k` times.

In one shift operation:

*   Element at `grid[i][j]` moves to `grid[i][j + 1]`.
*   Element at `grid[i][n - 1]` moves to `grid[i + 1][0]`.
*   Element at `grid[m - 1][n - 1]` moves to `grid[0][0]`.

Return the *2D grid* after applying shift operation `k` times.

<br/>

# **Example 1:**

!\[\](https://assets.leetcode.com/uploads/2019/11/05/e1.png)
**Input:** grid = \[\[1,2,3\],\[4,5,6\],\[7,8,9\]\], k = 1

**Output:** \[\[9,1,2\],\[3,4,5\],\[6,7,8\]\]

<br/>

# **Example 2:**

!\[\](https://assets.leetcode.com/uploads/2019/11/05/e2.png)
**Input:** grid = \[\[3,8,1,9\],\[19,7,2,5\],\[4,6,11,10\],\[12,0,21,13\]\], k = 4

**Output:** \[\[12,0,21,13\],\[3,8,1,9\],\[19,7,2,5\],\[4,6,11,10\]\]

<br/>

# **Example 3:**

**Input:** grid = \[\[1,2,3\],\[4,5,6\],\[7,8,9\]\], k = 9

**Output:** \[\[1,2,3\],\[4,5,6\],\[7,8,9\]\]

<br/>

# **Constraints:**

*   `m == grid.length`
*   `n == grid[i].length`
*   <code>1 &lt;= m &lt;= 50</code>
*   <code>1 &lt;= n &lt;= 50</code>
*   <code>-1000 &lt;= grid[i][j] &lt;= 1000</code>
*   <code>0 &lt;= k &lt;= 100</code>

<br/>

<details><summary>Hint 1</summary>Simulate step by step. move grid\[i\]\[j\] to grid\[i\]\[j+1\]. handle last column of the grid.</details>
<details><summary>Hint 2</summary>Put the matrix row by row to a vector. take k % vector.length and move last k of the vector to the beginning. put the vector to the matrix back the same way.</details>
