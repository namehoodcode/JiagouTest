using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCommand
{
    public bool isFinish = false;
    public BaseCommand()
    {

    }
    public virtual bool Do()
    {
        return true;
    }

    public virtual bool UnDo()
    {
        return true;
    }

    public virtual bool Update(float dt)
    {
        return isFinish;
    }


}
