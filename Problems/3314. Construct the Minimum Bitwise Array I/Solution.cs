using LeetCodeDaily.Core;

namespace _3314.Construct_the_Minimum_Bitwise_Array_I;

public class Solution
{
    [ResultGenerator]
    public int[] MinBitwiseArray(IList<int> nums)
    {
        /* Brute force approach for analysis:

        	for (int i = 2; i <= 1000; i++)
		    {
			    bool found = false;
			
			    for (int j = 0; j < i; j++)
			    {
				    if ((j | (j + 1)) == i)
				    {
					    found = true;
					    Console.WriteLine(
                            $"{i} : {Convert.ToString(i, 2).PadLeft(32)}" + 
                            $" : {Convert.ToString(j, 2).PadLeft(32)}" +
                            $" - diff: {i - j}");
					    break;
				    }
				
			    }
			
			    if (found == false)
		        {
				
			    }
			
		    }

        */

        // When brute-forcing the solution and checking the results, I've noticed a few things:
        //     1. There can not be a solution for even numbers
        //     2. There is a solution for every odd number
        //     3. There is a clear pattern for the solution. 
        //        When iterating the bits from least significant to most significant,
        //        the result always has the last bit in a contiguous sequence of '1's set to '0'.
        //        So, for instance:
        //        Input     3:         11    -    Result     1:         1    -   flip bit 2     (first zero at bit 3)
        //        Input     5:        101    -    Result     4:       100    -   flip bit 1     (first zero at bit 2)
        //        Input     7:        111    -    Result     3:        11    -   flip bit 3     (first zero at bit 4)
        //        Input     9:       1001    -    Result     8:      1000    -   flip bit 1     (first zero at bit 2)
        //        Input    11 :      1011    -    Result     9:      1001    -   flip bit 2     (first zero at bit 3)
        //        Input    13 :      1101    -    Result    12:      1100    -   flip bit 1     (first zero at bit 2)
        //        Input    15 :      1111    -    Result     7:       111    -   flip bit 4     (first zero at bit 5)
        //        Input    17 :     10001    -    Result    16:     10000    -   flip bit 1     (first zero at bit 2)
        //        Input    19 :     10011    -    Result    17:     10001    -   flip bit 2     (first zero at bit 3)
        //        Input    21 :     10101    -    Result    20:     10100    -   flip bit 1     (first zero at bit 2)
        //        Input    23 :     10111    -    Result    19:     10011    -   flip bit 3     (first zero at bit 4)
        //        Input    25 :     11001    -    Result    24:     11000    -   flip bit 1     (first zero at bit 2)
        //        Input    27 :     11011    -    Result    25:     11001    -   flip bit 2     (first zero at bit 3)
        //        Input    29 :     11101    -    Result    28:     11100    -   flip bit 1     (first zero at bit 2)
        //        Input    31 :     11111    -    Result    15:      1111    -   flip bit 5     (first zero at bit 6)
        //        Input    33 :    100001    -    Result    32:    100000    -   flip bit 1     (first zero at bit 2)

        int n = nums.Count;
        int[] result = new int[n];

        for (int i = 0; i < n; i++)
        {
            // even number? -> no solution -> -1
            if ((nums[i] & 1) == 0)
            {
                result[i] = -1;
                continue;
            }

            // Odd number? -> search for first zero bit from LSB to MSB
            // -> found first zero? -> set previous bit to zero -> add to resulting array
            int mask = 2;

            for (; mask < 1024; mask <<= 1)
            {
                if ((nums[i] & mask) == 0)
                {
                    result[i] = nums[i] & ~(mask >>> 1);
                    break;
                }
            }
        }

        return result;
    }

    [ResultGenerator(ApproachIndex = 1)]
    public int[] MinBitwiseArrayOtherSolution(IList<int> nums)
    {
        int n = nums.Count;
        int[] result = new int[n];

        for (int i = 0; i < n; i++)
        {
            int currentNum = nums[i];
            if (currentNum == 2)
            {
                result[i] = -1;
            }
            else
            {
                for (int bitPosition = 1; bitPosition < 32; bitPosition++)
                {
                    if ((currentNum >> bitPosition & 1) == 0)
                    {
                        result[i] = currentNum ^ (1 << (bitPosition - 1));
                        break;
                    }
                }
            }
        }

        return result;
    }

    static int[] lookup = new int[1000];

