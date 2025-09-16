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

        var intArr = new int[] { 444, 555, 666, 777 };
        var intArr2 = new int[] { 377, 823, 119, 43 };
        var int2Arrs = new int[,] { { 5, 192, 33 }, { 192, 72, 95 }, { 33, 95, 999 } };
        var strings = "8542";
        var string2 = "ana";
        var strArr = new string[] { "abc", "bbc", "cbc" };

        //Console.WriteLine(sol.Solution0915(strings));
        Util.PrintArray(sol.Solution09162(intArr, 100));
        //sol.Solution09102(int2Arrs);
        //study.OutSample();

        //Util.CompareDelegate cmp = Util.AscendingCompare;
        //Util.Sort(intArray, Util.DecendingCompare);
    }
}