/// <summary>
/// A container of values for a fighter's attack
/// </summary>
public struct FighterAttack
{
    /*
     * Instance variables
     */
    public int AttackStrength;
    public ElementType AttackElement;


    /*
     * Constructors
     */
    public FighterAttack(int attackStrength, ElementType attackElement)
    {
        AttackStrength = attackStrength;
        AttackElement = attackElement;
    }
}
