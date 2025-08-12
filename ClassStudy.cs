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