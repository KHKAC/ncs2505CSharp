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
        //cSharpStudy.ListSample();
        //Console.WriteLine(sol.Soultion07112(4));
        MakeLotto();
    }

    /// <summary>
    /// 로또 번호 만들기 (나중에 필요하니 삭제 X)
    /// </summary>
    public static void MakeLotto()
    {
        //랜덤 함수 선언 필요
        var random = new Random();
        //볼이 담긴 리스트 선언
        var ballList = new List<int>();
        //리스트에 볼 45개 넣기
        for (int i = 1; i <= 45; i++)
        {
            ballList.Add(i);
        }
        //리스트에서 볼을 하나씩 6번 꺼내기
        for (int i = 0; i < 6; i++)
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