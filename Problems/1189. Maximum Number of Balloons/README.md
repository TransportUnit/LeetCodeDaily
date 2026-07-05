# 1189. Maximum Number of Balloons

Given a string `text`, you want to use the characters of `text` to form as many instances of the word **"balloon"** as possible.

You can use each character in `text` **at most once**. Return the maximum number of instances that can be formed.

<br/>

# **Example 1:**

**![](1536_ex1_upd.JPG)**

**Input:** text = "nlaebolko"

**Output:** 1

# **Example 2:**

**![](1536_ex2_upd.JPG)**

**Input:** text = "loonbalxballpoon"

**Output:** 2

# **Example 3:**

**Input:** text = "leetcode"

**Output:** 0

<br/>

# **Constraints:**

*   <code>1 <= text.length <= 10<sup>4</sup></code>
*   `text` consists of lower case English letters only.

<br/>

<details><summary>Hint 1</summary>Count the frequency of letters in the given string.</details>
<details><summary>Hint 2</summary>Find the letter than can make the minimum number of instances of the word "balloon".</details>