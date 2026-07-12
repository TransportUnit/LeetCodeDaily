# 1331. Rank Transform of an Array

Given an array of integers `arr`, replace each element with its rank.

The rank represents how large the element is. The rank has the following rules:

*   Rank is an integer starting from 1.
*   The larger the element, the larger the rank. If two elements are equal, their rank must be the same.
*   Rank should be as small as possible.

<br/>

# **Example 1:**

**Input:** arr = \[40,10,20,30\]

**Output:** \[4,1,2,3\]

**Explanation**: 40 is the largest element. 10 is the smallest. 20 is the second smallest. 30 is the third smallest.

<br/>

# **Example 2:**

**Input:** arr = \[100,100,100\]

**Output:** \[1,1,1\]

**Explanation**: Same elements share the same rank.

<br/>

# **Example 3:**

**Input:** arr = \[37,12,28,9,100,56,80,5,12\]

**Output:** \[5,3,4,2,8,6,7,1,3\]

<br/>

# **Constraints:**

*   <code>0 &lt;= arr.length &lt;= 10<sup>5</sup></code>
*   <code>-10<sup>9</sup>&nbsp;&lt;= arr[i] &lt;= 10<sup>9</sup></code>

<br/>

<details><summary>Hint 1</summary>Use a temporary array to copy the array and sort it.</details>
<details><summary>Hint 2</summary>The rank of each element is the number of unique elements smaller than it in the sorted array plus one.</details>
