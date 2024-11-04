using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������ϵͳ�������ж���������������¼�
public class InputSystem : BaseSystem
{
    List<KeyCode> keys;
    public float x;
    public float y;
    public InputSystem()
    {
        keys = new List<KeyCode> {KeyCode.Space };//�����Եİ������Է������棬��Ҹı��λ��ʱ��ֻ��Ҫ�����б���Ԫ�أ�����Ȼunity���Դ���input system��������Ƶ�Ͽ����õ��ӻ���д�������
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
