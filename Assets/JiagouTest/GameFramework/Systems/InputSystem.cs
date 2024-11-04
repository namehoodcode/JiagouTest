using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//玩家输入系统，用来判断玩家输入来触发事件
public class InputSystem : BaseSystem
{
    List<KeyCode> keys;
    public float x;
    public float y;
    public InputSystem()
    {
        keys = new List<KeyCode> {KeyCode.Space };//功能性的按键可以放在里面，玩家改变键位的时候只需要更改列表内元素，（虽然unity有自带的input system，但是视频上看到好点子还是写了这个）
    }

    public override void Update(float dt)
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameApp.gameEventSystem.PostEvent(EventDefine.StartChangeScene);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameApp.gameEventSystem.PostEvent("onHealthChange");
        }
        base.Update(dt);
    }

}
