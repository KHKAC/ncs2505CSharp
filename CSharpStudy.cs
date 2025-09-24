#define TEST_ENV
//#define PROD_ENV
using System.Collections;
using System.Text;
using Hagoon;
using MyExtension;
// Forms를 사용하려면 csproj에 <ItemGroup> 추가해야함
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Data.Common;

class CSharpStudy
{
    #region LINQ 강의
    public class Orders
    {
        public int Order_ID { get; set; }
        public string Customer_ID { get; set; }
        public string Ship_City { get; set; }
        public DateTime Order_Date { get; set; }
    }
    public void LINQSample()
    {
        var db = new List<Orders>
        {
            new Orders{Order_ID = 3, Customer_ID = "FRANS", Ship_City = "Seoul", Order_Date = new DateTime(2025, 9, 24)},
            new Orders{Order_ID = 1, Customer_ID = "KYOUNG", Ship_City = "GwangJu", Order_Date = new DateTime(2025, 11, 22)},
            new Orders{Order_ID = 2, Customer_ID = "FRANS", Ship_City = "BuSan", Order_Date = new DateTime(2025, 6, 25)}
        };

        // 쿼리식 표현
        // var fransOrders = from ord in db
        //                   where ord.Customer_ID == "FRANS"
        //                   orderby ord.Order_Date ascending
        //                   select ord;
        //   select new
        //   {
        //     Id = ord.Order_ID,
        //     City = ord.Ship_City.ToLower()
        //   };

        // 메서드식 표현
        var fo = db.Where(order => order.Customer_ID == "FRANS");//.Select(o => o)
        foreach (var o in fo)
        {
            //Console.WriteLine($"{o.Order_ID} : {o.Order_Date}");
            //Console.WriteLine($"{o.Id} : {o.City}");
        }
        //var v = db.Where(o => o.Ship_City == "Seoul").SingleOrDefault();
        //var v = db.Where(o => o.Customer_ID == "FRANS").FirstOrDefault();
        //var v = db.Where(o => o.Customer_ID == "FRANS").OrderBy(m => m.Order_ID);
        var v = db.Where(o => o.Customer_ID == "FRANS").Select(p => new
        {
            Id = p.Order_ID,
            City = p.Ship_City.ToLower(),
        });
        if (v != null)
        {
            //Console.WriteLine($"{v.Order_Date}");
            foreach (var o in v)
            {
                //Console.WriteLine($"{o.Order_ID} : {o.Order_Date}");
                Console.WriteLine($"{o.Id} : {o.City}");
            }
        }

    }
    #endregion

    #region C# 7.0 편해진 out
    public void OutSample()
    {
        // int x, y;
        // GetData(0, 1, out x, out y);
        // GetData(0, 1, out int x, out int y);
        GetData(0, 1, out var x, out var y);
        GetData(0, 1, out var z, out _);
        Console.WriteLine($"{x}, {y}, {z}");
    }

    #endregion
    #region C# 7.0 tuple 강의
    (int count, int sum, double average) Calculate(List<int> data)
    {
        int cnt = 0, sum = 0;
        double avg = 0;
        foreach (var item in data)
        {
            cnt++;
            sum += item;
        }
        avg = sum / cnt;
        return (cnt, sum, avg);
    }

    public void TupleTest()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
        //var r = Calculate(list);
        //Console.WriteLine($"{r.count}, {r.sum}, {r.average}");
        //Console.WriteLine($"{r.Item1}, {r.Item2}, {r.Item3}");

