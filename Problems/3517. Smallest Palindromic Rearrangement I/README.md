# 3517. Smallest Palindromic Rearrangement I

You are given a **palindromic** string `s`.

Return the **lexicographically smallest** palindromic permutation of `s`.

<br/>

# **Example 1:**

**Input:** s = "z"

**Output:** "z"

**Explanation:**

A string of only one character is already the lexicographically smallest palindrome.

<br/>

# **Example 2:**

**Input:** s = "babab"

**Output:** "abbba"

**Explanation:**

Rearranging `"babab"` &rarr; `"abbba"` gives the smallest lexicographic palindrome.

<br/>

# **Example 3:**

**Input:** s = "daccad"

**Output:** "acddca"

**Explanation:**

Rearranging `"daccad"` &rarr; `"acddca"` gives the smallest lexicographic palindrome.

<br/>

# **Constraints:**

*   <code>1 &lt;= s.length &lt;= 10<sup>5</sup></code>
*   `s` consists of lowercase English letters.
*   `s` is guaranteed to be palindromic.

<br/>

<details><summary>Hint 1</summary>Consider a palindrome as composed of two mirror-image halves.</details>
<details><summary>Hint 2</summary>Construct one half (using `s`), and then the other half is its reverse to obtain the lexicographically smallest permutation.</details>
