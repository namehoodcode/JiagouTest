using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerXiarenCommand : EntityBaseCommand<Player>
{
    public bool isBig = false;
    public PlayerXiarenCommand(Player entityC) : base(entityC)
    {
    }

    public override bool Update(float dt)
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    if (isBig)
        //    {
        //        entityC.DoAnimateSmall();
        //    }
        //    else
        //    {

        //        entityC.DoAnimateBig();
        //    }
        //}
        return base.Update(dt);
    }
}
