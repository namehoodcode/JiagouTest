using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCommand : BaseCommand
{
    //������������������ȥ���ú���
    float x;
    float y;

    public PlayerMoveCommand(EntityController entityC) : base(entityC)
    {
    }

    public override bool Init()
    {
        return base.Init();
    }

    public override bool Update(float dt)
    {
        //x = Input.GetAxisRaw("Horizontal");
        //y = Input.GetAxisRaw("Vertical");
        x = GameApp.inputSystem.x;
        y = GameApp.inputSystem.y;
        if (x != 0 || y != 0)
        {
            entityC.Move(x, y);
        }
        return base.Update(dt);
    }

    public override void Excecute()
    {
        base.Excecute();
    }
}
