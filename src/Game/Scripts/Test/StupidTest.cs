using GdUnit4;
using static GdUnit4.Assertions;

namespace CodingGame.Scripts.Test;

[TestSuite]
public class StupidTest
{
    [TestCase]
    public void StupidTest1()
    {
        var a = 1;
        var b = 2;
        AssertInt(a + b).IsEqual(3);
    }
}