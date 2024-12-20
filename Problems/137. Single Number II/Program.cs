﻿using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

var baseCase = 
    Case
        .CreateCase(
            "[2,2,3,2]".ParseArray<int>(),
            3)
        .CreateCase(
            "[0,1,0,1,0,1,99]".ParseArray<int>(),
            99)
        .CreateCase(
            "[67, 1, 99, 1, 1, 67, 67]".ParseArray<int>(),
            99)
        ;

ResultGeneratorAttribute.Detect();

baseCase.Run();

ResultGeneratorAttribute.Detect(1);

baseCase.Run();