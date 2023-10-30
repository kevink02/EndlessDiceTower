using UnityEngine;

/// <summary>
/// For generating random values
/// </summary>
public static class RandomGenerator
{
    /*
     * Class methods
     */
    /// <summary>
    /// Returns a random value between <paramref name="minInc"/> inclusive and <paramref name="maxInc"/> inclusive
    /// </summary>
    /// <param name="minInc"></param>
    /// <param name="maxInc"></param>
    /// <returns></returns>
    public static int GetRandomInclusive(int minInc, int maxInc)
    {
        return (maxInc >= minInc) ? Random.Range(minInc, maxInc + 1) : minInc;
    }

    /// <summary>
    /// Returns a random value between <paramref name="minInc"/> inclusive and <paramref name="maxExc"/> exclusive
    /// </summary>
    /// <param name="minInc"></param>
    /// <param name="maxExc"></param>
    /// <returns></returns>
    public static int GetRandomExclusive(int minInc, int maxExc)
    {
        return (maxExc > minInc) ? Random.Range(minInc, maxExc) : minInc;
    }
}
