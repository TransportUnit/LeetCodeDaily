# 812. Largest Triangle Area

Given an array of points on the **X-Y** plane `points` where `points[i] = [xi, yi]`, return _the area of the largest triangle that can be formed by any three different points_. Answers within `10-5` of the actual answer will be accepted.

<br/>

**Example 1:**
- **Input:** points = \[\[0,0\],\[0,1\],\[1,0\],\[0,2\],\[2,0\]\]
- **Output:** 2.00000
- **Explanation:** The five points are shown in the above figure. The red triangle is the largest.

**Example 2:**
- **Input:** points = \[\[1,0\],\[0,0\],\[0,1\]\]
- **Output:** 0.50000

<br/>

**Constraints:**

*   <code>3 &lt;= points.length &lt;= 50</code>
*   <code>-50 &lt;= xi, yi &lt;= 50</code>
*   All the given points are **unique**.