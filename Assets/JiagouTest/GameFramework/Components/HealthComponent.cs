using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    public GameObject healthBar;
    public Image healthBarImage;
    public Entity entityData;
    public float value;
    private void Start()
    {
        entityData = GetComponent<Entity>();
        GameApp.gameEventSystem.AddEvent(TempEventDefine.onHealthChange, OnHealthChangeTest);
        //这下必须要写viewsystem了
    }

    public void OnHealthChangeTest(object args = null)
    {
        entityData.currentHealth -= 10;
        value = entityData.currentHealth/entityData.maxHealth;
        healthBarImage.fillAmount = value;
    }
}
