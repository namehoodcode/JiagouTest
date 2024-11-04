using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//这个摄像机系统还没写完
public class CameraSystem : BaseSystem
{
    public Transform camTF;
    public int sceneZTrans = 1;
    public CameraSystem()
    {
        camTF = Camera.main.transform;
        if (camTF == null)
        {
            return;
        }
        SetCamPos(0, 0, -3);
        GameApp.gameEventSystem.AddEvent(EventDefine.StartChangeScene,ChangeScene);
    }

    public void SetCamPos(float x,float y,float z)
    {
        camTF.position = new Vector3(x, y, z);
    }

    public void ChangeCamPos(float x,float y,float z)
    {
        if (camTF == null)
        {
            Debug.Log("cam null");
            return;
        }
        camTF.position += new Vector3(x, y, z);
    }

    public void ChangeScene(object args = null)
    {
        ChangeCamPos(0, 0, sceneZTrans);
        sceneZTrans = -sceneZTrans;
        //改变摄像机z轴坐标，2d场景下的摄像机能看到z轴坐标大于自身z轴坐标的画面，且在能看到的情况下，z轴距离摄像机近的场景会挡住距离远的场景
    }
}
