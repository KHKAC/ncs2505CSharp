#region 인터페이스 강의 2
public class ClimateMotitor
{
    ILogger logger;
    public ClimateMotitor(ILogger inLogger)
    {
        logger = inLogger;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("온도를 입력해주세요 : ");
            string temp = Console.ReadLine();
            if (temp == "")
            {
                break;
            }
            logger.WriteLog($"현재 온도 : {temp}");
        }
    }
}

public interface ILogger
{
    void WriteLog(string message);
}

public class FileLogger : ILogger
{
    StreamWriter writer;
    public FileLogger(string path)
    {
        writer = File.CreateText(path);
        writer.AutoFlush = true;
    }
    public void WriteLog(string message)
    {
        writer.WriteLine($"{DateTime.Now.ToShortTimeString()}, {message}");
    }
}

public class ConsoleLogger : ILogger
{
    public void WriteLog(string message)
    {
        Console.WriteLine($"{DateTime.Now.ToLocalTime()}, {message}");
    }
}
#endregion

#region 인터페이스 강의 1
public interface IComparable
{
    // 인터페이스에서는 구현부 'method() {}' 사용하면 안 됨.
    // 인터페이스 내부는 전부 public 그래서 생략 가능
    int CompareTo(object obj);
    void Open();
    void Close();
}

public class MyClass2 : IComparable
{
    // 인터페이스 클래스에서 만들지 않은 구현부는 상속받은 클래스에서 만든다.
    public int CompareTo(object obj)
    {
        return 0;
    }

    public void Open()
    {

    }
    public void Close()
    {

    }
}

public class InterfaceSample
{
    public void Sample()
    {
        // IComparable ic = new IComparable(); <- 에러 발생 인터페이스 구현부 없음.
        IComparable ic = new MyClass2();
        ic.Open();
        ic.Close();

        MyClass2 mc2 = new MyClass2();
        mc2.Open();
        mc2.Close();
    }
}
#endregion

public static class MyUtility
{


    private static int ver;

    // static 생성자
    static MyUtility()
    {
        ver = 1;
    }

    public static string Convert(int i)
    {
        return i.ToString();
    }

    //public int ConvertBack(string s) <- static이 아니라서 불가능
    public static int ConvertBack(string s)
    {
        return int.Parse(s);
    }
}

public class Myclass
{
    public Myclass()
    {
        val = 100;
    }
    int val = 1;

    // 일반 메서드
    public int InstRun()
    {
        int k = Myclass.Run();
        return val;
    }

    // 스태틱 메서드 : 동떨어져 있어서 혼자 노는 애, 호출되는 메서드가 public이어도 같음
    public static int Run()
    {
        //return val; & InstRun(); <- 안 됨
        return 1;
    }
}

public class Client
{
    public void Test()
    {
        // 일반 메서드 호출 방식
        Myclass myClass = new Myclass();
        int i = myClass.InstRun();
        Console.WriteLine($"i : {i}");

        // static
        //int j = myClass.Run(); <- 불가능. 아래처럼 클래스에 .연산자를 붙여서 사용 가능
        int j = Myclass.Run();
        Console.WriteLine($"j : {j}");
    }
}

// base class
public class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }
    protected int Weight { get; set; }
    private int gold;
    public void SetGold(int value)
    {
        gold = value;
    }
    public int GetGold()
    {
        return gold;
    }
}

// child class
public class Dog : Animal
{
    public void SetWeight(int value)
    {
        Weight = value;
    }
    public void HowOld()
    {
        // base class의 Age 사용
        //Console.WriteLine("Age : {0}", this.Age);
        Console.WriteLine($"My Dog, {this.Name} is {this.Age} years old. Weight is {this.Weight}kg");
    }
}

public class Bird : Animal
{
    public void Fly()
    {
        Console.WriteLine($"{this.Name} is flying");
    }
}

public abstract class PureBase
{
    //abstract
    public abstract int GetFirst();
    public abstract int GetNext();

    public int GetEnd()
    {
        return 100;
    }
 }

public class DerivedA : PureBase
{
    private int num = 1;

    //override
    public override int GetFirst()
    {
        return num;
    }
    public override int GetNext()
    {
        return ++num;
    }
}