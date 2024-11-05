using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//世界命令系统，适用于按照一定流程完成任务的要求，自行创建command脚本写逻辑，再加进该system队列执行
public class WorldCommandSystem : BaseSystem
{
    private Queue<WorldBaseCommand> willDoCommandQueue;//将要执行的命令队列
    private Stack<WorldBaseCommand> unDoStack;//不一定用得上
    private WorldBaseCommand current;//当前所执行的命令

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
