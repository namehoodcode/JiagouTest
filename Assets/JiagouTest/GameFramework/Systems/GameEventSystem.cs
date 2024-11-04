using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//管理游戏中发生的事件的系统，如果发生的事件每次只调用一次，用event好，如果要调用多次，那么最好用WorldCommandSystem
//和游戏中系统耦合比较紧密，不建议随便修改内容
public class GameEventSystem : BaseSystem
{
    private Dictionary<string, System.Action<object>> eventDic;
    //普通事件字典

    private Dictionary<System.Object,Dictionary<string,System.Action<object>>> objEventDic;
    //对应物体的事件字典

    public GameEventSystem()
    {
        eventDic = new Dictionary<string, System.Action<object>>();
        objEventDic = new Dictionary<object, Dictionary<string, System.Action<object>>>();
    }

    /// <summary>
    /// 一般写在Awake或者构造方法中
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callback"></param>
    public void AddEvent(string eventName, System.Action<object> callback)
    {
        if(callback == null)
        {
            return;
        }

        if (eventDic.ContainsKey(eventName))
        {
            if (!eventDic[eventName].GetInvocationList().Contains(callback))
            {
                //该判断条件是防止一个Action被添加到自身引起循环调用
                eventDic[eventName] += callback;
            }
            else
            {
                Debug.Log("GameEventSystem中以无listenerObj的方法添加了相同的Action，请检查相关代码");
            }
        }
        else
        {
            eventDic.Add(eventName, callback);
        }
    }
    //添加没有listenerObj的事件

    /// <summary>
    /// 一般写在Awake或者构造方法中
    /// </summary>
    /// <param name="listenerObj"></param>
    /// <param name="eventName"></param>
    /// <param name="callback"></param>
    public void AddEvent(System.Object listenerObj,string eventName,System.Action<object> callback)
    {
        if (callback == null)
        {
            return;
        }

        if (objEventDic.ContainsKey(listenerObj))
        {
            if (objEventDic[listenerObj].ContainsKey(eventName))
            {
                if (!objEventDic[listenerObj][eventName].GetInvocationList().Contains(callback))
                {
                    //判断是否添加重复的Action
                    objEventDic[listenerObj][eventName] += callback;
                }
                else
                {
                    Debug.Log("GameEventSystem中以有listenerObj的方法添加了相同的Action，请检查相关代码");
                }
            }
            else
            {
                objEventDic[listenerObj].Add(eventName, callback);
            }
        }
        else
        {
            Dictionary<string,System.Action<object>> tempDic = new Dictionary<string,System.Action<object>>();
            tempDic.Add(eventName, callback);
            objEventDic.Add(listenerObj, tempDic);
        }
    }
    //添加有listenerObj的事件
    

    /// <summary>
    /// 一般写在OnDestroy方法中
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="callback"></param>
    public void RemoveEvent(string eventName,System.Action<object> callback)
    {
        if (eventDic.ContainsKey(eventName))
        {
            eventDic[eventName] -= callback;
            if (eventDic[eventName] == null)
            {
                eventDic.Remove(eventName);
            }
        }
    }

    /// <summary>
    /// 一般写在OnDestroy方法中
    /// </summary>
    /// <param name="listenerObj"></param>
    /// <param name="eventName"></param>
    /// <param name="callback"></param>
    public void RemoveEvent(System.Object listenerObj, string eventName, System.Action<object> callback)
    {
        if (objEventDic.ContainsKey(listenerObj))
        {
            if (objEventDic[listenerObj].ContainsKey(eventName))
            {
                objEventDic[listenerObj][eventName] -= callback;
                if(objEventDic[listenerObj][eventName] == null)
                {
                    objEventDic[listenerObj].Remove(eventName);
                    if (objEventDic[listenerObj] == null)
                    {
                        objEventDic.Remove(listenerObj);
                    }
                }
            }
        }
    }

    public void RemoveObjAllEvent(System.Object listenerObj)
    {
        if (objEventDic.ContainsKey(listenerObj))
        {
            objEventDic.Remove(listenerObj);
        }
    }


    /// <summary>
    /// 执行事件
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="args"></param>
    public void PostEvent(string eventName,object args = null)
    {
        if (eventDic.ContainsKey(eventName))
        {
            Debug.Log("posted " + eventName);
            eventDic[eventName]?.Invoke(args);
        }
    }

    /// <summary>
    /// 执行事件
    /// </summary>
    /// <param name="listenerObj"></param>
    /// <param name="eventName"></param>
    /// <param name="args"></param>
    public void PostEvent(System.Object listenerObj, string eventName, object args = null) 
    {
        if (objEventDic.ContainsKey(listenerObj))
        {
            if (objEventDic[listenerObj].ContainsKey(eventName))
            {
                objEventDic[listenerObj][eventName]?.Invoke(args);
            }
        }
    }

}
