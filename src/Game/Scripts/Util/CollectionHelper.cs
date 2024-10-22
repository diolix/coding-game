using System.Collections.Generic;

namespace CodingGame.Scripts.Util;

public static class CollectionHelper
{
    public static IEnumerable<(T1 Item1, T2 Item2)> ZipLongest<T1, T2>(IEnumerable<T1> liste1, IEnumerable<T2> liste2)
    {
        using var enum1 = liste1.GetEnumerator();
        using var enum2 = liste2.GetEnumerator();

        while (true)
        {
            bool hasNext1 = enum1.MoveNext();
            bool hasNext2 = enum2.MoveNext();

            if (!hasNext1 && !hasNext2)
                yield break;

            yield return (
                hasNext1 ? enum1.Current : default(T1),
                hasNext2 ? enum2.Current : default(T2)
            );
        }
    }
}