using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpLifePlus : MonoBehaviour
{
    [Header ("Power Up Info")]
    [SerializeField] private Button button;
    [SerializeField] private string name;
    [SerializeField] private Sprite icon;

    [Header ("Prefab Child Components")]
    private Image powerUpIcon;
    private TextMeshProUGUI powerUpNameText;

    private void Awake()
    {
        button.onClick.AddListener(LifeIncrease);
        powerUpIcon.sprite = icon;
        powerUpNameText.text = name;
    }

    private void LifeIncrease()
    {
        PlayerInfo.instance.LifeHandler(1);
        Time.timeScale = 1;
        UIManager.instance.SetPowerUpContainer(false);
    }
}
