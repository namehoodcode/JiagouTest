using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


/// <summary>
/// ����ʵ��Ľӿڣ�������д����ʵ�嶼�еĹ���
/// </summary>
public interface IEntity
{
    void Move();
}


//ʵ����Ϊ�ӿ�
//��������һ�¾��巽��ʵ��Ҫд��������ǵ������ԣ��Լ����Ҫ�Ѿ���ʵ��д��command����Ļ�Ҫ���ܶ�Ĵ��κ͵��ã����Ըɴ�ͷ�������
//���䣺���������ķ����Ž������command����
//����Ĳ��䣺�ѹ���ô���Ծ����ܹ����Ǻܺã�Ҫ������һ������ļܹ���