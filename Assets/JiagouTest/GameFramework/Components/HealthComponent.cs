using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthComponent : MonoBehaviour
{
    public GameObject healthBar;
    public Image healthBarImage;
    public EntityData entityData;
    public float value;
    private void Start()
    {
        entityData = GetComponent<EntityData>();
        if(GameApp.gameEventSystem == null) { Debug.Log("ex"); }
        GameApp.gameEventSystem.AddEvent("onHealthChange", OnHealthChangeTest);
        //���±���Ҫдviewsystem��
    }

    public void OnHealthChangeTest(object args = null)
    {
        entityData.currentHealth -= 10;
        value = entityData.currentHealth/entityData.maxHealth;
        healthBarImage.fillAmount = value;
    }
}
