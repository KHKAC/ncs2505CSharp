// Util을 사용하기 위해 필요한 namespace 사용 선언
using Hagoon;
internal class Program
{
    /// <summary>
    /// 메인 함수
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        ProgramSolution sol = new ProgramSolution();
        CSharpStudy study = new CSharpStudy();

        var intArray = new int[] { 9, -1, 0 };
        var strings = "nice to meet you";

        var strArr1 = new string[] { "a", "bd", "c" };
        var strArr2 = new string[] { "I", "Love", "Programmers." };

        //Console.WriteLine(sol.Solution08042(580000));
        //Util.PrintIntArray(sol.Solution0804(15));
        //Util.PrintString(sol.Solution0730(strArr1));

        study.ParamSample();
        
        // MakeLotto();
    }
}