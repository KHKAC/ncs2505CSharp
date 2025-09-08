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

        var intArr = new int[] { 110, 66, 439, 785, 1 };
        var intArr2 = new int[] { 377, 823, 119, 43 };
        var int2Arrs = new int[,] { { 0, 4 }, { 1, 2 }, { 3, 5 }, { 7, 7 } };
        var strings = "c";
        var string2 = "AABB";
        var strArr = new string[] { "abc", "bbc", "cbc" };

        Console.WriteLine(sol.Solution09082(strArr, strings));
        //Util.PrintArray(sol.Solution0908(intArr, intArr2));
        //sol.Solution09012();
        //study.RegexSample2();

        //Util.CompareDelegate cmp = Util.AscendingCompare;
        //Util.Sort(intArray, Util.DecendingCompare);
    }
}