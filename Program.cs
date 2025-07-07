internal class Program
{
    /// <summary>
    /// 메인 함수
    /// </summary>
    /// <param name="args"></param>
    private static void Main(string[] args)
    {
        // 문제풀이 250704
        // Console.WriteLine(Soultion0704(3, 2));

        // 문제풀이 250707
        // Console.WriteLine(Soultion0707(100, 2));
        Console.WriteLine(Soultion07072(27, 19));
    }

    
    /// <summary>
    /// 두 수의 곱 구하기
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public static int Soultion07072(int num1, int num2)
    {
        int answer = num1 * num2;
        return answer;
    }

    /// <summary>
    /// 두 수의 차 구하기
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public static int Soultion0707(int num1, int num2)
    {
        int answer = num1 - num2;
        return answer;
    }

    /// <summary>
    /// 나머지 구하기
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public static int Soultion0704(int num1, int num2)
    {
        int answer = num1 % num2;
        return answer;
    }
}