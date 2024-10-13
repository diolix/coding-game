namespace GraphModel.NewHandle;

public class ExecutionContext
{
    public event Action OnExecute;
    public void Execute()
    {
        OnExecute?.Invoke();
    }
}