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
        CSharpStudy cSharpStudy = new CSharpStudy();

        var intArray = new int[] { 2, 100, 120, 600, 12, 12 };
        var strings = "nice to meet you";

        var strArr1 = new string[] { "a","bd","c" };
        var strArr2 = new string[] { "I", "Love", "Programmers." };

        Console.WriteLine(sol.Solution07302(169));
        //Util.PrintIntArray(sol.Solution07282(strArr1));
        //Util.PrintString(sol.Solution0730(strArr1));

        //cSharpStudy.ExceptionSample();

        // MakeLotto();
    }
}