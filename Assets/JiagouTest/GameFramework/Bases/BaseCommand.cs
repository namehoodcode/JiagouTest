using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCommand 
{
    public EntityController entityC;//�������
    protected bool isFinish;//�Ƿ�����

    public BaseCommand()
    {
        this.isFinish = false;
    }
    //����������������

    public BaseCommand(EntityController entityC)
    {
        this.entityC = entityC;
        entityC.commandUpdates += Update;
        this.isFinish = false;
    }
    //��������ʵ������

    public virtual bool Init()
    {
        return true;
    }
    public virtual bool Update(float dt)
    {
        return isFinish;
    }
    
    //ִ������
    public virtual void Excecute()
    {

    }

    //��������
    public virtual void UnDo()
    {

    }
}
