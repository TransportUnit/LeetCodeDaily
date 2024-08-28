using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        ("[[1,1,1,1,0]," +
          "[1,1,0,1,0]," +
          "[1,1,0,0,0]," +
          "[0,0,0,0,0]]").ParseMatrix<char>(),
        1)
    .CreateCase(
        ("[[1,1,0,0,0]," +
          "[1,1,0,0,0]," +
          "[0,0,1,0,0]," +
          "[0,0,0,1,1]]").ParseMatrix<char>(),
        3)
    .Run();