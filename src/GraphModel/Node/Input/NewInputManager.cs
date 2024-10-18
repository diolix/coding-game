using CodingGame.Script.Util;
using GraphModel.NewHandle;
using GraphModel.NewHandle.Value.Impure;

namespace GraphModel.Node.Input;

public class NewInputManager
{
    private readonly IEnumerable<INewHandle> _handles;
    public IEnumerable<INewHandle> Handles => _handles;
    
    private IEnumerable<ImpureInputValueHandle> _inputValues;
    
    public NewInputManager(IEnumerable<INewHandle> handles)
    {
        _handles = handles;
        InitializeInputValues();
    }

    private void InitializeInputValues()
    {
        _inputValues = _handles.Where(handle => handle is ImpureInputValueHandle).Cast<ImpureInputValueHandle>();
    }
    
    public Optional<object> GetValue(string label)
    {
        return _inputValues.First(handle => handle.Label == label).GetValue();
    }
}