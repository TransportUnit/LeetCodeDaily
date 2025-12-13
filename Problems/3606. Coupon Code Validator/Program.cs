using _3606.Coupon_Code_Validator;
using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

string cases =
"""
["SAVE20","","PHARMA5","SAVE@20"]
["restaurant","grocery","pharmacy","restaurant"]
[true,true,true,true]
["PHARMA5","SAVE20"]

["GROCERY15","ELECTRONICS_50","DISCOUNT10"]
["grocery","electronics","invalid"]
[false,true,true]
["ELECTRONICS_50"]

["SAVE50","SAVE30","PHARMA5","SAVE@20"]
["restaurant","restaurant","pharmacy","restaurant"]
[true,true,true,true]
["PHARMA5","SAVE30","SAVE50"]

["MI","b_"]
["pharmacy","pharmacy"]
[true,true]
["MI","b_"]
""";

var solutionInstance = new Solution();
Case.SetResultGenerator<(string[], string[], bool[]), string[]>((input) => solutionInstance.ValidateCoupons(input.Item1, input.Item2, input.Item3).ToArray());

cases
    .ParseCases<(string[], string[], bool[]), string[]>()
    .Run();