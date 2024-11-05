using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeShowComponent : MonoBehaviour
{
    float currentTime;
    public TextMeshProUGUI TimeText;
    private void Start()
    {
        currentTime = 0;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        UpdateText();
    }

    private void UpdateText()
    {
        TimeText.text = currentTime.ToString();
    }
}
