using System;
using UnityEngine;

public class EventHandlerTest : MonoBehaviour
{
    public event EventHandler<EventArgs> OnEventTest;

    public void Awake()
    {
    }

    public void OnEnable()
    {
        OnEventTest += Test;
        OnEventTest += TestA;
        OnEventTest += TestB;
    }

    public void Start()
    {
        OnEventTest(this, new EventArgsB());
    }

    public void OnDisable()
    {
        OnEventTest -= Test;
        OnEventTest -= TestA;
        OnEventTest -= TestB;
    }

    public void Test(object sender, EventArgs args)
    {
        args.TestVar += "?";
        Debug.Log($"Argument value is now {args.TestVar}");
    }

    public void TestA(object sender, EventArgs args)
    {
        Debug.Log($"Argument value is {args.TestVar}");
        if (args is EventArgsA a)
        {
            a.TestVarA += 1;
            Debug.Log($"Argument A value is now {a.TestVarA}");
        }
    }

    public void TestB(object sender, EventArgs args)
    {
        Debug.Log($"Argument value is {args.TestVar}");
        if (args is EventArgsB b)
        {
            b.TestVarB += 0.1f;
            Debug.Log($"Argument B value is now {b.TestVarB}");
        }
    }
}

public class EventArgsA : EventArgs
{
    public int TestVarA;
}

public class EventArgsB : EventArgs
{
    public float TestVarB;
}
