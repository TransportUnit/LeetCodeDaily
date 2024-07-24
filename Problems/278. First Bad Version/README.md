# 278. First Bad Version

You are a product manager and currently leading a team to develop a new product.<br/>
Unfortunately, the latest version of your product fails the quality check.<br/>
Since each version is developed based on the previous version, all the versions after a bad version are also bad.<br/>

Suppose you have n versions [1, 2, ..., n] and you want to find out the first bad one, which causes all the following ones to be bad.<br/>
You are given an API bool isBadVersion(version) which returns whether version is bad.<br/>
Implement a function to find the first bad version.<br/>
You should minimize the number of calls to the API.

<br/>

Example 1:
- Input: n = 5, bad = 4
- Output: 4
- Explanation:
  - call isBadVersion(3) -> false
  - call isBadVersion(5) -> true
  - call isBadVersion(4) -> true
  - Then 4 is the first bad version.

<br/>

Example 2:
- Input: n = 1, bad = 1
- Output: 1

<br/>

Constraints:
- 1 &lt;= bad &lt;= n &lt;= 231 - 1