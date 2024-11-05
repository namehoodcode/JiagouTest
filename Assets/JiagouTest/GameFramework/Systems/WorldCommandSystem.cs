using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//��������ϵͳ�������ڰ���һ��������������Ҫ�����д���command�ű�д�߼����ټӽ���system����ִ��
public class WorldCommandSystem : BaseSystem
{
    private Queue<WorldBaseCommand> willDoCommandQueue;//��Ҫִ�е��������
    private Stack<WorldBaseCommand> unDoStack;//��һ���õ���
    private WorldBaseCommand current;//��ǰ��ִ�е�����

    public WorldCommandSystem()
    {
        willDoCommandQueue = new Queue<WorldBaseCommand>();
        unDoStack = new Stack<WorldBaseCommand>();
    }

    public bool IsRunningCommand
    {
        get { return current != null; }
    }

    public void AddCommand(WorldBaseCommand command)
    {
        willDoCommandQueue.Enqueue(command);
        unDoStack.Push(command);
    }

    public override void Update(float dt)
    {
        if (current == null)
        {
            if (willDoCommandQueue.Count > 0)
            {
                current = willDoCommandQueue.Dequeue();
                current.Do();
            }
        }
        else
        {
            if (current.Update(dt))
            {
                current = null;
            }
        }
        base.Update(dt);
    }

    public void Clear()
    {
        willDoCommandQueue?.Clear();
        unDoStack?.Clear();
        current = null;
    }

    public void UnDo()
    {
        if (unDoStack.Count > 0)
        {
            unDoStack.Pop().UnDo();
        }
    }
}
