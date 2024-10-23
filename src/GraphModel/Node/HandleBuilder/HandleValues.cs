namespace GraphModel.Node.HandleBuilder;

public record HandleValues();
public record ValueHandleValues(string Label, ValueType ValueType) : HandleValues;
public record FlowHandleValues(string Label) : HandleValues;