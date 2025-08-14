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

        var intArray = new int[] { 5, 2, 1, 7, 5 };
        var strings = "abCdEfghIJ";
        var strArr1 = new string[] { "a", "bd", "c" };
        var strArr2 = new string[] { "I", "Love", "Programmers." };

        Console.WriteLine(sol.Solution08142(strings));
        //Util.PrintArray(sol.Solution0813(intArray, 2));
        //sol.Solution08122();

        Client client = new Client();
        //study.ClassTest();
        //study.GenericSample();

        string str = MyUtility.Convert(123);
        int i = MyUtility.ConvertBack(str);
        //Console.WriteLine($"str : {str}, i : {i}");
        
        // MakeLotto();
    }
}