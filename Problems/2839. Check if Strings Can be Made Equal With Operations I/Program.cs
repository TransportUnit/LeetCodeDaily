using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

"""
abcd
cdab
true

abcd
dacb
false

gckx
ckgx
false

gpfu
gupf
false

drih
dhri
false

rzvo
rvzo
false

jsvj
ravc
false

rihr
irrh
false

hhlz
hzhl
false

wyjh
wjyh
false
"""
.ParseCases<(string, string), bool>()
.DetectAndRun();