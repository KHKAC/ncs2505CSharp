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

        var intArr = new int[] { 4, 2, 6, 1, 7, 6 };
        var intArr2 = new int[] { 3, 3, 3, 3, 3 };
        var int2Arrs = new int[,] { { 1, 3 }, { 0, 4 } };
        var boolArr = new bool[] { true, false, true, false };
        var strings = "abstract algebra";
        var string2 = "abanana";
        var strArr = new string[] { "nami", "ahri", "jayce", "garen", "ivern", "vex", "jinx" };

        Console.WriteLine(sol.Solution10142(6));
        //Util.PrintArray(sol.Solution10132(strArr));
        //sol.Solution09102(int2Arrs);
        //study.DateTest();

        //Util.CompareDelegate cmp = Util.AscendingCompare;
        //Util.Sort(intArray, Util.DecendingCompare);
    }
}