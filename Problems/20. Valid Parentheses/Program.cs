using LeetCodeDaily.Core;
using LeetCodeDaily.Extensions;

ResultGeneratorAttribute.Detect();

Case
    .CreateCase(
        "()",
        true)
    .CreateCase(
        "()[]{}",
        true)
    .CreateCase(
        "(]",
        false)
      .CreateCase(
        "([])",
        true)
      .CreateCase(
        "((",
        false)
    .Run();