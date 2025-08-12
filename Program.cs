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
        var intArray = new int[] { 10, 20, 30, 5, 5, 20, 5 };
        var strings = "love";
        var strArr1 = new string[] { "a", "bd", "c" };
        var strArr2 = new string[] { "I", "Love", "Programmers." };

        //Console.WriteLine(sol.Solution08112(intArray));
        //Util.PrintIntArray(sol.Solution0811(strings));
        //Util.PrintString(sol.Solution0812(strings, 10));
        sol.Solution08122();

        CSharpStudy study = new CSharpStudy();
        //study.ClassTest();
        //study.PreProTest();
        

        // MakeLotto();
    }
}