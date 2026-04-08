# 3653. XOR After Range Multiplication Queries I

You are given an integer array `nums` of length `n` and a 2D integer array `queries` of size `q`, where <code>queries[i] = [l<sub>i</sub>, r<sub>i</sub>, k<sub>i</sub>, v<sub>i</sub>]</code>.

For each query, you must apply the following operations in order:

*   Set <code>idx = l<sub>i</sub></code>.
*   While <code>idx &lt;= r<sub>i</sub></code>:
    *   Update: <code>nums[idx] = (nums[idx] * v<sub>i</sub>) % (10<sup>9</sup> + 7)</code>
    *   Set <code>idx += k<sub>i</sub></code>.

Return the **bitwise XOR** of all elements in `nums` after processing all queries.


<br/>

# **Example 1:**

**Input:** nums = \[1,1,1\], queries = \[\[0,2,1,4\]\]

**Output:** 4

**Explanation:**

*   A single query `[0, 2, 1, 4]` multiplies every element from index 0 through index 2 by 4.
*   The array changes from `[1, 1, 1]` to `[4, 4, 4]`.
*   The XOR of all elements is `4 ^ 4 ^ 4 = 4`.

# **Example 2:**

**Input:** nums = \[2,3,1,5,4\], queries = \[\[1,4,2,3\],\[0,2,1,2\]\]

**Output:** 31

**Explanation:**

*   The first query `[1, 4, 2, 3]` multiplies the elements at indices 1 and 3 by 3, transforming the array to `[2, 9, 1, 15, 4]`.
*   The second query `[0, 2, 1, 2]` multiplies the elements at indices 0, 1, and 2 by 2, resulting in `[4, 18, 2, 15, 4]`.
*   Finally, the XOR of all elements is `4 ^ 18 ^ 2 ^ 15 ^ 4 = 31`.​​​​​​​**​​​​​​​**

<br/>

# **Constraints:**

*   <code>1 &lt;= n == nums.length &lt;= 10<sup>3</sup></code>
*   <code>1 &lt;= nums[i] &lt;= 10<sup>9</sup></code>
*   <code>1 &lt;= q == queries.length &lt;= 10<sup>3</sup></code>
*   `queries[i] = [li, ri, ki, vi]`
*   `0 <= li <= ri < n`
*   `1 <= ki <= n`
*   <code>1 &lt;= vi &lt;= 10<sup>5</sup></code>

<br/>

<details><summary>Hint 1</summary>Use bruteforce</details>