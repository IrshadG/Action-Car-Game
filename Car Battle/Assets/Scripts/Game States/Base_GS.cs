using UnityEngine;

public abstract class Base_GS
{
    public abstract void OnStateStarted(GameManager manager);

    public virtual void OnStateUpdate(GameManager manager)
    {

    }

    public abstract void OnStateChanged(GameManager manager);
}
