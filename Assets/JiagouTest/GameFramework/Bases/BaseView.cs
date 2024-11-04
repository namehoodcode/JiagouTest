using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseView : MonoBehaviour
{
    public int ViewId { get;set; }
    public ViewController Controller { get; set; }
    protected Canvas _canvas;
    protected Dictionary<string,GameObject> viewObjs = new Dictionary<string,GameObject>();
    private bool _isInit = false;//�Ƿ��ʼ��

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
        OnAwake();
    }

    private void Start()
    {
        OnStart();
    }

    protected virtual void OnAwake()
    {

    }

    protected virtual void OnStart()
    {

    }

    public virtual void Close(params object[] args)
    {
        SetVisible(false);//���ص�ǰ��ͼ
    }

    public void DestroyView()
    {
        //�������ٵ�ǰ��ͼ
    }

    public virtual void InitData()
    {
        _isInit = true;
    }

    public virtual void InitUI()
    {

    }

    public bool IsInit
    {
        get { return _isInit; }//��ͼ�Ƿ��ʼ��
    }

    public bool IsShow 
    {
        get { return _canvas.enabled == true; }//�Ƿ���ʾ
    }
    
    public virtual void Open(params object[] args)
    {

    }

    public void SetVisible(bool value)
    {
        _canvas.enabled = value;
    }

    public GameObject Find(string res)
    {
        if (viewObjs.ContainsKey(res))
        {
            return viewObjs[res];
        }
        else
        {
            viewObjs.Add(res, transform.Find(res).gameObject);
            return viewObjs[res];
        }
    }

    public T Find<T>(string res) where T : Component
    {
        return Find(res).GetComponent<T>();
    }
}
