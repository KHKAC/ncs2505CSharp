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
        CSharpStudy cSharpStudy = new CSharpStudy();

        var intArray = new int[] { 0, 2, 3, 4 };
        var strings = "nice to meet you";

        var strArr1 = new string[] { "a", "bd", "c" };
        var strArr2 = new string[] { "I", "Love", "Programmers." };

        //Console.WriteLine(sol.Solution07312(intArray, 1));
        //Util.PrintIntArray(sol.Solution07282(strArr1));
        //Util.PrintString(sol.Solution0730(strArr1));


        //cSharpStudy.ExceptionSample();

        MyCustomer mc = new MyCustomer();
        // name, age 값을 넣음(Set함)
        mc.Name = "Kyoung";
        mc.Age = 35;
        //mc.SetAge(-3);
        Console.WriteLine(mc.GetCustomerData());
        Console.WriteLine(mc.CalAge(40));

        // MakeLotto();
    }
}