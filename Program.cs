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

        var intArray = new int[] { 5, 2, 1, 7, 5 };
        var int2Arrs = new int[,] { { 0, 4 }, { 1, 2 }, { 3, 5 }, { 7, 7 } };
        var strings = "wsdawsdassw";
        var strArr = new string[] { "progressive", "hamburger", "hammer", "ahocorasick" };

        //Console.WriteLine(sol.Solution08292(4, 4, 4));
        //Util.PrintArray(sol.Solution0829(intArray));
        sol.Solution09012();
        //study.ExtensionTest();

        //Util.CompareDelegate cmp = Util.AscendingCompare;
        //Util.Sort(intArray, Util.DecendingCompare);
    }
}