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

        var intArr = new int[] { 1, 2 };
        var intArr2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var int2Arrs = new int[,] { { 572, 22, 37 }, { 287, 726, 384 }, { 85, 137, 292 }, {487, 13, 876} };
        var boolArr = new bool[] { false, false, false, true, false, false, false };
        var string1 = "Program29b8UYP";
        var string2 = "merS123";
        var strArr1 = new string[] { "s", "o", "m", "d" };
        var strArr2 = new string[] { "moos", "dzx", "smm", "sunmmo", "som" };

        //Console.WriteLine(sol.Solution1128(strArr1, strArr2));
        //Util.PrintArray(sol.Solution11282(int2Arrs)); // 배열 2차원 이상의 배열을 출력 불가
        //sol.Solution1126();
        //study.DateTest();

        //Util.CompareDelegate cmp = Util.AscendingCompare;
        //Util.Sort(intArray, Util.DecendingCompare);
    }
}