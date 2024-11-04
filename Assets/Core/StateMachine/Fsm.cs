using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IFsm
{
    public abstract void Update();

    public abstract void EnterState();

    public abstract void ExitState();
}