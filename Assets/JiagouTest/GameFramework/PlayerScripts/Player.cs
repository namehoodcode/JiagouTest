using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ҵ����ݣ���Ϊ
/// ����������inspector����޸�
/// </summary>
public class Player : Entity, IPlayer
{
    PlayerMoveCommand playerMoveCommand;
    PlayerTimeStopCommand playerTimeStopCommand;
    public override void Start()
    {
        playerMoveCommand = new PlayerMoveCommand(this);
        playerTimeStopCommand = new PlayerTimeStopCommand(this);
        base.Start();
    }

    public override void Update()
    {    
        base.Update();
    }

    public void Move()
    {
        moveDir = ((Vector3)GameApp.inputSystem.mouseWorldPos - transform.position).normalized;
        rb.velocity = moveDir * moveSpeed;
    }
}
