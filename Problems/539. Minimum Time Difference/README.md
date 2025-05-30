# 539. Minimum Time Difference

Given a list of 24-hour clock time points in **"HH:MM"** format, return _the minimum **minutes** difference between any two time-points in the list_.

<br/>

**Example 1:**
- **Input:** timePoints = \["23:59","00:00"\]
- **Output:** 1

**Example 2:**
- **Input:** timePoints = \["00:00","23:59","00:00"\]
- **Output:** 0

<br/>

**Constraints:**

*   `2 <= timePoints.length <= 2 * 10`<sup>`4`</sup>
*   `timePoints[i]` is in the format **"HH:MM"**.