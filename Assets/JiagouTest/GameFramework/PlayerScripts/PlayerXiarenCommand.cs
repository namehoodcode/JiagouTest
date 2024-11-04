using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerXiarenCommand : BaseCommand
{
    public bool isBig = false;
    public PlayerXiarenCommand(EntityController entityC) : base(entityC)
    {
    }

    public override bool Init()
    {
        return base.Init();
    }

    public override void Excecute()
    {
        base.Excecute();
    }
    public override bool Update(float dt)
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isBig)
            {
                DoAnimateSmall();
            }
            else
            {

                DoAnimateBig();
            }
        }
        return base.Update(dt);
    }

    public void DoAnimateBig()
    {
        entityC.gameObject.transform.DOScale(5,.5f);
        entityC.gameObject.transform.DORotate(new Vector3(0, 0, 180), .5f);
        isBig  = true;
    }

    public void DoAnimateSmall()
    {
        entityC.gameObject.transform.DOScale(1, .5f);
        entityC.gameObject.transform.DORotate(new Vector3(0, 0, 0), .5f);
        isBig = false;
    }
}
