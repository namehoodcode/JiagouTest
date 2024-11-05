using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


/// <summary>
/// 所有实体的接口，往里面写所有实体都有的功能
/// </summary>
public interface IEntity
{
    void Move();
}


//实体行为接口
//这里想了一下具体方法实现要写在哪里，考虑到复用性，以及如果要把具体实现写在command里面的话要整很多的传参和调用，所以干脆就放这里了
//补充：建议把这里的方法放进具体的command里面
//后面的补充：难怪这么不对劲，架构不是很好，要重新捋一遍这里的架构了