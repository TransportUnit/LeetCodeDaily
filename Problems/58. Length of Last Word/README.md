# 58. Length of Last Word

Given a string `s` consisting of words and spaces, return _the length of the **last** word in the string._

A **word** is a maximal substring consisting of non-space characters only.

<br/>

**Example 1:**
- **Input:** s = "Hello World"
- **Output:** 5
- **Explanation:** The last word is "World" with length 5.

<br/>

**Example 2:**
- **Input:** s = "   fly me   to   the moon  "
- **Output:** 4
- **Explanation:** The last word is "moon" with length 4.

<br/>

**Example 3:**
- **Input:** s = "luffy is still joyboy"
- **Output:** 6
- **Explanation:** The last word is "joyboy" with length 6.

<br/>

**Constraints:**

*   `1 <= s.length <= 104`
*   `s` consists of only English letters and spaces `' '`.
*   There will be at least one word in `s`.