using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//������Ϸ�з������¼���ϵͳ������������¼�ÿ��ֻ����һ�Σ���event�ã����Ҫ���ö�Σ���ô�����WorldCommandSystem
//����Ϸ��ϵͳ��ϱȽϽ��ܣ�����������޸�����
public class GameEventSystem : BaseSystem
{
    private Dictionary<string, System.Action<object>> eventDic;
    //��ͨ�¼��ֵ�

    private Dictionary<System.Object,Dictionary<string,System.Action<object>>> objEventDic;
    //��Ӧ������¼��ֵ�

    public GameEventSystem()
    {
        eventDic = new Dictionary<string, System.Action<object>>();
        objEventDic = new Dictionary<object, Dictionary<string, System.Action<object>>>();
    }

    /// <summary>
    /// һ��д��Awake���߹��췽����
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
                //���ж������Ƿ�ֹһ��Action����ӵ���������ѭ������
                eventDic[eventName] += callback;
            }
            else
            {
                Debug.Log("GameEventSystem������listenerObj�ķ����������ͬ��Action��������ش���");
            }
        }
        else
        {
            eventDic.Add(eventName, callback);
        }
    }
    //���û��listenerObj���¼�

    /// <summary>
    /// һ��д��Awake���߹��췽����
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
                    //�ж��Ƿ�����ظ���Action
                    objEventDic[listenerObj][eventName] += callback;
                }
                else
                {
                    Debug.Log("GameEventSystem������listenerObj�ķ����������ͬ��Action��������ش���");
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
    //�����listenerObj���¼�
    

    /// <summary>
    /// һ��д��OnDestroy������
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
    /// һ��д��OnDestroy������
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
    /// ִ���¼�
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
    /// ִ���¼�
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
