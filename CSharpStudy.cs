class CSharpStudy
{
    public void ArrayExample()
    {
        int sum = 0;
        //int[] nums = new int[10] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        int[] nums = new int[10];

        nums[0] = 1;
        nums[1] = 2;
        //
        nums[9] = 0;
        //배열 넘어가면 안 된다...큰일난다...
        //nums[10] = 11;

        Random rand = new Random();
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = rand.Next() % 100;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            Console.WriteLine($"No.{i} = " + nums[i]);
            sum += nums[i];
        }

        Console.WriteLine("sum = " + sum);
    }

    /// <summary>
    /// 데이터 타입
    /// </summary>
    public void DataType()
    {
        //bool
        bool b = true;

        //
        short sh = -32768;
        int i = 2147483647;
        long l = 1234L;
        float f = 123.85f;
        double d1 = 123.45;
        double d2 = 123.45D;
        decimal d = 123.45M;

        Console.WriteLine(f);
        i = (int)f;
        Console.WriteLine(i);
        char c = 'A';
        string s = "Hello, World!";
        string s2 = null;
        string s3 = "";
        string s4 = string.Empty;
        //int ii = null;

        DateTime dt = new DateTime(2025, 7, 9, 11, 16, 00);

        //int는 MaxValue로 최대값 바로 호출 가능
        if (i > int.MaxValue)
        {

        }

    }

}