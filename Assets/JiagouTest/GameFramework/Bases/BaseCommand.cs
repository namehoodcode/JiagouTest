using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCommand 
{
    public EntityController entityC;//命令对象
    protected bool isFinish;//是否做完

    public BaseCommand()
    {
        this.isFinish = false;
    }
    //用来创建世界命令

    public BaseCommand(EntityController entityC)
    {
        this.entityC = entityC;
        entityC.commandUpdates += Update;
        this.isFinish = false;
    }
    //用来创建实体命令

    public virtual bool Init()
    {
        return true;
    }
    public virtual bool Update(float dt)
    {
        return isFinish;
    }
    
    //执行命令
    public virtual void Excecute()
    {

    }

    //撤销命令
    public virtual void UnDo()
    {

    }
}
