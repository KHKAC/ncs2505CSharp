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

        var intArr = new int[] { 12, 4, 15, 1, 14 };
        var intArr2 = new int[] { 2021, 12, 29 };
        var int2Arrs = new int[,] { { 0, 1, 2 }, { 1, 2, 3 }, { 2, 3, 4 }, { 3, 4, 5 } };
        var boolArr = new bool[] { false, false, false, true, false, false, false };
        var strings = "aaaa";
        var string2 = "aa";
        var strArr = new string[] { "0123456789","9876543210","9999999999999" };

        Console.WriteLine(sol.Solution10272(strings, string2));
        //Util.PrintArray(sol.Solution10232(strArr, 50000, 5, 5));
        //sol.Solution09102(int2Arrs);
        //study.DateTest();

        //Util.CompareDelegate cmp = Util.AscendingCompare;
        //Util.Sort(intArray, Util.DecendingCompare);
    }
}