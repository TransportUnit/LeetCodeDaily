# 1437. Check If All 1's Are at Least Length K Places Away

Given an binary array `nums` and an integer `k`, return `true` _if all_ `1`_'s are at least_ `k` _places away from each other, otherwise return_ `false`.

<br/>

**Example 1:**
- **Input:** nums = \[1,0,0,0,1,0,0,1\], k = 2
- **Output:** true
- **Explanation:** Each of the 1s are at least 2 places away from each other.

**Example 2:**
- **Input:** nums = \[1,0,0,1,0,1\], k = 2
- **Output:** false
- **Explanation:** The second 1 and third 1 are only one apart from each other.

<br/>

**Constraints:**

*   <code>1 &lt;= nums.length &lt;= 10<sup>5</sup></code>
*   <code>0 &lt;= k &lt;= nums.length</code>
*   `nums[i]` is `0` or `1`