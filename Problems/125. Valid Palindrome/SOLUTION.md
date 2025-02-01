Intuition & Approach
====================

Move towards the middle of the string from both ends, and compare each valid pair of characters. If a pair doesn't match, we can assume that `s` is not a palindrome and return `false`. We use two (actual) pointers to traverse the string.

If both pointers meet at the same index, we can safely assume that each pair so far has matched up, and there are either only invalid characters left (as in `"abc....cba"`) or we traversed the entire string. At this point, we return `true`.

Before each comparison, we skip any invalid character at either end by checking that its decimal value is within one of the defined ranges (`'0-9'`, `'A-Z'`, `'a-z'`).  
This completely avoids having to remove all invalid characters from the string before iterating over it (and having to allocate extra memory, since strings are immutable in my language of choice).

_Side note: C# strings are UTF-16 encoded, but fortunately every character in the ASCII table has the same UTF-16 decimal representation._

The comparison itself is a bit trickier, as the palindrome string can contain both upper and lower case letters, as well as numbers.  
Remember: at the point of comparison, we can assume that both characters selected are at least within this range, since we would have already returned `true` if the pointers had met at the same index (i.e. we found a pair of valid characters).

If the decimal values between the two characters do not match up, we have to investigate further.  
If either one of them is a number (decimal representation: `'48-57'`), they must be different characters if their decimal values differ.  
We can check whether a character is a number by taking a look at the other decimal representation ranges: `'a-z'` is represented by `'97-122'` and `'A-Z'` is represented by `'65-90'`, so any value below 'A' has to be a number.

If neither character is a number, there is only one possible scenario where both characters represent the same letter, but have different decimal representation values: their letter case is different (example: `'b', 'B'`).  
We confirm that by simply checking if either character plus the ASCII table offset between lower case and upper case letters equals the other letter (Offset: `'a' - 'A'` = 97 - 65 = _**32**_).  
If that is not the case, we return `false`.

Complexity
==========

*   Time complexity: _**O(n)**_

*   Space complexity: _**O(1)**_

Code
====

see _Solution.cs__