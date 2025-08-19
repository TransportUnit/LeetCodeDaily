# 2586. Count the Number of Vowel Strings in Range

You are given a **0-indexed** array of string `words` and two integers `left` and `right`.

A string is called a **vowel string** if it starts with a vowel character and ends with a vowel character where vowel characters are `'a'`, `'e'`, `'i'`, `'o'`, and `'u'`.

Return _the number of vowel strings_ `words[i]` _where_ `i` _belongs to the inclusive range_ `[left, right]`.

<br/>

**Example 1:**
- **Input:** words = \["are","amy","u"\], left = 0, right = 2
- **Output:** 2
- **Explanation:** 
  - "are" is a vowel string because it starts with 'a' and ends with 'e'.
  - "amy" is not a vowel string because it does not end with a vowel.
  - "u" is a vowel string because it starts with 'u' and ends with 'u'.
  - The number of vowel strings in the mentioned range is 2.

**Example 2:**
- **Input:** words = \["hey","aeo","mu","ooo","artro"\], left = 1, right = 4
- **Output:** 3
- **Explanation:** 
  - "aeo" is a vowel string because it starts with 'a' and ends with 'o'.
  - "mu" is not a vowel string because it does not start with a vowel.
  - "ooo" is a vowel string because it starts with 'o' and ends with 'o'.
  - "artro" is a vowel string because it starts with 'a' and ends with 'o'.
  - The number of vowel strings in the mentioned range is 3.

<br/>

**Constraints:**

*   <code>1 &lt;= words.length &lt;= 1000</code>
*   <code>1 &lt;= words[i].length &lt;= 10</code>
*   <code>words[i]</code> consists of only lowercase English letters.
*   <code>0 &lt;= left &lt;= right &lt; words.length</code>