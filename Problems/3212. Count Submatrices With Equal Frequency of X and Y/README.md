# 3212. Count Submatrices With Equal Frequency of X and Y

Given a 2D character matrix `grid`, where `grid[i][j]` is either `'X'`, `'Y'`, or `'.'`, return the number of submatrices that contain:

*   `grid[0][0]`
*   an **equal** frequency of `'X'` and `'Y'`.
*   **at least** one `'X'`.

<br/>

# **Example 1:**

**Input:** grid = \[\["X","Y","."\],\["Y",".","."\]\]

**Output:** 3

**Explanation:**

**![](ex1.png)**

# **Example 2:**

**Input:** grid = \[\["X","X"\],\["X","Y"\]\]

**Output:** 0

**Explanation:**

No submatrix has an equal frequency of `'X'` and `'Y'`.

# **Example 3:**

**Input:** grid = \[\[".","."\],\[".","."\]\]

**Output:** 0

**Explanation:**

No submatrix has at least one `'X'`.

<br/>

**Constraints:**

*   `1 <= grid.length, grid[i].length <= 1000`
*   `grid[i][j]` is either `'X'`, `'Y'`, or `'.'`.


<br/>

<details><summary>Hint 1</summary>
<p>
Replace <code>’X’</code> with 1, <code>’Y’</code> with -1 and <code>’.’</code> with 0.
</p>
</details>
<details><summary>Hint 2</summary>
<p>
You need to find how many submatrices <code>grid[0..x][0..y]</code> have a sum of 0 and at least one <code>’X’</code>.
</p>
</details>

<details><summary>Hint 3</summary>Use prefix sum to calculate submatrices sum.</details>