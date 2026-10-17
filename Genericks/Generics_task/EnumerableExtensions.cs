
using System;
using System.Collections.Generic;

public static class EnumerableExtensions
{
    public static IEnumerable<T> Page<T>(
        this IEnumerable<T> source,
        int pageNumber,
        int pageSize)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (pageNumber < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(pageNumber));
        }

        if (pageSize < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(pageSize));
        }

        return GetPage(source, pageNumber, pageSize);
    }

    private static IEnumerable<T> GetPage<T>(
        IEnumerable<T> source,
        int pageNumber,
        int pageSize)
    {
        long start = ((long)pageNumber - 1) * pageSize;
        long end = start + pageSize;
        long index = 0;

        foreach (T item in source)
        {
            if (index >= start && index < end)
            {
                yield return item;
            }

            if (index >= end - 1)
            {
                yield break;
            }

            index++;
        }
    }

    public static T? FindById<T>(
        this IEnumerable<T> source,
        int id)
        where T : IHasId
    {
        foreach (T item in source)
        {
            if (item.Id == id)
            {
                return item;
            }
        }

        return default;
    }

public static IReadOnlyDictionary<int, T> ToIdDictionary<T>(
    this IEnumerable<T> source)
    where T : IHasId
    {
        Dictionary<int, T> result = new();

        foreach (T item in source)
        {
            result.Add(item.Id, item);
        }

        return new System.Collections.ObjectModel.ReadOnlyDictionary<int, T>(result);
    }


}

