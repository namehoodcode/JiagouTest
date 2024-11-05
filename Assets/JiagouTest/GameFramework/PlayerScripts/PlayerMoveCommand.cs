using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveCommand : EntityBaseCommand<Player>
{
    //用怎样的条件和流程去调用函数
    float x;
    float y;
    float timer = 0;
    float maxTime = 1f;

    public PlayerMoveCommand(Player entityC) : base(entityC)
    {
    }

    public override bool Update(float dt)
    {
        //x = Input.GetAxisRaw("Horizontal");
        //y = Input.GetAxisRaw("Vertical");
        //x = GameApp.inputSystem.x;
        //y = GameApp.inputSystem.y;
        //if (x != 0 || y != 0)
        //{
        //    entityC.Move(x, y);
        //}
        Debug.Log("in Update");
        timer += Time.deltaTime;
        if (Input.GetMouseButton(0) && timer >= 1f)
        {
            timer = 0;
            entityC.Move();
        }
        return base.Update(dt);
    }

    public override bool Do()
    {
        return base.Do();
    }
}
