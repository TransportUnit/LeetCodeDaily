# 744. Find Smallest Letter Greater Than Target

You are given an array of characters `letters` that is sorted in **non-decreasing order**, and a character `target`. There are **at least two different** characters in `letters`.

Return _the smallest character in_ `letters` _that is lexicographically greater than_ `target`. If such a character does not exist, return the first character in `letters`.

<br/>

# **Example 1:**

**Input:** letters = \["c","f","j"\], target = "a"

**Output:** "c"

**Explanation:** The smallest character that is lexicographically greater than 'a' in letters is 'c'.

# **Example 2:**

**Input:** letters = \["c","f","j"\], target = "c"

**Output:** "f"

**Explanation:** The smallest character that is lexicographically greater than 'c' in letters is 'f'.

# **Example 3:**

**Input:** letters = \["x","x","y","y"\], target = "z"

**Output:** "x"

**Explanation:** There are no characters in letters that is lexicographically greater than 'z' so we return letters\[0\].

<br/>

# **Constraints:**

*   <code>2 &lt;= letters.length &lt;= 10<sup>4</sup></code>
*   `letters[i]` is a lowercase English letter.
*   `letters` is sorted in **non-decreasing** order.
*   `letters` contains at least two different characters.
*   `target` is a lowercase English letter.

<br/>

<details>
<summary>Hint 1</summary>
Try to find whether each of 26 next letters are in the given string array.
</details>
