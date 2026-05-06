# 1861. Rotating the Box

You are given an `m x n` matrix of characters `boxGrid` representing a side-view of a box. Each cell of the box is one of the following:

*   A stone `'#'`
*   A stationary obstacle `'*'`
*   Empty `'.'`

The box is rotated **90 degrees clockwise**, causing some of the stones to fall due to gravity. Each stone falls down until it lands on an obstacle, another stone, or the bottom of the box. Gravity **does not** affect the obstacles' positions, and the inertia from the box's rotation **does not** affect the stones' horizontal positions.

It is **guaranteed** that each stone in `boxGrid` rests on an obstacle, another stone, or the bottom of the box.

Return _an_ `n x m` _matrix representing the box after the rotation described above_.

<br/>

# **Example 1:**

![](ex1.png)

**Input:** boxGrid = \[\["#",".","#"\]\]

**Output:** \[\["."\],
         \["#"\],
         \["#"\]\]

# **Example 2:**

![](ex2.png)

**Input:** boxGrid = \[\["#",".","\*","."\],
              \["#","#","\*","."\]\]

**Output:** \[\["#","."\],
         \["#","#"\],
         \["\*","\*"\],
         \[".","."\]\]

# **Example 3:**

![](ex3.png)

**Input:** boxGrid = \[\["#","#","\*",".","\*","."\],
              \["#","#","#","\*",".","."\],
              \["#","#","#",".","#","."\]\]

**Output:** \[\[".","#","#"\],
         \[".","#","#"\],
         \["#","#","\*"\],
         \["#","\*","."\],
         \["#",".","\*"\],
         \["#",".","."\]\]

<br/>

# **Constraints:**

*   `m == boxGrid.length`
*   `n == boxGrid[i].length`
*   `1 <= m, n <= 500`
*   `boxGrid[i][j]` is either `'#'`, `'*'`, or `'.'`.

<br/>

<details><summary>Hint 1</summary>Rotate the box using the relation rotatedBox[i][j] = box[m - 1 - j][i].</details>
<details><summary>Hint 2</summary>Start iterating from the bottom of the box and for each empty cell check if there is any stone above it with no obstacles between them.</details>