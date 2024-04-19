public class ParallelUtils<T, TR>
{
    private readonly Func<T, T, TR> operation;
    private readonly T operand1;
    private readonly T operand2;

    public ParallelUtils(Func<T, T, TR> operation, T operand1, T operand2)
    {
        this.operation = operation ?? throw new ArgumentNullException(nameof(operation));
        this.operand1 = operand1;
        this.operand2 = operand2;
    }

    public TR Result { get; private set; }

    public void StartEvaluation()
    {
        Task.Run(Evaluate);
    }

    public void Evaluate()
    {
        Result = operation(operand1, operand2);
    }
}
class Programwe
{
    static void Main()
    {
        Func<int, int, int> add = (a, b) => a + b;
        ParallelUtils<int, int> parallelUtils = new ParallelUtils<int, int>(add, 10, 20);

        parallelUtils.StartEvaluation();

        Task.Delay(100).Wait();

        Console.WriteLine(parallelUtils.Result);
    }
}