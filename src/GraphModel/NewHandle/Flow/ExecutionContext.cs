namespace GraphModel.NewHandle.Flow;

public class ExecutionContext
{
    public event Action OnExecute;
    public void Execute()
    {
        OnExecute?.Invoke();
    }
}