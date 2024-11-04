using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��������ϵͳ��ûд��
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
        //�ı������z�����꣬2d�����µ�������ܿ���z�������������z������Ļ��棬�����ܿ���������£�z�������������ĳ����ᵲס����Զ�ĳ���
    }
}
