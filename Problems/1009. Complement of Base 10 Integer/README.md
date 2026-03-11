# 1009. Complement of Base 10 Integer

The **complement** of an integer is the integer you get when you flip all the `0`'s to `1`'s and all the `1`'s to `0`'s in its binary representation.

*   For example, The integer `5` is `"101"` in binary and its **complement** is `"010"` which is the integer `2`.

Given an integer `n`, return _its complement_.

<br/>

# **Example 1:**

**Input:** n = 5

**Output:** 2

**Explanation:** 5 is "101" in binary, with complement "010" in binary, which is 2 in base-10.

# **Example 2:**

**Input:** n = 7

**Output:** 0

**Explanation:** 7 is "111" in binary, with complement "000" in binary, which is 0 in base-10.

# **Example 3:**

**Input:** n = 10

**Output:** 5

**Explanation:** 10 is "1010" in binary, with complement "0101" in binary, which is 5 in base-10.

<br/>

# **Constraints:**

*   <code>0 &lt;= n &lt; 10<sup>9</sup></code> 


**Note:** This question is the same as 476

<br/>

<details>
<summary>Hint 1</summary>
<p>
A binary number plus its complement will equal 111....111 in binary. Also, N = 0 is a corner case.
</p>
</details>