public class Employee
{
    internal string name;
    private DateTime hiringDate;

    public Employee(string name, DateTime hiringDate)
    {
        this.name = name;
        this.hiringDate = hiringDate;
    }

    public int Experience()
    {
        return (DateTime.Now - hiringDate).Days / 365;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"{name} has {Experience()} years of experience");
    }
}

public class Developer : Employee
{
    private string programmingLanguage;

    public Developer(string name, DateTime hiringDate, string programmingLanguage) : base(name, hiringDate)
    {
        this.programmingLanguage = programmingLanguage;
    }

    public new void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"{name} is {programmingLanguage} programmer");
    }
}

public class Tester : Employee
{
    private bool isAutomation;

    public Tester(string name, DateTime hiringDate, bool isAutomation) : base(name, hiringDate)
    {
        this.isAutomation = isAutomation;
    }

    public new void ShowInfo()
    {
        base.ShowInfo();
        if (isAutomation)
        {
            Console.WriteLine($"{name} is automated tester");
        }
        else
        {
            Console.WriteLine($"{name} is manual tester");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {

        Employee emp = new Employee("Danya", new DateTime(2010, 1, 1));
        emp.ShowInfo();

        Developer dev = new Developer("Yura", new DateTime(2015, 5, 10), "C#");
        dev.ShowInfo();

        Tester tester1 = new Tester("Roma", new DateTime(2013, 8, 20), true);
        tester1.ShowInfo();

        Tester tester2 = new Tester("Solya", new DateTime(2014, 3, 15), false);
        tester2.ShowInfo();

    }
}
