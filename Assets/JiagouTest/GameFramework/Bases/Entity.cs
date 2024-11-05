using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//实体数据，血量，移速等
public class Entity : MonoBehaviour
{
    [Header("实体通用数据")]
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
