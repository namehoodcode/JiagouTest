using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public float dt;
    public Player playerData;
    private void Awake()
    {
        dt = Time.deltaTime;
        GameApp.Instance.Init();
    }
    void Start()
    {
        
    }


    void Update()
    {
        GameApp.Instance.Update(dt);
    }
}
