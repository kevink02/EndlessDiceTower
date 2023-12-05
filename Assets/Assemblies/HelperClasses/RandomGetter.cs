using System;
using System.Collections.Generic;

public static class RandomGetter<T>
{
    /*
     * Class methods
     */
    public static T GetRandomItem(T[] items)
    {
        if (items == null)
        {
            throw new NullReferenceException("The given array is null");
        }
        else if (items.Length == 0)
        {
            throw new NullReferenceException("The given array is empty");
        }
        return items[RandomGenerator.GetRandomExclusive(0, items.Length)];
    }

    public static T GetRandomItem(List<T> items)
    {
        if (items == null)
        {
            throw new NullReferenceException("The given list is null");
        }
        else if (items.Count == 0)
        {
            throw new NullReferenceException("The given list is empty");
        }
        return items[RandomGenerator.GetRandomExclusive(0, items.Count)];
    }
}
