using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseSystem//系统应该有的函数，起一个提示作用
{
    public virtual void Init() { }

    public virtual void Update(float dt) { }
}
