using System;

public class MyAccessModifiers
{
    private int birthYear;
    public string personalInfo;
    protected internal string IdNumber;
    public static byte averageMiddleAge = 50;
    internal string Name;
    internal string NickName { get; set; }

    public MyAccessModifiers(int birthYear, string idNumber, string personalInfo)
    {
        this.birthYear = birthYear;
        this.IdNumber = idNumber;
        this.personalInfo = personalInfo;
        this.Name = "";
        this.NickName = "";
    }

    public int Age
    {
        get { return DateTime.Now.Year - birthYear; }
    }

    protected internal bool HasLivedHalfOfLife()
    {
        return Age >= MyAccessModifiers.averageMiddleAge / 2;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        MyAccessModifiers other = (MyAccessModifiers)obj;
        return this.Name == other.Name && this.Age == other.Age && this.personalInfo == other.personalInfo;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Age, personalInfo);
    }
}

class Program
{
    static void Main(string[] args)
    {
        MyAccessModifiers person = new MyAccessModifiers(1990, "ID123456", "John Doe");

        person.Name = "John";

        Console.WriteLine($"Name: {person.Name}");
        Console.WriteLine($"Age: {person.Age}");

        bool hasLivedHalf = person.HasLivedHalfOfLife();
        Console.WriteLine($"Has lived half of life: {hasLivedHalf}");

        Console.WriteLine($"Personal Info: {person.personalInfo}");
        Console.WriteLine($"ID Number: {person.IdNumber}");

        MyAccessModifiers person2 = new MyAccessModifiers(1990, "ID123456", "John Doe");
        bool areEqual = person == person2;
        Console.WriteLine($"Are the two persons equal: {areEqual}");
    }
}
