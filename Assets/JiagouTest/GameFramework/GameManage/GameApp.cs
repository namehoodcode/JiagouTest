using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//管理游戏系统初始化和更新的脚本
public class GameApp : Singleton<GameApp>
{
    public static GameEventSystem gameEventSystem;
    public static InputSystem inputSystem;
    public static CameraSystem cameraSystem;

    public override void Init()
    {
        gameEventSystem = new GameEventSystem();
        inputSystem = new InputSystem();
        cameraSystem = new CameraSystem();
        base.Init();
    }

    public override void Update(float dt)
    {
        inputSystem.Update(dt);
        base.Update(dt);
    }
}
