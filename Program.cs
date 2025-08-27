// Util을 사용하기 위해 필요한 namespace 사용 선언
using Hagoon;
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

        var intArray = new int[] { 1, 2, 0, 0, 3 };
        var intArrs = new int[,] { {0, 4}, {1, 2}, {3, 5}, {7, 7} };
        var strings = "zpiaz";
        var strArr = new string[] { "progressive", "hamburger", "hammer", "ahocorasick" };

        // Console.WriteLine(sol.Solution08272(10));
        Util.PrintArray(sol.Solution08272(25));
        // sol.Solution08122();
        // study.DeleTest();

        // Util.CompareDelegate cmp = Util.AscendingCompare;
        // Util.Sort(intArray, Util.DecendingCompare);
        // Util.PrintArray(intArray);
        // study.TestMyArea();
    }
}