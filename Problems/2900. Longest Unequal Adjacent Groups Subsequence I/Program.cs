using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

Case
    .CreateCase(
        ("[\"a\", \"b\", \"c\", \"d\", \"e\"]".ParseArray<string>(), "[1, 1, 1, 1, 1]".ParseArray<int>()),
        "[\"a\"]".ParseArray<string>().ToList() as IList<string>)
    .CreateCase(
        ("[\"a\", \"b\", \"c\", \"d\", \"e\"]".ParseArray<string>(), "[0, 0, 0, 0, 0]".ParseArray<int>()),
        "[\"a\"]".ParseArray<string>().ToList())
    .CreateCase(
        ("[\"f\", \"o\", \"l\", \"i\", \"v\", \"r\", \"a\", \"q\", \"z\", \"g\", \"p\", \"h\", \"n\", \"c\", \"y\", \"u\", \"e\", \"b\", \"k\", \"t\", \"w\", \"m\", \"x\", \"j\", \"s\", \"d\"]".ParseArray<string>(), "[0, 1, 1, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1, 0, 1, 1, 0, 1, 0]".ParseArray<int>()),
        "[\"f\",\"o\",\"i\",\"v\",\"a\",\"g\",\"p\",\"h\",\"n\",\"u\",\"b\",\"t\",\"w\",\"m\",\"j\",\"s\",\"d\"]".ParseArray<string>().ToList())
    .CreateCase(
        ("[\"zvedu\", \"lwdc\", \"hdzxskgolc\", \"riavnjtkkq\", \"rcjus\", \"lkdy\", \"t\", \"ogetdzwtp\", \"bxkr\", \"ul\", \"hql\", \"ajragiuuo\", \"n\", \"wve\", \"qrnsfj\", \"lxq\", \"kiiwtt\", \"ipaiguj\", \"dmp\", \"vgojlcy\", \"hl\", \"vhbylrhf\", \"utxz\", \"lc\", \"zg\", \"sny\", \"vkhd\", \"zwlzbzhuy\", \"e\", \"yay\", \"iuaz\", \"kulsuuksdi\", \"idzikb\", \"larthyyfrp\", \"tlzxb\", \"rxngmsw\", \"xyrbfmttf\", \"fgcehzw\", \"tksuk\", \"psngvcgjz\", \"alqrm\", \"bgfb\", \"fmbuv\", \"snprpzdees\", \"qlkofi\", \"yrdbyv\", \"y\", \"pnhxulzx\", \"yprndzrv\", \"yybcsdpivk\", \"xzljt\", \"tk\", \"anou\", \"tnzaszevuz\", \"iz\", \"cins\", \"lm\", \"g\", \"gap\", \"yrgowfrgv\", \"sawxnnnct\", \"unsaxygosz\", \"nsjlxxesm\", \"ujmav\", \"vj\", \"dam\", \"slnyvnzj\", \"eevhhnw\", \"gtqbbp\", \"krvzq\", \"memclrd\", \"gvwaaqrgz\", \"aigxxlhir\", \"vkbdo\", \"jazqnndx\", \"ttnai\", \"tkg\", \"iswjne\", \"scnr\", \"rm\", \"yjyr\", \"rvwo\", \"nvktima\", \"vwdqokabvb\", \"ahbmkhfim\", \"uvsvlvyvg\", \"rk\", \"ogqsoeywih\", \"v\", \"ccm\", \"fu\", \"crti\", \"bfvoapp\", \"d\", \"ayqulkg\", \"c\", \"vv\", \"qqkjaubnf\", \"pkhtth\", \"hdxmfxqpv\"]".ParseArray<string>(), "[1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1, 0, 1, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 0, 1, 1, 1, 0, 0, 1, 1, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 1, 0, 0]".ParseArray<int>()),
        "[\"zvedu\",\"lwdc\",\"rcjus\",\"lkdy\",\"t\",\"ogetdzwtp\",\"hql\",\"ajragiuuo\",\"wve\",\"qrnsfj\",\"kiiwtt\",\"ipaiguj\",\"vgojlcy\",\"hl\",\"utxz\",\"sny\",\"zwlzbzhuy\",\"e\",\"yay\",\"iuaz\",\"fgcehzw\",\"psngvcgjz\",\"alqrm\",\"qlkofi\",\"y\",\"pnhxulzx\",\"yprndzrv\",\"xzljt\",\"tk\",\"tnzaszevuz\",\"iz\",\"cins\",\"lm\",\"gap\",\"ujmav\",\"vj\",\"slnyvnzj\",\"gtqbbp\",\"aigxxlhir\",\"jazqnndx\",\"ttnai\",\"scnr\",\"yjyr\",\"nvktima\",\"vwdqokabvb\",\"rk\",\"v\",\"bfvoapp\",\"ayqulkg\",\"c\",\"vv\",\"pkhtth\"]".ParseArray<string>().ToList())
    .Detect()
    .SetResultChecker(ResultChecker)
    .Run();

bool ResultChecker(Case<(string[], int[]), IList<string>> c)
{
    if (c.ExpectedResult is null)
    {
        return c.ActualResult is null;
    }
    else
    {
        if (c.ActualResult is null)
        {
            return false;
        }
    }

    if (c.ExpectedResult.Count != c.ActualResult.Count)
    {
        return false;
    }

    if (c.ActualResult.Except(c.Input.Item1).Any())
    {
        return false;
    }

    var resultsWithIndexes = 
        c.ActualResult
        .Select(x => 
            new 
            { 
                Entry = x, 
                Index = Array.IndexOf(c.Input.Item1, x) 
            })
        .ToList();

    // kind of redundant
    if (resultsWithIndexes.Any(x => x.Index < 0))
    {
        return false;
    }

    var first = resultsWithIndexes.First();

    var lastgroupValue = c.Input.Item2[first.Index];

    foreach (var resultWithIndex in resultsWithIndexes.Skip(1))
    {
        var currentGroupValue = c.Input.Item2[resultWithIndex.Index];

        if (currentGroupValue == lastgroupValue)
        {
            return false;
        }

        lastgroupValue = currentGroupValue;
    }

    return true;
}