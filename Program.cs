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
        //sol.Soultion07082(7, 7);
        Console.WriteLine(sol.Soultion07082(11, 11));
        cSharpStudy.DataType();
    }
    
}