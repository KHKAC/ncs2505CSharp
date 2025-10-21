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

        var intArr = new int[] { 2021, 12, 28 };
        var intArr2 = new int[] { 2021, 12, 29 };
        var int2Arrs = new int[,] { { 0, 1, 2 }, { 1, 2, 3 }, { 2, 3, 4 }, { 3, 4, 5 } };
        var boolArr = new bool[] { false, false, false, true, false, false, false };
        var strings = "We are the world";
        var string2 = "bbbbb";
        var strArr = new string[] { "nami", "ahri", "jayce", "garen", "ivern", "vex", "jinx" };

        Console.WriteLine(sol.Solution10212(15));
        //Util.PrintArray(sol.Solution10162(strings));
        //sol.Solution09102(int2Arrs);
        //study.DateTest();

        //Util.CompareDelegate cmp = Util.AscendingCompare;
        //Util.Sort(intArray, Util.DecendingCompare);
    }
}