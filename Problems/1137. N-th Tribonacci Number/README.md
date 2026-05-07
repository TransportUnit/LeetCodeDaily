# 1137. N-th Tribonacci Number

The Tribonacci sequence Tn is defined as follows: 

T0 = 0, T1 = 1, T2 = 1, and Tn+3 = Tn + Tn+1 + Tn+2 for n >= 0.

Given `n`, return the value of Tn.

<br/>

# **Example 1:**

**Input:** n = 4
**Output:** 4
**Explanation:**
T\_3 = 0 + 1 + 1 = 2
T\_4 = 1 + 1 + 2 = 4

# **Example 2:**

**Input:** n = 25
**Output:** 1389537

<br/>

# **Constraints:**

*   `0 <= n <= 37`
*   The answer is guaranteed to fit within a 32-bit integer, ie. <code>answer &lt;= 2<sup>31</sup> - 1</code>.

<br/>

<details><summary>Hint 1</summary>Make an array F of length 38, and set F[0] = 0, F[1] = F[2] = 1.</details>
<details><summary>Hint 2</summary>Now write a loop where you set F[n+3] = F[n] + F[n+1] + F[n+2], and return F[n].</details>