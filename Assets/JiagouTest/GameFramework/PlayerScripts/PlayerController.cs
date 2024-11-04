using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//实体行为类
public class PlayerController : EntityController
{
    public PlayerMoveCommand playerMoveCommand { get; private set; }

    public override void Start()
    {
        playerMoveCommand = new PlayerMoveCommand(this);
    }

    public override void Update()
    {
        base.Update();
    }
}
