# 20. Valid Parentheses

Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

1. Open brackets must be closed by the same type of brackets.
2. Open brackets must be closed in the correct order.
3. Every close bracket has a corresponding open bracket of the same type.

<br/>

Example 1:
- Input: s = "()"
- Output: true

<br/>

Example 2:
- Input: s = "()[]{}"
- Output: true

<br/>

Example 3:
- Input: s = "(]"
- Output: false

<br/>

Example 4:
- Input: s = "([])"
- Output: true

<br/>

Constraints:
- 1 &lt;= s.length &lt;= 104
- s consists of parentheses only '()[]{}'.