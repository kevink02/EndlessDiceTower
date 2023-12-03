public struct IntRange
{
    /*
     * Properties
     */
    public int MinValue { get; private set; }
    public int MaxValue { get; private set; }

    
    /*
     * Constructors
     */
    public IntRange(int minValue, int maxValue)
    {
        MinValue = minValue;
        if (maxValue >= minValue)
        {
            MaxValue = maxValue;
        }
        else
        {
            throw new System.Exception("The given max value is not greater than or equal to the given min value");
        }
    }


    /*
     * Instance methods
     */
    /// <summary>
    /// Checks if <paramref name="value"/> is inclusive between the min and max values
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool IsInRange(int value)
    {
        return MinValue <= value && value <= MaxValue;
    }

    /// <summary>
    /// Checks if <paramref name="value"/> is not inclusive between the min and max values
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public bool IsNotInRange(int value)
    {
        return MinValue > value || value < MaxValue;
    }
}
