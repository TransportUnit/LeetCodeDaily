# 1545. Find Kth Bit in Nth Binary String

Given two positive integers `n` and `k`, the binary string `Sn` is formed as follows:

*   `S1 = "0"`
*   `Si = Si - 1 + "1" + reverse(invert(Si - 1))` for `i > 1`

Where `+` denotes the concatenation operation, `reverse(x)` returns the reversed string `x`, and `invert(x)` inverts all the bits in `x` (`0` changes to `1` and `1` changes to `0`).

For example, the first four strings in the above sequence are:

*   `S1 = "0"`
*   `S2 = "0**1**1"`
*   `S3 = "011**1**001"`
*   `S4 = "0111001**1**0110001"`

Return _the_ `kth` _bit_ _in_ `Sn`. It is guaranteed that `k` is valid for the given `n`.

<br/>

# **Example 1:**

**Input:** n = 3, k = 1

**Output:** "0"

**Explanation:** S3 is "**0**111001".

The 1st bit is "0".

# **Example 2:**

**Input:** n = 4, k = 11

**Output:** "1"

**Explanation:** S4 is "0111001101**1**0001".

The 11th bit is "1".

<br/>

# **Constraints:**

*   `1 <= n <= 20`
*   <code>1 &lt;= k &lt;= 2<sup>n</sup> - 1</code>
	

<br/>

<details>
<summary>Hint 1</summary>
<p>Since n is small, we can simply simulate the process of constructing S1 to Sn.</p>
</details>