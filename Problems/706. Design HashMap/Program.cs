using LeetCodeDaily.Extensions;

"""
["MyHashMap","put","put","get","get","put","get","remove","get"]
[[],[1,1],[2,2],[1],[3],[2,1],[2],[2],[2]]
[null,null,null,1,-1,null,1,null,-1]

["MyHashMap","remove","put","put","put","put","put","put","get","put","put"]
[[],[2],[3,11],[4,13],[15,6],[6,15],[8,8],[11,0],[11],[1,10],[12,14]]
[null,null,null,null,null,null,null,null,0,null,null]

["MyHashMap","remove","put","get","remove","remove","put","get","put","put","put","get","remove","get","remove","remove","remove","remove","put","put","remove"]
[[],[416695],[495113,909657],[627667],[237284],[77276],[84018,624558],[340321],[823877,944894],[295210,11560],[793578,436501],[655802],[418157],[784343],[56761],[67700],[387474],[832102],[131359,624075],[729011,168329],[743575]]
[null,null,null,-1,null,null,null,-1,null,null,null,-1,null,-1,null,null,null,null,null,null,null]

["MyHashMap","put","get","put","get"]
[[],[1000000,1],[1000000],[0,2],[0]]
[null,null,1,null,2]
"""
.ParseCases<(string, string), string>()
.DetectAndRun();