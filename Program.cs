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

        var intArr = new int[] { 3, 7, 2, 5, 4, 6, 1 };
        var intArr2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var int2Arrs = new int[,] { { 80, 70 }, { 90, 50 }, { 40, 70 }, { 50, 80 } };
        var boolArr = new bool[] { false, false, false, true, false, false, false };
        var string1 = "apple";
        var string2 = "pleap";
        var strArr1 = new string[] { "programmer01", "15789" };
        var strArr2 = new string[] { "moos", "dzx", "smm", "sunmmo", "som" };
        var str2Arr = new string[,] {{"programmer02", "111111"}, {"programmer00", "134"}, {"programmer01", "1145"}};

        Console.WriteLine(sol.Solution12042(string1, string2));
        //Util.PrintArray(sol.Solution12032(int2Arrs)); // 배열 2차원 이상의 배열을 출력 불가
        //sol.Solution1202();
        //study.DateTest();

        //Util.CompareDelegate cmp = Util.AscendingCompare;
        //Util.Sort(intArray, Util.DecendingCompare);
    }
}