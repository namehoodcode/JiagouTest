using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ʵ����Ϊ�࣬�������ʵ���command
//��������һ�¾��巽��ʵ��Ҫд��������ǵ������ԣ��Լ����Ҫ�Ѿ���ʵ��д��command����Ļ�Ҫ���ܶ�Ĵ��κ͵��ã����Ըɴ�ͷ�������
public class EntityController : MonoBehaviour
{
    [SerializeField] private EntityData entityData;
    public event Func<float,bool> commandUpdates;

    public virtual void Awake()
    {
        entityData = GetComponent<EntityData>();
    }
    public virtual void Start()
    {

    }

    public virtual void Update()
    {
        commandUpdates?.Invoke(Time.deltaTime);
    }

    public virtual void Move(float x,float y)
    {
        gameObject.transform.position += Time.deltaTime * new Vector3(x, y, 0) * entityData.moveSpeed;
    }
}
