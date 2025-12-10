# 239. Sliding Window Maximum

You are given an array of integers `nums`, there is a sliding window of size `k` which is moving from the very left of the array to the very right. You can only see the `k` numbers in the window. Each time the sliding window moves right by one position.

Return _the max sliding window_.

<br/>

# **Example 1:**

**Input:** nums = \[1,3,-1,-3,5,3,6,7\], k = 3

**Output:** \[3,3,5,5,6,7\]

**Explanation:**<br/>
<code>Window position --------- Max</code><br/>
<code>-----------------------------</code><br/>
<code>[1  3  -1] -3  5  3  6  7---------3</code><br/>
<code> 1 [3  -1  -3] 5  3  6  7---------3</code><br/>
<code> 1  3 [-1  -3  5] 3  6  7---------5</code><br/>
<code> 1  3  -1 [-3  5  3] 6  7---------5</code><br/>
<code> 1  3  -1  -3 [5  3  6] 7---------6</code><br/>
<code> 1  3  -1  -3  5 [3  6  7]---------7</code><br/>
# **Example 2:**

**Input:** nums = \[1\], k = 1

**Output:** \[1\]

<br/>

 # **Constraints:**

*   <code>1 &lt;= nums.length &lt;= 10<sup>5</sup></code>
*   <code>-10<sup>4</sup> &lt;= nums[i] &lt;= 10<sup>4</sup></code>
*   <code>1 &lt;= k &lt;= nums.length</code>

<br/>

# Hint 1
How about using a data structure such as deque (double-ended queue)?

# Hint 2
The queue size need not be the same as the window’s size.

# Hint 3
Remove redundant elements and the queue should store only elements that need to be considered.