using GraphModel.Edge;
using GraphModelTest.Mocks;

namespace GraphModelTest.Test.Edge;

public abstract class BaseEdgeTest
{
    protected EdgeFactory EdgeFactory { get; } = new EdgeFactory();
    protected MockNodeFactory MockNodeFactory { get; } = new MockNodeFactory();
}