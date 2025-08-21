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

        var intArray = new int[] { 58, 44, 27, 10, 100 };
        var strings = "ProgrammerS123";
        var strArr1 = new string[] { "a", "bd", "c" };
        var strArr2 = new string[] { "I", "Love", "Programmers." };

        //Console.WriteLine(sol.Solution08202(intArray, 139));
        // Util.PrintArray(sol.Solution0819(intArray));
        // sol.Solution08122();
        // study.DeleTest();

        // Util.CompareDelegate cmp = Util.AscendingCompare;
        // Util.Sort(intArray, Util.DecendingCompare);
        // Util.PrintArray(intArray);
        study.TestMyArea();
    }
}