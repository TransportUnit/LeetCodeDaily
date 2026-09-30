# 1614. Maximum Nesting Depth of the Parentheses

Given a **valid parentheses string** `s`, return the **nesting depth** of* *`s`. The nesting depth is the **maximum** number of nested parentheses.

<br/>

# **Example 1:**

**Input:** s = "(1+(2*3)+((8)/4))+1"

**Output:** 3

**Explanation:**

Digit 8 is inside of 3 nested parentheses in the string.

<br/>

# **Example 2:**

**Input:** s = "(1)+((2))+(((3)))"

**Output:** 3

**Explanation:**

Digit 3 is inside of 3 nested parentheses in the string.

<br/>

# **Example 3:**

**Input:** s = "()(())((()()))"

**Output:** 3

<br/>

# **Constraints:**

*   <code>1 &lt;= s.length &lt;= 100</code>
*   `s` consists of digits `0-9` and characters `'+'`, `'-'`, `'*'`, `'/'`, `'('`, and `')'`.
*   It is guaranteed that parentheses expression `s` is a VPS.

<br/>

<details><summary>Hint 1</summary>The depth of any character in the VPS is the ( number of left brackets before it ) - ( number of right brackets before it )</details>
