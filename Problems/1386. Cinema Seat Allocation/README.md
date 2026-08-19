# 1386. Cinema Seat Allocation

![](cinema_seats_1.png)

A cinema has `n` rows of seats, numbered from 1 to `n`. Each row has 10 seats, numbered from 1 to 10.

You are given a 2D integer array `reservedSeats`, where <code>reservedSeats[i] = [row<sub>i</sub>, seat<sub>i</sub>]</code> means that seat <code>seat<sub>i</sub></code> in row <code>row<sub>i</sub></code> is already reserved.

A four-person group must be assigned to four seats in the **same** row. The group can be seated in one of the following seat blocks:

*   seats `2, 3, 4, 5`
*   seats `4, 5, 6, 7`
*   seats `6, 7, 8, 9`

A block can be used only if **none** of its seats are reserved. Each seat can be assigned to **at most **one group.

Return an integer denoting the **maximum** number of four-person groups that can be assigned.

<br/>

# **Example 1:**

![](cinema_seats_3.png)

**Input:** n = 3, reservedSeats = \[\[1,2\],\[1,3\],\[1,8\],\[2,6\],\[3,1\],\[3,10\]\]

**Output:** 4

**Explanation:** The figure above shows an optimal allocation of four groups. Seats marked in blue are already reserved, and each set of four contiguous seats marked in orange is assigned to one group.

<br/>

# **Example 2:**

**Input:** n = 2, reservedSeats = \[\[2,1\],\[1,8\],\[2,6\]\]

**Output:** 2

<br/>

# **Example 3:**

**Input:** n = 4, reservedSeats = \[\[4,3\],\[1,4\],\[4,6\],\[1,7\]\]

**Output:** 4

<br/>

# **Constraints:**

*   <code>1 &lt;= n &lt;= 10<sup>9</sup></code>
*   <code>1 &lt;= reservedSeats.length &lt;= min(10 * n, 10<sup>4</sup>)</code>
*   <code>reservedSeats[i] == [row<sub>i</sub>, seat<sub>i</sub>]</code>
*   <code>1 &lt;= row<sub>i</sub> &lt;= n</code>
*   <code>1 &lt;= seat<sub>i</sub> &lt;= 10</code>
*   All `reservedSeats[i]` are distinct.

<br/>

<details><summary>Hint 1</summary>Note you can allocate at most two four-person groups in one row.</details>
<details><summary>Hint 2</summary>Greedily check if you can allocate seats for two groups, one group or none.</details>
<details><summary>Hint 3</summary>Process only rows that appear in the input, for other rows you can always allocate seats for two groups.</details>
