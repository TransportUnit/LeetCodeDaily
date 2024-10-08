﻿using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        "ABFCACDB",
        2)
    .CreateCase(
        "ACBBD",
        5)
    .CreateCase(
        "CCADDADDDBBCDDBABACADABAABADCABDCCBDACBDBAADDABCABBCABBDDAABCBCBBCCCDBCDDDADAACBCACDDBBA",
        62)
    .CreateCase(
        "DCDCBCBDACBBABDABABCCCBABCCCCCCCBDDBCDACDADABADDCDBBC",
        35)
    .CreateCase(
        "BBBDCADCDACACDBBCACDACDABCBCDDADCDCACCDDBCACCDDDCCBCDBDCBDDCBCBBCCBBBAACBBB",
        47)
    .CreateCase(
        "BCDDBCCCCBACCADDCBDADDCCABCCCBACAADDADCDAACABDDDDABBACBABCABCCDCABBA",
        48)
    .CreateCase(
        "RZAAAACCCCCAABBDDDDDBBBBYAAAAAAACAACAACACCAAAACCACCDDBDDBBBBDDBDBBDBBDBBBBBBBMBSCACCACDBDDBDACCDDBCD",
        6)
    .CreateCase(
        "DCAACCCCCCACCCAACAABBDBBDDDBDDDDDDBBDPCAACAAACAAAAAACDBBBBBBDBBBDBBDACCCAAABBBDDDAACACDBDBBCAACDBBDP",
        4)
    .CreateCase(
        "AXFCCCCCACCACCCAACAACACACAACCAAABBBDDBBDBDBDBBDBBDDDBDDBDDDDDCCACDBDDCABD",
        3)
    .CreateCase(
        "ACACACACACACACACACACACACACACACACACACACACACACACACACDBDBDBDBDBDBDBDBDBDBDBDBDBDBDBDBDBDBDBDBDBDBDBDBDB",
        0)
    .Run();