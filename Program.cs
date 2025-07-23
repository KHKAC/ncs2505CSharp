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

        var intArray = new int[] { 1, 2, 3, 4, 5 };
        var strings = "nice to meet you";

        Console.WriteLine(sol.Solution07232(7, 7));
        //PrintIntArray(sol.Solution0723(intArray, 1, 3));
        //PrintString(sol.Solultion07162(strings));

        //cSharpStudy.ConditionSample();
        // MakeLotto();
    }

    /// <summary>
    /// 정수 배열의 합을 구하는 함수
    /// </summary>
    /// <param name="scoreArray"></param>
    /// <returns></returns>
    public static int CalculateSum(int[] scoreArray) //배열 받는쪽 
    {
        int sum = 0;
        for (int i = 0; i < scoreArray.Length; i++)
        {
            sum += scoreArray[i];
        }
        return sum;
    }

    public static void PrintString(string strings)
    {
        Console.Write("[ ");
        for (int i = 0; i < strings.Length; i++)
        {
            Console.Write(strings[i]);
            // if (i != strings.Length - 1)
            // {
            //     Console.Write(", ");
            // }
        }
        Console.Write(" ]");
    }

    /// <summary>
    /// 정수 배열을 출력시키는 함수
    /// </summary>
    /// <param name="answerArray"></param>
    public static void PrintIntArray(int[] answerArray)
    {
        Console.Write("[ ");
        for (int i = 0; i < answerArray.Length; i++)
        {
            Console.Write(answerArray[i]);
            if (i != answerArray.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.Write(" ]");
    }

    /// <summary>
    /// 로또 번호 만들기 (나중에 필요하니 삭제 X)
    /// </summary>
    public static void MakeLotto()
    {
        //상수
        const int TOTAL_BALLS = 45; //전체 공 개수
        const int PICK_BALLS = 6; // 뽑는 공 개수

        //랜덤 함수 선언 필요
        var random = new Random();
        //볼이 담긴 리스트 선언
        var ballList = new List<int>();
        //리스트에 볼 45개 넣기
        for (int i = 1; i <= TOTAL_BALLS; i++)
        {
            ballList.Add(i);
        }
        //리스트에서 볼을 하나씩 6번 꺼내기
        for (int i = 0; i < PICK_BALLS; i++)
        {
            //남아있는 볼 갯수 중 랜덤하게 인덱스 고르기
            int index = random.Next() % ballList.Count;
            //[인덱스]와 볼 번호 출력
            Console.Write("[" + index + "] ");
            Console.WriteLine(ballList[index]);
            //인덱스에 있는 볼을 리스트에서 지우기
            ballList.RemoveAt(index);
        }
    }
}