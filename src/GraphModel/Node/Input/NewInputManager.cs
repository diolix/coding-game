using CodingGame.Script.Util;
using GraphModel.NewHandle;
using GraphModel.NewHandle.Value;

namespace GraphModel.Node.Input;

public class NewInputManager
{
    private readonly IEnumerable<INewHandle> _handles;
    public IEnumerable<INewHandle> Handles => _handles;
    
    private IEnumerable<InputValueHandle> _inputValues = null!;
    
    public NewInputManager(IEnumerable<INewHandle> handles)
    {
        _handles = handles;
        InitializeInputValues();
    }

    private void InitializeInputValues()
    {
        _inputValues = _handles.OfType<InputValueHandle>();
    }
    
    public Optional<object> GetValue(string label)
    {
        return _inputValues.First(handle => handle.Label == label).GetValue();
    }
}