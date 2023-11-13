public class RollableDieWrapper
{
    /*
     * Instance variables
     */
    private int _rolledValue;
    private bool _wasRolledThisTurn;


    /*
     * Properties
     */
    public RollableDie RollableDie { get; private set; }


    /*
     * Constructors
     */
    public RollableDieWrapper(RollableDie rollableDie)
    {
        RollableDie = rollableDie;
    }
}
