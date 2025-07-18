using System.Collections;
using System.Text;

class CSharpStudy
{
    public void SBSample()
    {
        var sb = new StringBuilder();
        for (int i = 1; i <= 26; i++)
        {
            sb.Append(i.ToString());
            //sb.Append(System.Environment.NewLine);
            sb.Append(' ');
        }
        string s = sb.ToString();
        Console.WriteLine($"Result : {s}");
        //Environment.NewLine으로 줄 바꿈한것도 StringBuilder에 포함
        //StringBuilder를 사용할 때 .ToString(); 사용을 까먹지 말 것!!!

        sb.Clear(); //sb 안에 있는 것들 초기화(=비워버림)
        sb.Append((char)('A' + 3));
        Console.WriteLine(sb.ToString());
    }

    public void ASCIISample()
    {
        string s = "C# Studies";
        for (int i = 0; i < s.Length; i++)
        {
            // Console.WriteLine("{1} : {0}", i, s[i]);
        }

        string str = "Hello";
        char[] charArray = str.ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            // Console.WriteLine("{0} : {1}", i, charArray[i]);
        }

        char[] charArray2 = { 'A', 'B', 'C', 'D' };
        string s2 = new string(charArray2);
        // Console.WriteLine(s2);

        //문자 연산
        char c1 = 'Z'; // 10진수로 표현 가능하다.
        char c2 = (char)(c1 - 9);
        Console.WriteLine(c2);
    }

    public void StringSample()
    {
        //string 변수
        string s1 = "C#";
        string s2 = "Programming";
        int startIndex = 3;
        int len = s2.Length - startIndex - 1;

        string s3 = s2.Substring(3, len);
        Console.WriteLine(s3);

        //문자(chat) 변수
        char c1 = 'A';
        char c2 = 'B';
        char c3 = '\0'; // = null

        string s4 = s1 + " " + s2;
        Console.WriteLine("String : {0}", s4);

        string s4Sub = s4.Substring(1, 5);
        Console.WriteLine("SubString : {0}", s4Sub);
        //ASCII 코드 알아두면 좋은 정도 따로 외울 필요 없음.
    }

    #region
    //var는 전역변수로는 쓸 수 없다. 오직 지역변수로만 가능
    public void ArrraySample()
    {
        // 1차 배열
        var players = new string[10];
        string[] regions = { "서울", "경기,", "부산" };

        // 2차원 배열
        string[,] depts = { { "김과장", "경리부" }, { "이과장", "총리부" } };

        // 3차원 배열 <- 사람이 이해할 수 있는 마지노선
        string[,,] cubes;

        // 가변 배열
        int[,] aa = new int[3, 2]; // 앞,뒤 전부 크기 지정해야함 (2차 배열)
        int[][] a = new int[3][]; // 앞만 크기 지정해야함, 뒤는 크기 지정하면 안 됨(가변 배열)
        a[0] = new int[2];
        a[1] = new int[3] { 1, 2, 3 };
        a[2] = new int[4] { 1, 2, 3, 4 };
        a[0][0] = 1;
        a[0][1] = 2;
        aa[0, 0] = 1;
        aa[0, 1] = 3;
        // aa[0, 3] = 2; <- OutOfRange 오류 발생
        aa[2, 1] = 7;

        int sum = 0;
        int[] scores = { 80, 78, 60, 90, 100 };
        for (int i = 0; i < scores.Length; i++)
        {
            sum += scores[i];
        }
        // Console.WriteLine("sum = " + sum);
        // Console.WriteLine("sum = {0}", sum);
        Console.WriteLine($"sum = {sum}");
    }

    public void SortedDicSample()
    {
        var tMap = new SortedDictionary<int, string>();
        tMap.Add(1001, "Tom");
        tMap.Add(1003, "John");
        tMap.Add(1010, "Irina");
        tMap.Add(1005, "Lee");

        string name101 = tMap[1010];
        // Iterator 사용
        foreach (KeyValuePair<int, string> kv in tMap)
        {
            Console.WriteLine("{2}{0} : {1}", kv.Key, kv.Value, "*");
        }
    }

    public void HashTableSample()
    {
        // Hashtable ht = new Hashtable();
        // ht.Add("irina", "Irina SP");
        // ht.Add("tom", "Tom Cr");
        // ht.Add(3, 'a');

        // if (ht.Contains("tom"))
        // {
        //     Console.WriteLine(ht[tom]);
        // }

        //Dictionary<int, string> emp = new Dictionary<int, string>();
        var emp = new Dictionary<int, string>();
        emp.Add(1001, "Jane");
        //emp.Add(1002, "Tom");
        emp.Add(1003, "Cindy");
        if (emp.ContainsKey(1002) == false)
        {
            emp.Add(1002, "Kim");
        }

        string name = emp[1002];
        Console.WriteLine(name);
    }

    public void StackQueueSample()
    {
        //Stack<float> s = new Stack<float>();
        var s = new Stack<float>();
        s.Push(10.5f);
        s.Push(3.54f);
        s.Push(4.22f);

        float pp = s.Peek(); // Stack의 Pop했을 때의 값을 제거하지 않고 미리 보여줌.
        Console.WriteLine("pp : " + pp);

        float p3 = s.Pop();
        Console.WriteLine("p3 : " + p3);

        float p4 = s.Pop();
        Console.WriteLine("p4 : " + p4);

        var q = new Queue<int>();
        q.Enqueue(120);
        q.Enqueue(130);
        q.Enqueue(150);

        int qq = q.Peek();
        Console.WriteLine("qq : " + qq);
        int next = q.Dequeue();
        Console.WriteLine("next : " + next);
        next = q.Dequeue();
        Console.WriteLine("next : " + next);
    }

    public void LinkedListSample()
    {
        // int a = 1, b = 2; -> 가능
        // var va = 1, va = 2; -> var는 한 줄에 하나만 정의 가능
        // LinkedList<string> list = new LinkedList<string>();
        var list = new LinkedList<string>();
        list.AddLast("Apple");
        list.AddLast("Banana");
        list.AddLast("Lemon");

        //LinkedListNode<string> node = list.Find("Banana");
        var node = list.Find("Banana");
        //LinkedListNode<string> newNode = new LinkedListNode<string>("Grape");
        var newNode = new LinkedListNode<string>("Grape");

        list.AddAfter(node, newNode);
        list.AddAfter(node, "Kiwi");

        list.ToList<string>().ForEach(p => Console.WriteLine(p));
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
    }

    public void ListSample()
    {
        //List<int> myList = new List<int>();
        var myList = new List<int>();
        myList.Add(90);
        myList.Add(88);
        myList.Add(75);

        int val = myList[1];

        var chrList = new List<char>();
        chrList.Add('b');
        chrList.Add('c');

        var boolList = new List<bool>();
        boolList.Add(false);

        var intArray = new int[100];
        intArray[2] = 10;
        myList.Add(10);
        Console.WriteLine(intArray.Length);
        Console.WriteLine(myList.Count);

        //리스트 정렬
        myList.Sort();
    }

    public void ArrrayListSample()
    {
        //ArrayList myList = new ArrayList();
        var myList = new ArrayList();
        var yourList = true;

        myList.Add(90);
        myList.Add(88);
        myList.Add(75);

        int val = (int)myList[1];
        //Console.WriteLine(val);
        //Console.WriteLine((int)myList[0]);
    }

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
#endregion
}