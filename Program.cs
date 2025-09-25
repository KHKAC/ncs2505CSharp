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

        var intArr = new int[] { -1, 2, 5, 6, 3 };
        var intArr2 = new int[] { 3, 3, 3, 3, 3 };
        var int2Arrs = new int[,] { { 5, 192, 33 }, { 192, 72, 95 }, { 33, 95, 999 } };
        var strings = "AAA";
        var string2 = "ana";
        var strArr = new string[] { "aBc", "AbC" };

        //Console.WriteLine(sol.Solution09252(3, 10));
        Util.PrintArray(sol.Solution09252(7, 11));
        //sol.Solution09102(int2Arrs);
        //study.SimbolTest();

        //Util.CompareDelegate cmp = Util.AscendingCompare;
        //Util.Sort(intArray, Util.DecendingCompare);
    }
}