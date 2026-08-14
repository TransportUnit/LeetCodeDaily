# 3090. Maximum Length Substring With Two Occurrences

Given a string `s`, return the **maximum** length of a substring such that it contains *at most two occurrences* of each character.

<br/>

# **Example 1:**

**Input:** s = "bcbbbcba"

**Output:** 4

**Explanation:**

The following substring has a length of 4 and contains at most two occurrences of each character: <code>"bcbb<u>bcba</u>"</code>.

<br/>

# **Example 2:**

**Input:** s = "aaaa"

**Output:** 2

**Explanation:**

The following substring has a length of 2 and contains at most two occurrences of each character: <code>"<u>aa</u>aa"</code>.

<br/>

# **Constraints:**

*   <code>2 &lt;= s.length &lt;= 100</code>
*   `s` consists only of lowercase English letters.

<br/>

<details><summary>Hint 1</summary>We can try all substrings by brute-force since the constraints are very small.</details>
