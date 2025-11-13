# 3228. Maximum Number of Operations to Move Ones to the End

You are given a binary string `s`.

You can perform the following operation on the string **any** number of times:

*   Choose **any** index `i` from the string where `i + 1 < s.length` such that `s[i] == '1'` and `s[i + 1] == '0'`.
*   Move the character `s[i]` to the **right** until it reaches the end of the string or another `'1'`. For example, for `s = "010010"`, if we choose `i = 1`, the resulting string will be `s = "0**001**10"`.

Return the **maximum** number of operations that you can perform.

<br/>

**Example 1:**<br/>
**Input:** s = "1001101"<br/>
**Output:** 4<br/>
**Explanation:**<br/>
- We can perform the following operations:
  *   Choose index `i = 0`. The resulting string is `s = "**001**1101"`.
  *   Choose index `i = 4`. The resulting string is `s = "0011**01**1"`.
  *   Choose index `i = 3`. The resulting string is `s = "001**01**11"`.
  *   Choose index `i = 2`. The resulting string is `s = "00**01**111"`.


**Example 2:**<br/>
**Input:** s = "00111"<br/>
**Output:** 0

<br/>

**Constraints:**

*   <code>1 &lt;= s.length &lt;= 10<sup>5</sup></code>
*   `s[i]` is either `'0'` or `'1'`.