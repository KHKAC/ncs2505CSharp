// Util, 확장 메서드 사용하기 위해 필요한 namespace 사용 선언
using Hagoon; // Util
using MyExtension; // 확장메서드

internal class Program // internal폴더(Assembly) 내에 있는 파일(class)들이 접근할 수 있게 만드는 것
{
    /// <summary>
    /// 메인 함수
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        ProgramSolution sol = new ProgramSolution();
        CSharpStudy study = new CSharpStudy();

        var intArr = new int[] { 2, 4, 8 };
        var intArr2 = new int[] { 4, 1, 2 };
        var int2Arrs = new int[,] { { 0, 1 }, { 2, 5 }, { 3, 9 } };
        var boolArr = new bool[] { false, false, false, true, false, false, false };
        var string1 = "027778888";
        var string2 = "pleap";
        var strArr1 = new string[] { "19 - 6 = 13", "5 + 66 = 71", "5 - 15 = 63", "3 - 1 = 2" };
        var strArr2 = new string[] { "moos", "dzx", "smm", "sunmmo", "som" };
        var str2Arr = new string[,] {{"programmer02", "111111"}, {"programmer00", "134"}, {"programmer01", "1145"}};

        Console.WriteLine(sol.Solution12182(int2Arrs));
        //Util.PrintArray(sol.Solution12122(5, 5)); // 배열 2차원 이상의 배열을 출력 불가
        //sol.Solution1202();
        //study.DateTest();

        //Util.CompareDelegate cmp = Util.AscendingCompare;
        //Util.Sort(intArray, Util.DecendingCompare);
    }
}