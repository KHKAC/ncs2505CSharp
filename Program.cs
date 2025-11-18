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

        var intArr = new int[] { 1, 4, 2, 5, 3 };
        var intArr2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var int2Arrs = new int[,] { { 0, 4, 1 }, { 0, 3, 2 }, { 0, 3, 3 } };
        var boolArr = new bool[] { false, false, false, true, false, false, false };
        var string1 = "1001";
        var string2 = "1111";
        var strArr = new string[] { "l" };

        Console.WriteLine(sol.Solution11182(string1, string2));
        //Util.PrintArray(sol.Solution1118(intArr));
        //sol.Solution1111();
        //study.DateTest();

        //Util.CompareDelegate cmp = Util.AscendingCompare;
        //Util.Sort(intArray, Util.DecendingCompare);
    }
}