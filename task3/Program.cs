public delegate double CalcDelegate(double num1, double num2, char operation);

public class CalcProgram
{
    public static double Calc(double num1, double num2, char operation)
    {
        switch (operation)
        {
            case '+':
                return num1 + num2;
            case '-':
                return num1 - num2;
            case '*':
                return num1 * num2;
            case '/':
                if (num2 != 0)
                    return num1 / num2;
                else
                    return 0; 
            default:
                throw new ArgumentException("Invalid operation");
        }
    }

    public CalcDelegate funcCalc = new CalcDelegate(Calc);
}

class Program
{
    static void Main(string[] args)
    {
        CalcProgram calculator = new CalcProgram();
        
        Console.WriteLine(calculator.funcCalc(5, 3, '+')); 
        Console.WriteLine(calculator.funcCalc(5, 3, '-')); 
        Console.WriteLine(calculator.funcCalc(5, 3, '*')); 
        Console.WriteLine(calculator.funcCalc(5, 0, '/')); 
        Console.WriteLine(calculator.funcCalc(5, 0, '/')); 
    }
}
