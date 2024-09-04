# 191. Number of 1 Bits

[id1]: ## "Set Bit
A set bit refers to a bit in the binary representation of a number that has a value of 1."

Write a function that takes the binary representation of a positive integer and returns the number of 
[set bits][id1] it has (also known as the [Hamming weight](https://en.wikipedia.org/wiki/Hamming_weight "Wikipedia")).

<br/>

**Example 1**:

	Input: n = 11
	Output: 3
	Explanation:
		The input binary string 1011 has a total of three set bits.



**Example 2**:

	Input: n = 128
	Output: 1
	Explanation:
		The input binary string 10000000 has a total of one set bit.



**Example 3**:

	Input: n = 2147483645
	Output: 30
	Explanation:
		The input binary string 1111111111111111111111111111101 has a total of thirty set bits.
 
<br/>

**Constraints**:
- `1 <= n <= 231 - 1`
 
<br/>

**Follow up**: If this function is called many times, how would you optimize it?