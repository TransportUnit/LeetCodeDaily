# 2089. Find Target Indices After Sorting Array

You are given a **0-indexed** integer array `nums` and a target element `target`.

A **target index** is an index `i` such that `nums[i] == target`.

Return *a list of the target indices of* `nums` after* sorting *`nums`* in **non-decreasing** order*. If there are no target indices, return *an **empty** list*. The returned list must be sorted in **increasing** order.

<br/>

# **Example 1:**

**Input:** nums = \[1,2,5,2,3\], target = 2

**Output:** \[1,2\]

**Explanation:** After sorting, nums is \[1,**2**,**2**,3,5\].

The indices where nums\[i\] == 2 are 1 and 2.

<br/>

# **Example 2:**

**Input:** nums = \[1,2,5,2,3\], target = 3

**Output:** \[3\]

**Explanation:** After sorting, nums is \[1,2,2,**3**,5\].

The index where nums\[i\] == 3 is 3.

<br/>

# **Example 3:**

**Input:** nums = \[1,2,5,2,3\], target = 5

**Output:** \[4\]

**Explanation:** After sorting, nums is \[1,2,2,3,**5**\].

The index where nums\[i\] == 5 is 4.

<br/>

# **Constraints:**

*   <code>1 &lt;= nums.length &lt;= 100</code>
*   <code>1 &lt;= nums[i], target &lt;= 100</code>

<br/>

<details><summary>Hint 1</summary>Try "sorting" the array first.</details>
<details><summary>Hint 2</summary>Now find all indices in the array whose values are equal to target.</details>
