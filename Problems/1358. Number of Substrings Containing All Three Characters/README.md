# 1358. Number of Substrings Containing All Three Characters

Given a string `s` consisting only of characters _a_, _b_ and _c_.

Return the number of substrings containing **at least** one occurrence of all these characters _a_, _b_ and _c_.

<br/>

# **Example 1:**

**Input:** s = "abcabc"

**Output:** 10

**Explanation:** 
* The substrings containing at least one occurrence of the characters _a_, _b_ and _c are "_abc_", "_abca_", "_abcab_", "_abcabc_", "_bca_", "_bcab_", "_bcabc_", "_cab_", "_cabc_"_ and _"_abc_"_ (**again**)_._ 

# **Example 2:**

**Input:** s = "aaacb"

**Output:** 3

**Explanation:** 
* The substrings containing at least one occurrence of the characters _a_, _b_ and _c are "_aaacb_", "_aacb_"_ and _"_acb_"._ 

# **Example 3:**

**Input:** s = "abc"

**Output:** 1

<br/>

# **Constraints:**

*   <code>3 &lt;= s.length &lt;= 5 x 10<sup>4</sup></code>
*   `s` only consists of _a_, _b_ or _c_ characters.

<br/>

<details><summary>Hint 1</summary>For each position we simply need to find the first occurrence of a/b/c on or after this position.</details>
<details><summary>Hint 2</summary>So we can pre-compute three link-list of indices of each a, b, and c.</details>