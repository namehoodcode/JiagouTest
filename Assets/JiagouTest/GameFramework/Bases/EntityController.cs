using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//实体行为类，里面管理实体的command
//这里想了一下具体方法实现要写在哪里，考虑到复用性，以及如果要把具体实现写在command里面的话要整很多的传参和调用，所以干脆就放这里了
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
