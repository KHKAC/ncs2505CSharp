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

    public static int ConvertBack(string s) //public int ConvertBack(string s) <- static이 아니라서 불가능
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