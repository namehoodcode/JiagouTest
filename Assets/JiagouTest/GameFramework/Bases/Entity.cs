using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ʵ�����ݣ�Ѫ�������ٵ�
public class Entity : MonoBehaviour
{
    [Header("ʵ��ͨ������")]
    public float moveSpeed;
    public float maxHealth;
    public float currentHealth;
    [SerializeField] protected Vector2 moveDir;
    [SerializeField] protected Vector2 currentVelocity;

    protected Rigidbody2D rb;

    public event Func<float, bool> commandUpdates;
    public virtual void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Update()
    {
        currentVelocity = rb.velocity;
        commandUpdates?.Invoke(Time.deltaTime);
    }
}
