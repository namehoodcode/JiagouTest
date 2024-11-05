using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBaseCommand<T> : BaseCommand where T : Entity 
{
    public T entityC;//命令对象

    public EntityBaseCommand(T entityC)
    {
        this.entityC = entityC;
        entityC.commandUpdates += Update;
        this.isFinish = false;
    }//用来创建实体命令

    public override bool Do()
    {
        return base.Do();
    }

    public override bool UnDo()
    {
        return base.UnDo();
    }

    public override bool Update(float dt)
    {
        return base.Update(dt);
    }
}
