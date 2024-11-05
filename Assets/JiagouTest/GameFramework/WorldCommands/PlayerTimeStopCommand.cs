using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimeStopCommand : EntityBaseCommand<Player>
{
    bool isActivating = false;
    public PlayerTimeStopCommand(Player entityC) : base(entityC)
    {
        GameApp.gameEventSystem.AddEvent(TempEventDefine.LowTimeScale, ChangeTimeScale);
    }

    public override bool Update(float dt)
    {
        return base.Update(dt);
    }

    public void ChangeTimeScale(object args = null)
    {
        if (isActivating == false)
        {
            Time.timeScale = .1f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        isActivating = !isActivating;
    }
}
