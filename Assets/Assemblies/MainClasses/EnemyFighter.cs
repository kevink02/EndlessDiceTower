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
        throw new System.NotImplementedException();
    }

    public override void DoTurn()
    {
        throw new System.NotImplementedException();
    }

    public override void DoAttack()
    {
        throw new System.NotImplementedException();
    }
}
