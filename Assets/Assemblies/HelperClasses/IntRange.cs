public struct IntRange
{
    /*
     * Instance variables
     */
    private int _minValue, _maxValue;

    
    /*
     * Constructors
     */
    public IntRange(int minValue, int maxValue)
    {
        _minValue = minValue;
        if (maxValue >= minValue)
        {
            _maxValue = maxValue;
        }
        else
        {
            throw new System.Exception("The given max value is not greater than or equal to the given min value");
        }
        //_maxValue = (maxValue >= minValue) ? maxValue : minValue;
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
        return _minValue <= value && value <= _maxValue;
    }
}
