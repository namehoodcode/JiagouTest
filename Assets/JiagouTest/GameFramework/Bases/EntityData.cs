using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//实体数据，血量，移速等
public class EntityData : MonoBehaviour
{
    public float moveSpeed;
    public float maxHealth;
    public float currentHealth;

    public virtual void Start()
    {
        currentHealth = maxHealth;
    }
}
