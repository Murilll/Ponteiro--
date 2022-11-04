﻿var coll = "LAB_PR_COV.csv"
    .Open()
    .Skip(1)
    .Take(1000)
    .ToList();

foreach (var x in coll)
{
    Console.WriteLine(x);
}

public static class MyExtensionMethods // Metodo de Extensão é voce colocar um metodo em uma classe que já existe
{
    public static IEnumerable<T> Skip<T>(this IEnumerable<T> coll, int N)
    {
        var it = coll.GetEnumerator();
        for (int i = 0; i < N && it.MoveNext(); i++);
        
        while (it.MoveNext())
            yield return it.Current;
    }
    
    public static IEnumerable<T> Take<T>(this IEnumerable<T> coll, int N)
    {
        var it = coll.GetEnumerator();
        for (int i = 0; i < N && it.MoveNext(); i++);
            yield return it.Current;
    }

    public static List<T> ToList<T>(this IEnumerable<T> coll)
    {
        List<T> list = new List<T>();

        var it = coll.GetEnumerator();
        while (it.MoveNext())
            list.Add(it.Current);
        return list;
    }

    public static int Count<T>(this IEnumerable<T> coll)
    {
        int count = 0;
        var it = coll.GetEnumerator();

        while (it.MoveNext())
            count++;
        return count;
    }

    public static T LastOrDefaut<T>(this IEnumerable<T> coll)
    {
        int count = 0;
        var it = coll.GetEnumerator();
        while (it.MoveNext())
            count++;
        
        return count == 0 ? default(T) : it.Current;
    }

    public static IEnumerable<T> Append<T>(this IEnumerable<T> coll, T item)
    {
        var it = coll.GetEnumerator();
        while (it.MoveNext())
            yield return it.Current;
        yield return item;
    }

    public static IEnumerable<T> Prepend<T>(this IEnumerable<T> coll, T item) // 1
    {
        yield return item;
        var it = coll.GetEnumerator();
        while (it.MoveNext())
            yield return it.Current;
    }

    public static T FirstOrDefault<T>(this IEnumerable<T> coll) // 2
    {
        var it = coll.GetEnumerator();
        return it.MoveNext() ? it.Current : default;
    }

    public static T[] ToArray<T>(this IEnumerable<T> coll) // 3
    {
        T[] arr = new T[coll.Count()];
        var it = coll.GetEnumerator();
        for (int i = 0; it.MoveNext(); i++)
            arr[i] = it.Current;
        return arr;
    }

    public static IEnumerable<string> Open(this string file)
    {
        var stream = new StreamReader(file);

        while(!stream.EndOfStream)
        {
            var line = stream.ReadLine();
            yield return line;
        }

        stream.Close();
    }
}