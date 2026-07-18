# 1979. Find Greatest Common Divisor of Array

Given an integer array `nums`, return** ***the **greatest common divisor** of the smallest number and largest number in *`nums`.

The **greatest common divisor** of two numbers is the largest positive integer that evenly divides both numbers.

<br/>

# **Example 1:**

**Input:** nums = \[2,5,6,9,10\]

**Output:** 2

**Explanation:**

The smallest number in nums is 2.

The largest number in nums is 10.

The greatest common divisor of 2 and 10 is 2.

<br/>

# **Example 2:**

**Input:** nums = \[7,5,6,8,3\]

**Output:** 1

**Explanation:**

The smallest number in nums is 3.

The largest number in nums is 8.

The greatest common divisor of 3 and 8 is 1.

<br/>

# **Example 3:**

**Input:** nums = \[3,3\]

**Output:** 3

**Explanation:**

The smallest number in nums is 3.

The largest number in nums is 3.

The greatest common divisor of 3 and 3 is 3.

<br/>

# **Constraints:**

*   <code>2 &lt;= nums.length &lt;= 1000</code>
*   <code>1 &lt;= nums[i] &lt;= 1000</code>

<br/>

<details><summary>Hint 1</summary>Find the minimum and maximum in one iteration. Let them be mn and mx.</details>
<details><summary>Hint 2</summary>Try all the numbers in the range \[1, mn\] and check the largest number which divides both of them.</details>
