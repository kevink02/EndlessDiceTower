public class EnemyFighter : DiceFighter
{
    /*
     * Unity methods
     */
    private new void Awake()
    {
        base.Awake();
    }

    private new void OnEnable()
    {
        base.OnEnable();
    }

    private new void Start()
    {
        base.Start();
    }


    /*
     * Instance methods
     */
    public override void StartTurn()
    {
        DoTurn();
    }

    public override void DoTurn()
    {
        // Roll all dice
        for (int i = 0; i < 3; i++)
        {
            OnDieRolled?.Invoke(i);
        }

        // Perform the attack
        OnAttackPerformed?.Invoke();

        EndTurn();
    }

    public override void DoAttack()
    {
        throw new System.NotImplementedException();
    }
}
