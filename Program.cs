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
        var intArray = new int[] { 10, 8, 6 };
        var strings = "abcde0";
        var strArr1 = new string[] { "a", "bd", "c" };
        var strArr2 = new string[] { "I", "Love", "Programmers." };

        //Console.WriteLine(sol.Solution0808(intArray, 3));
        Util.PrintIntArray(sol.Solution08082(strings));
        //Util.PrintString(sol.Solution08072(strings));

        CSharpStudy study = new CSharpStudy();
        //study.PreProTest();
        // CSharpStudy.MyClass cls = new CSharpStudy.MyClass();
        // cls[1] = 1024;
        // int i = cls[1];
        // Console.WriteLine(i);
        // cls.SetData(3, 100);
        // int i2 = cls.GetData(3);
        // Console.WriteLine(i2);

        // MakeLotto();
    }
}