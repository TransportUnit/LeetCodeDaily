# 125. Valid Palindrome

A phrase is a **palindrome** if, after converting all uppercase letters into lowercase letters and removing all non-alphanumeric characters, it reads the same forward and backward. Alphanumeric characters include letters and numbers.

Given a string `s`, return `true` _if it is a **palindrome**, or_ `false` _otherwise_.

<br/>

**Example 1:**
- **Input:** s = "A man, a plan, a canal: Panama"
- **Output:** true
- **Explanation:** "amanaplanacanalpanama" is a palindrome.

**Example 2:**
- **Input:** s = "race a car"
- **Output:** false
- **Explanation:** "raceacar" is not a palindrome.

**Example 3:**
- **Input:** s = " "
- **Output:** true
- **Explanation:** s is an empty string "" after removing non-alphanumeric characters.
Since an empty string reads the same forward and backward, it is a palindrome.

<br/>

**Constraints:**

*   <code>1 &lt;= s.length &lt;= 2 * 10<sup>5</sup></code>
*   `s` consists only of printable ASCII characters.