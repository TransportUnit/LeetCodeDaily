using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

"""
["c","f","j"]
"a"
"c"

["c","f","j"]
"c"
"f"

["x","x","y","y"]
"z"
"x"

["e","e","e","e","e","e","n","n","n","n"]
"e"
"n"

["c","f","j"]
"g"
"j"

["c","f","j"]
"d"
"f"

["c","f","j", "k", "m", "p"]
"l"
"m"

["c","f","j"]
"j"
"c"
"""
.Replace("\"", string.Empty)
.ParseCases<(char[], char), char>()
.DetectAndRun();