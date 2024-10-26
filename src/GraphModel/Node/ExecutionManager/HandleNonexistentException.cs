using GraphModel.NewValueTypes;

namespace GraphModel.Node.ExecutionManager;

public class HandleNonexistentException(string message) : Exception(message)
{ }

public class HandleFlowNonexistentException(string label)
    : HandleNonexistentException($"Flow handle with label : {label} does not exist");

public class HandleValueNonexistentException(string label, ValueTypeEnum valueTypeEnum)
    : HandleNonexistentException($"Value handle with label : {label} of type : {valueTypeEnum} does not exist");