        //(int cnt, int sum, double avg) = Calculate(list);
        //(var cnt, var sum, var avg) = Calculate(list);
        //var(cnt, sum, avg) = Calculate(list);
        int cnt, sum;
        double avg;
        (cnt, sum, avg) = Calculate(list);
        Console.WriteLine($"cnt = {cnt}, sum = {sum}");
        (cnt, sum) = (sum, cnt);
        Console.WriteLine($"cnt = {cnt}, sum = {sum}");
        
    }
    #endregion

    #region C# 7.0 Expression-bodied
    class Employee
    {
        int id;
        string[] tags = new string[10];

        // Expression-bodied 생성자
        public Employee(int id) => this.id = id;
        // 원래 생성자
        // public Employee(int id)
        // {
        //     this.id = id;
        // }

        // Expression-bodied Finalizer(소멸자 : 솔직히 정말로 드물게 쓰임)
        ~Employee() => Console.Write("~Employee");
        // 원래 소멸자
        // ~Employee()
        // {
        //     Console.Write("~Employee");
        // }

        // Expression-bodied property
        public int Id
        {
            get => this.id;
            set => this.id = value > 0 ? value : 0;
        }
        // 원래 property(속성)
        // public int Id
        // {
        //     get
        //     {
        //         return id;
        //     }
        //     set
        //     {
        //         this.id = value > 0 ? value : 0;
        //     }
        // }

        // Expression-bodied indexer
        public string this[int index]
        {
            get => tags[index];
            set => tags[index] = value;
        }
        // 원래 indexer
        // public string this[int index]
        // {
        //     get
        //     {
        //         return tags[index];
        //     }
        //     set
        //     {
        //         tags[index] = value;
        //     }
        // }

        // Expression-bodied event
        EventHandler notified;
        public event EventHandler Notified
        {
            add => notified += value;
            remove => notified -= value;
        }

    }
    #endregion

    #region C# 6.0 Expression-bodied
    class Person
    {
        // 원래 Property 만드는 방식
        // public string Name
        // {
        //     get
        //     {
        //         return Name;
        //     }
        //     set
        //     {
        //         Name = value;
        //     }
        // }
        // 간략화
        // public string Name { get; set; }
        // 초기값 추가 가능해짐
        public string Name { get; set; } = "No name";
        public string NickName { get; }
        public int Age { get; }
        // public bool Enabled { get; } = true;
        public bool Enabled => true;
        public int Level { get; }
        public Person()
        {
            this.Level = 1;
        }

        int height = 3;
        int width = 2;

        // public int Area
        // {
        //     get
        //     {
        //         return height * width;
        //     }
        // }
        public int Area => height * width;
        string strData = "EBM";
        // public void Print()
        // {
        //     Console.WriteLine(strData);
        // }
        public void Print() => Console.WriteLine(strData);
        int salary;
        /*
        public int Salary
        {
            get
            {
                // if (salary < 0) salary = 0;
                // return salary;
                return salary < 0 ? 0 : salary;
            }
        }
        */
        public int Salary => salary < 0 ? 0 : salary;
    }

    public void AutoPropertyInit()
    {
        Person p = new Person();
        // Console.WriteLine(p.Name);
        // Console.WriteLine(p.NickName);
        // Console.WriteLine(p.Enabled);
        // Console.WriteLine(p.Level);
        // Console.WriteLine(p.Age);
        Console.WriteLine(p.Area);
        p.Print();
    }
    #endregion

    #region Dictionary 초기자 강의
    public void DicInit()
    {
        var score1 = new Dictionary<string, int>()
        {
            {"Kim", 100},
            {"Lee", 90}
        };
        int sc = score1["Lee"];

        var score2 = new Dictionary<string, int>()
        {
            ["Kim"] = 100,
            ["Lee"] = 90
        };
        int sc2 = score2["Lee"];

        var A = new[] { 1, 2, 3 };
        var L = new List<int>(A) { [2] = 9 }; // Dictionary Initialize를 사용해서 만듦.
        Console.WriteLine($"{L[0]}, {L[2]}");
        var K = new List<int>() { [0] = 1 }; // 에러 발생
        Console.WriteLine($"{K[0]}");
    }
    #endregion

    #region null(널) 조건 연산자
    public EventHandler Clicked;
    public void Click1()
    {
        var tempClicked = Clicked;
        if (tempClicked != null)
            tempClicked(this, null);

    }
    public void Click2() => Clicked?.Invoke(this, null);
    // {
    //     Clicked?.Invoke(this, null);
    // }
    
    public void NullSample()
    {
        var rows = new List<int>();
        int? cnt = rows?.Count;
        // int cnt2;
        // if (rows == null)
        // {
        //     cnt = 0;
        // }
        // else
        // {
        //     cnt2 = rows.Count;
        // }
        int cnt2 = rows?.Count ?? 0; //위의 주석의 식을 줄여서 쓰면 나오는 식
        int? cnt3 = rows?.Count ?? null;
    }
    #endregion
    #region Regex 클래스 강의
    public void RegexSample2()
    {
        string pn = "010-1234-5555";
        Regex regex1 = new Regex(@"^01[01678]-[0-9]{4}-[0-9]{4}$");
        if (regex1.IsMatch(pn))
        {
            Console.WriteLine("Match");
        }
        else
        {
            Console.WriteLine("Mismatch");
        }

        string name = "김공돌";
        regex1 = new Regex(@"^[가-힣]{3}$");
        if (regex1.IsMatch(name))
        {
            Console.WriteLine("Match");
        }
        else
        {
            Console.WriteLine("Mismatch");
        }
    }
    public void RegexSample()
    {
        string str = "서울시 강남구 역삼동 강남아파트";
        Regex regex = new Regex("강남");
        // Match m = regex.Match(str);
        MatchCollection mc = regex.Matches(str);
        // if (m.Success)
        // {
        //     Console.WriteLine($"{m.Index}: {m.Value}");
        // }
        // while (m.Success)
        // {
        //     Console.WriteLine($"{m.Index}: {m.Value}");
        //     m = m.NextMatch();
        // }
        foreach (Match m in mc)
        {
            Console.WriteLine($"{m.Index}: {m.Value}");
        }
    }
    #endregion

    #region Partial 클래스 강의
    public void PartialTest()
    {
        Class1 c1 = new Class1();
        c1.Get();
        c1.Put();
        c1.Run();

        Struct1 s1 = new Struct1(1912, "Kyoung");
        Console.WriteLine($"{s1.ID} : {s1.Name}");
    }
    #endregion

    #region 확장 메서드 강의 2
    public void ExTest2()
    {
        var nums = new List<int> { 55, 44, 33, 66, 11 };
        var v = nums.Where(p => p % 3 == 0);
        List<int> arr = v.ToList<int>();
        arr.ForEach(n => Console.WriteLine(n));
    }
    #endregion

    #region  확장 메서드 강의 1
    public void ExtensionTest()
    {
        string s = "This is a Test";
        string s2 = s.ToChangeCase();
        bool found = s.Found('z');
        Console.WriteLine($"{s2}, found: {found}");
    }
    #endregion

    #region 익명 타입 강의
    public void AnoTypeTest()
    {
        var v = new[] {
            new { Name = "Lee", Age = 33, Phone = "02-111-1111" },
            new { Name = "Kim", Age = 25, Phone = "02-222-2222" },
            new { Name = "Park", Age = 37, Phone = "02-333-3333" }
        };
        // LINQ Select를 이용해 name과 age만 갖는 새 익명 타입 객체들을 리턴
        var list = v.Where(x => x.Age >= 30).Select(x => new { x.Name, x.Age });
        foreach (var item in list)
        {
            Console.WriteLine($"{item.Name} : {item.Age}");
        }
    }
    #endregion

    #region 델리게이트 강의 3 + 무명 메서드 강의 + 람다식 강의
    class MyArea : Form // Form 클래스는 using System.Windows.Forms; 가 필요
    {
        // 무명 메서드
        delegate void MyDelegate(int a);
        public void AnoTest()
        {
            // var de = delegate (int p1) { Console.Write(p1); };
            // delegate 원래 사용법
            MyDelegate dd = new MyDelegate(AnoMethod);
            void AnoMethod(int p1)
            {
                Console.Write(p1);
            }
            // 무명 메서드로 간략화
            MyDelegate d = delegate (int p1)
            {
                Console.Write(p1);
            };
            d(100);
        }
        public MyArea()
        {
            // this.MouseClick += delegate { MyAreaClicked(); }; // <- 무명 메서드 사용
            // 람다식 강의
            this.MouseClick += (s, e) => MyAreaClicked();
        }

        public delegate void ClickDelegate(object sender);
        // delegate field => event field
        public event ClickDelegate MyClick; // delegate형태 public ClickDelegate MyClick;
        void MyAreaClicked()
        {
            if (MyClick != null)
            {
                MyClick(this);
            }
        }
    }

    MyArea area;
    public void TestMyArea()
    {
        area = new MyArea();
        area.MyClick += Area_Click;
        area.MyClick += After_Click;
        area.MyClick -= Area_Click;

        // event일 때는 사용 불가
        // area.MyClick = Area_Click;
        // area.MyClick = null;
        area.ShowDialog();

        // 무명 메서드
        area.Click += new EventHandler(delegate (object s, EventArgs a) { MessageBox.Show("OK"); });
        area.Click += (EventHandler)delegate (object s, EventArgs a) { MessageBox.Show("OK"); };
        area.Click += delegate (object s, EventArgs a) { MessageBox.Show("OK"); };
        area.Click += delegate { MessageBox.Show("OK"); };

        // 람다식
        area.Click += (s, a) => MessageBox.Show("OK");
    }
    void Area_Click(object sender)
    {
        area.Text += " MyArea 클릭!";
    }
    void After_Click(object sender)
    {
        area.Text += " AfterClick 클릭!";
    }
    #endregion

    #region 델리게이트 강의 2
    public void ComPareRun()
    {
        int[] a = { 5, 53, 3, 7, 1 };
        // 오름차순 정렬
        Util.CompareDelegate compDele = Util.AscendingCompare;
        Util.Sort(a, compDele);
        // 내림차순 정렬
        compDele = Util.DecendingCompare;
        Util.Sort(a, compDele);
    }
    // 1. delegate 선언
    delegate void RunDelegate(int i);
    void RunThis(int val)
    {
        Console.WriteLine($"{val}");
    }
    void RunThat(int value)
    {
        Console.WriteLine($"0x{value:X}");
    }
    public void DelePerform()
    {
        // 2. delegate 인스턴스 생성
        //RunDelegate run = new RunDelegate(RunThis); <- 아래와 같음
        RunDelegate run = RunThis;
        // 3. delegate 실행
        run(1024);
        //run = new RunDelegate(RunThat); <- 아래와 같음
        run = RunThat;
        run(1024);

    }
    #endregion
    
    #region 델리게이트 강의 1
    delegate int MyDelegate(string s);
    public void DeleTest()
    {
        // delegate 객체 생성
        MyDelegate m = new MyDelegate(StringToInt);
        // delegate 객체를 메서드로 전달
        DeleRun(m);
    }
    // delegate 대상이 되는 메서드
    int StringToInt(string s)
    {
        return int.Parse(s);
    }
    // delegate를 전달받는 메서드
    void DeleRun(MyDelegate m)
    {
        // delegate로부터 메서드 실행
        int i = m("123"); // m.Invoke("123");
        Console.WriteLine(i);
    }
    #endregion

    #region 제네릭 강의
    class MyStack<T>
    {
        T[] _elements;
        int pos = 0;
        public int Pos
        {
            get { return pos; }
        }

        public MyStack()
        {
            _elements = new T[100];
        }

        public void Push(T element)
        {
            _elements[++pos] = element;
        }
        public T Pop()
        {
            return _elements[pos--];
        }
    }

    public void GenericSample()
    {
        MyStack<int> numberStack = new MyStack<int>();
        //MyStack<string> nameStack = new MyStack<string>();
        var nameStack = new MyStack<string>();
        numberStack.Push(14);
        numberStack.Push(20);
        numberStack.Push(5);
        Console.WriteLine($"{numberStack.Pop()}, pos : {numberStack.Pos}");
        nameStack.Push("Thursday");
        Console.WriteLine(nameStack.Pop());
    }
    #endregion

    #region 상속 클래스 테스트
    public void ClassTest()
    {
        Console.WriteLine("***** Class Test *****");
        Animal anyone = new Animal();
        anyone.Name = "Cat";
        anyone.Age = 5;
        anyone.SetGold(1000);
        Console.WriteLine($"Gold : {anyone.GetGold()}");

        Dog myDog = new Dog();
        myDog.Name = "puppy";
        myDog.Age = 8;
        myDog.SetWeight(15);
        myDog.HowOld();
        myDog.SetGold(2000);
        Console.WriteLine($"Gold : {myDog.GetGold()}");

        Bird myBird = new Bird();
        myBird.Name = "Pipi";
        myBird.Age = 3;
        myBird.Fly();

        /*
        // PureBase pb = new PureBase(); <- 이건 불가능하다. abstract이기 때문
        DerivedA da = new DerivedA();
        Console.WriteLine(da.GetFirst());
        Console.WriteLine(da.GetNext());
        Console.WriteLine(da.GetEnd());
        */
    }
    #endregion

    #region  Indexer 수업
    public class MyClass
    {
        private const int MAX = 10;
        private string name;
        private int[] data = new int[MAX];
        //indexer
        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= MAX)
                {
                    throw new IndexOutOfRangeException();
                }
                else
                {
                    return data[index];
                }
            }
            set
            {
                //if (!(index < 0 && index >= MAX))
                if (index >= 0 && index < MAX)
                {
                    data[index] = value;
                }
            }
        }

        public void SetData(int index, int value)
        {
            if (index >= 0 && index < MAX)
            {
                data[index] = value;
            }
        }
        public int GetData(int index)
        {
            if (index >= 0 && index < MAX)
            {
                return data[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public void IndexerTest()
        {
            CSharpStudy.MyClass cls = new CSharpStudy.MyClass();
            cls[1] = 1024;
            int i = cls[1];
            Console.WriteLine(i);
            cls.SetData(3, 100);
            int i2 = cls.GetData(3);
            Console.WriteLine(i2);
        }

        int id = 0;
        public string Name { get; set; }
        public void Run(int id) { }
        protected void Execute() { }
    }
    #endregion

    #region  전처리기 수업(#define, #if, #elif, #else, #region, #endregion)
    class ClassSample
    {
        #region Public methods
        public void Run() { }
        public void Create() { }
        #endregion

        #region Property
        public int Id { get; set; }
        #endregion

        #region Private
        void Execute() { }
        #endregion
    }
    public void PreProTest()
    {
        bool verbose = false;
#if (TEST_ENV)
        Console.WriteLine("Now Test Environment");
        verbose = true;
#elif (PROD_ENV)
        Console.WriteLine("Now Prod Environment");
#else
        Console.WriteLine("???");
#endif
        if (verbose)
        {
            Console.WriteLine("Verbose...");
        }
    }
    #endregion

    #region  Event 수업
    class MyLesson
    {
        public event EventHandler Run;
        public void RunEvent()
        {
            if (Run != null)
            {
                Run(this, EventArgs.Empty);
            }
        }
    }

    public void EventTest()
    {
        MyLesson lesson = new MyLesson();
        lesson.Run += new EventHandler(Lesson1);
        lesson.Run += new EventHandler(Lesson2);
        lesson.RunEvent();
        lesson.Run -= new EventHandler(Lesson2);
        lesson.RunEvent();

    }

    public void Lesson1(object sender, EventArgs e)
    {
        Console.WriteLine("이건 첫 번째 레슨");
    }

    public void Lesson2(object sender, EventArgs e)
    {
        Console.WriteLine("이건 두 번째 레슨");
    }

    public void Lesson3()
    {
        // 이건 이벤트로 구독 못함 (object sender, EventArgs e)가 없음
    }
    #endregion

    public void StringTest()
    {
        string s21 = "string";
        Console.WriteLine(s21.IndexOf('r'));

        string s2 = "Unity C#";

    }

    public void StandardNumericFormatString()
    {
        Console.WriteLine("C Example {0:C}", 123.456f);
        Console.WriteLine("D6 Sample {0:D6}", -1234);
        Console.WriteLine("{0:E2}", -1052.0329112756f);
        Console.WriteLine("{0:F4}", -1234.56f);
        Console.WriteLine("{0:N3}", -1234.56f);
        Console.WriteLine("{0:P1}", -0.39678f);
        Console.WriteLine("{0:x4}, {1:X4}", 255, -1);
    }

    #region  파라미터 샘플
    public void ParamSample()
    {

        Method1(33, 90, "Kyoung");
        Method1(name: "Kyoung", age: 33, score: 90);
        Method1(score: 100, name: "KHK", age: 35);
        Method1(2, 99);
        Method1(score: 7, age: 90);
        Method2(3000, 1000, 44);
        Method2(3000, 1000);
        Method2(3000);
        Method3(44, 80, true);
        Method3();
        Method3(live: true);
        Method3(score: 1000, age: 3000);

        int ret = Util.Calc(1, 2);
        ret = Util.Calc(100, 20, "-");
        ret = Util.Calc(b: 4, a: 3, calcType: "*");
        ret = Util.Calc(b: 4, a: 3);

        int s = Calc2(1, 2, 3, 4, 5);
        //int s2 =  Calc3(1, 2, 3, 4, 5);
        int s2 = Calc2(6, 7, 8, 9, 10, 11, 12);

        // ref 사용. 초기화 필요.
        int x = 1;
        double y = 1.0;
        double ret2 = GetData(ref x, ref y);
        Console.WriteLine($"x = {x}, y = {y:0.0}, ret2 = {ret2:0.0}");
        Console.WriteLine("x = {0}, y = {1:0.0}, ret2 = {2:0.0}", x, y, ret2);

        // out 사용. 초기화 불필요.
        int c, d;
        bool bret = GetData(10000, 2000, out c, out d);
        Console.WriteLine($"c = {c:#,#} / d = {d:#,#} / bret = {bret}");
        Console.WriteLine("c = {0:#,#} / d = {1:#,#} / bret = {2}", c, d, bret);
    }

    // params 수업
    public int Calc3(int[] values)
    {
        return 0;
    }
    public int Calc2(params int[] values)
    {
        return 0;
    }

    // named 파라미터 수업
    public void Method3(int age = 10, int score = 0, bool live = true)
    {

    }
    public void Method2(int age, int score = 100, int city = 82)
    {

    }
    public void Method1(int age, int score, string name = "NameEmpty")
    {

    }
    #endregion

    #region 참조 / 값 레퍼런스 강의
    // pass by reference 수업
    public double GetData(ref int a, ref double b)
    {
        return ++a * ++b;
    }

    public bool GetData(int a, int b, out int c, out int d)
    {
        c = a + b;
        d = a - b;
        return true;
    }

    // pass by value 수업
    public int Calculate(int a)
    {
        Console.WriteLine("a = " + a);
        a *= 2;
        Console.WriteLine("a = " + a);
        return a;
    }
    #endregion

    #region Nullable 강의
    public void NullableTest()
    {
        int? a = null;
        int? b = 0;
        int result = Nullable.Compare<int>(a, b);
        Console.WriteLine(result); // 0이면 같음, -1이면 다름

        double? c = 0.01;
        double? d = 0.0100;
        bool result2 = Nullable.Equals<double>(c, d);
        Console.WriteLine(result2);
    }
    #endregion

    double _Sum = 0;
    DateTime _Time;
    bool? _Selected;

    public void CheckInput(int? i, double? d, DateTime? time, bool? selected)
    {
        if (i.HasValue && d.HasValue)
        {
            this._Sum = (double)i.Value + (double)d.Value;
        }

        if (!time.HasValue)
        {
            throw new ArgumentException();
        }
        else
        {
            this._Time = time.Value;
        }
        // 만약 selected가 null이면 false를 할당
        // if (selected == null)
        // {
        //     this._Selected = false;
        // }
        // else
        // {
        //     this._Selected = selected;
        // }
        this._Selected = selected ?? false;
    }

    // 클래스
    public void ClassSample2()
    {
        MyCustomer mc = new MyCustomer();
        // name, age 값을 넣음(Set함)
        mc.Name = "Kyoung";
        mc.Age = 35;
        //mc.SetAge(-3);
        Console.WriteLine(mc.GetCustomerData());
        Console.WriteLine(mc.CalAge(40));
    }
    // 구조체 정의
    public struct MyPoint // <-정의 완료됨.
    {
        public int X;
        public int Y;

        public MyPoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }
    }
    #region 기초 강의
    public void StructTest()
    {
        // MyPoint pt = new  MyPoint(10, 12);
        var pt = new MyPoint(10, 12);
        var pt2 = new MyPoint();
        //Console.WriteLine(pt.ToString());
        //Console.WriteLine(pt2.ToString());
    }

    public void ExceptionSample()
    {
        int[] intArr = new int[3];
        try
        {
            intArr[0] = 0;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("AE .....");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("IOR 오류 발생!" + ex);
        }
        finally
        {
            Console.WriteLine("에러 없음");
        }
    }

    public void LoopSample()
    {
        // for
        for (int i = 0; i < 10; i += 2)
        {
            //Console.WriteLine("Loop {0}", i);
        }
        // foreach
        string[] array = new string[] { "AB", "CD", "EF" };
        // foreach (string s in array)
        // {
        //     Console.WriteLine(s);
        // }
        foreach (var item in array)
        {
            //Console.WriteLine(item);
        }

        string[,,] arr = new string[,,] {
            {{"1", "2"}, {"11", "22"}},
            {{"3", "4"}, {"33", "44"}}
        };

        // 다중 배열 for문을 썼을 때
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                for (int k = 0; k < arr.GetLength(2); k++)
                {
                    //Console.Write(arr[i, j, k] + ", ");
                }
            }
        }
        //Console.WriteLine();
        foreach (var item in arr)
        {
            //Console.Write(item + ", ");
        }

        //While문
        int answer = 6;
        while (answer <= 10)
        {
            Console.Write(answer + ",");
            answer++;
        }
        Console.WriteLine();
        //do while문
        answer = 6;
        do
        {
            Console.Write(answer + ",");
            answer++;
        } while (answer <= 10);

    }

    public void ConditionSample()
    {
        string category = "참외";
        int price = 0;
        switch (category)
        {
            case "참외":
            case "사과":
                price = 2000;
                break;
            case "딸기":
                price = 10000;
                break;
            case "포도":
                price = 6000;
                break;
            default:
                price = 1000;
                break;
        }
        Console.WriteLine("{1}는 {0}원입니다.", price, category);

        int val = 100;
        switch (val)
        {
            case 0:
                // 0...
                break;
            case 100:
                // 100...
                break;
        }
    }

    public void OperatorSample()
    {
        int i = 100, j = 0;
        Console.WriteLine("before : {0}, {1}", i, j);
        //j = i--;
        j = --i;
        Console.WriteLine("after : {0}, {1}", i, j);

        for (int z = 0; z < 10; z++)
        {

        }

        int a = 5, b = -2, c = 1;
        bool d = true;
        if ((a > 1 && b < 0) || c == 1 || !d)
        {
            Console.WriteLine("ok");
        }

        byte ba = 7;
        byte bb = (byte)((ba & 3) | 4);
        Console.WriteLine(bb);

        i = 2;
        i = i << 5;
        Console.WriteLine(i);

        //int val = (a > b) ? a : b;
        int val;
        if (a > b)
        {
            val = a;
        }
        else
        {
            val = b;
        }

        string str = null;
        string s = str ?? "몰라 이 쉬키야";
        Console.WriteLine(s);

        int? ni = null;
        i = ni ?? 30;
    }

    public void CodingGuide()
    {
        bool isValid = false;
        if (isValid == false) // 나쁜 표현
        {
            // 하지마라
        }
        else
        {
            // 해라
        }

        if (isValid) // 좋은 표현
        {
            // isValid면 해라
        }
        else
        {
            // isValid가 아니면 하지마라
        }
        //---------------------------
        int a = 0, b = 0;
        if ((a = b) == 10) // 나쁜 표현 : if문 안에서 할당 같은거 하지마라
        {

        }
        a = b;
        if (a == 10)
        {

        }
        //--------------------------
        string path1 = "C:\\temp\\Test.txt"; // 나쁜 표현
        string path2 = @"C:\temp\Test.txt";  // 좋은 표헌
        //--------------------------
        string s1 = "1", s2 = "2", s3 = "3";
        // var res = s1 + "+" + s2 + "=" + s3; 안 좋은 표현
        var res = string.Format("{0} + {1} = {2}", s1, s2, s3);
    }

    public enum GameState { Ready, Run }
    public enum Category
    {
        // 값을 지정할거면 전부 지정을 하거나 처음 값만 지정할 것.
        // 값이 겹치면 절대 안 됨
        Cake,
        IceCream,
        Bread
    }
    enum City
    {
        Seoul,
        Deajun,
        Busan = 5,
        Jeju = 10
    }

    [Flags] //비트 연산을 하는 enum
    enum Border
    {
        None = 0,
        Top = 1,
        Right = 2,
        Bottom = 4,
        Left = 8
    }
    public void EnumSample()
    {
        Category cafeCategory;
        cafeCategory = Category.Bread;
        //Console.WriteLine((int)cafeCategory);

        City myCity = City.Seoul;
        int cityValue = (int)myCity;
        if (myCity == City.Seoul)
        {
            //Console.WriteLine("Welcome to Seoul");
        }

        // OR 연산자로 다중 플래스 할당
        Border b = Border.Top | Border.Bottom | Border.Left;
        // & 연산자로 플래그 체크
        if ((b & Border.Top) != 0)
        {
            // HasFlag() 이용해서 플래그 체크
            if (b.HasFlag(Border.Bottom))
            {
                Console.WriteLine((int)b);
            }
        }
    }

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