    static Solution()
    {
        lookup[2] = -1;
        lookup[3] = 1;
        lookup[5] = 4;
        lookup[7] = 3;
        lookup[11] = 9;
        lookup[13] = 12;
        lookup[17] = 16;
        lookup[19] = 17;
        lookup[23] = 19;
        lookup[29] = 28;
        lookup[31] = 15;
        lookup[37] = 36;
        lookup[41] = 40;
        lookup[43] = 41;
        lookup[47] = 39;
        lookup[53] = 52;
        lookup[59] = 57;
        lookup[61] = 60;
        lookup[67] = 65;
        lookup[71] = 67;
        lookup[73] = 72;
        lookup[79] = 71;
        lookup[83] = 81;
        lookup[89] = 88;
        lookup[97] = 96;
        lookup[101] = 100;
        lookup[103] = 99;
        lookup[107] = 105;
        lookup[109] = 108;
        lookup[113] = 112;
        lookup[127] = 63;
        lookup[131] = 129;
        lookup[137] = 136;
        lookup[139] = 137;
        lookup[149] = 148;
        lookup[151] = 147;
        lookup[157] = 156;
        lookup[163] = 161;
        lookup[167] = 163;
        lookup[173] = 172;
        lookup[179] = 177;
        lookup[181] = 180;
        lookup[191] = 159;
        lookup[193] = 192;
        lookup[197] = 196;
        lookup[199] = 195;
        lookup[211] = 209;
        lookup[223] = 207;
        lookup[227] = 225;
        lookup[229] = 228;
        lookup[233] = 232;
        lookup[239] = 231;
        lookup[241] = 240;
        lookup[251] = 249;
        lookup[257] = 256;
        lookup[263] = 259;
        lookup[269] = 268;
        lookup[271] = 263;
        lookup[277] = 276;
        lookup[281] = 280;
        lookup[283] = 281;
        lookup[293] = 292;
        lookup[307] = 305;
        lookup[311] = 307;
        lookup[313] = 312;
        lookup[317] = 316;
        lookup[331] = 329;
        lookup[337] = 336;
        lookup[347] = 345;
        lookup[349] = 348;
        lookup[353] = 352;
        lookup[359] = 355;
        lookup[367] = 359;
        lookup[373] = 372;
        lookup[379] = 377;
        lookup[383] = 319;
        lookup[389] = 388;
        lookup[397] = 396;
        lookup[401] = 400;
        lookup[409] = 408;
        lookup[419] = 417;
        lookup[421] = 420;
        lookup[431] = 423;
        lookup[433] = 432;
        lookup[439] = 435;
        lookup[443] = 441;
        lookup[449] = 448;
        lookup[457] = 456;
        lookup[461] = 460;
        lookup[463] = 455;
        lookup[467] = 465;
        lookup[479] = 463;
        lookup[487] = 483;
        lookup[491] = 489;
        lookup[499] = 497;
        lookup[503] = 499;
        lookup[509] = 508;
        lookup[521] = 520;
        lookup[523] = 521;
        lookup[541] = 540;
        lookup[547] = 545;
        lookup[557] = 556;
        lookup[563] = 561;
        lookup[569] = 568;
        lookup[571] = 569;
        lookup[577] = 576;
        lookup[587] = 585;
        lookup[593] = 592;
        lookup[599] = 595;
        lookup[601] = 600;
        lookup[607] = 591;
        lookup[613] = 612;
        lookup[617] = 616;
        lookup[619] = 617;
        lookup[631] = 627;
        lookup[641] = 640;
        lookup[643] = 641;
        lookup[647] = 643;
        lookup[653] = 652;
        lookup[659] = 657;
        lookup[661] = 660;
        lookup[673] = 672;
        lookup[677] = 676;
        lookup[683] = 681;
        lookup[691] = 689;
        lookup[701] = 700;
        lookup[709] = 708;
        lookup[719] = 711;
        lookup[727] = 723;
        lookup[733] = 732;
        lookup[739] = 737;
        lookup[743] = 739;
        lookup[751] = 743;
        lookup[757] = 756;
        lookup[761] = 760;
        lookup[769] = 768;
        lookup[773] = 772;
        lookup[787] = 785;
        lookup[797] = 796;
        lookup[809] = 808;
        lookup[811] = 809;
        lookup[821] = 820;
        lookup[823] = 819;
        lookup[827] = 825;
        lookup[829] = 828;
        lookup[839] = 835;
        lookup[853] = 852;
        lookup[857] = 856;
        lookup[859] = 857;
        lookup[863] = 847;
        lookup[877] = 876;
        lookup[881] = 880;
        lookup[883] = 881;
        lookup[887] = 883;
        lookup[907] = 905;
        lookup[911] = 903;
        lookup[919] = 915;
        lookup[929] = 928;
        lookup[937] = 936;
        lookup[941] = 940;
        lookup[947] = 945;
        lookup[953] = 952;
        lookup[967] = 963;
        lookup[971] = 969;
        lookup[977] = 976;
        lookup[983] = 979;
        lookup[991] = 975;
        lookup[997] = 996;
    }

    [ResultGenerator(ApproachIndex = 2)]
    public int[] MinBitwiseArrayLookup(IList<int> nums)
    {
        int n = nums.Count;
        var result = new int[n];

        for (int i = 0; i < n; i++)
        {
            result[i] = lookup[nums[i]];
        }

        return result;
    }
}