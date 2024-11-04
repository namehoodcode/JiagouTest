using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public float dt;
    public PlayerData playerData;
    void Start()
    {
        dt = Time.deltaTime;
        GameApp.Instance.Init();
    }


    void Update()
    {
        GameApp.Instance.Update(dt);
    }
}
