using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpVelocityPlus : MonoBehaviour
{
    [Header ("Power Up Info")]
    [SerializeField] private Button button;
    [SerializeField] private new string name;
    [SerializeField] private Sprite icon;

    [Header ("Prefab Child Components")]
    [SerializeField] private TextMeshProUGUI powerUpNameText;
    [SerializeField] private Image powerUpIcon;

    private void Awake()
    {
        button.onClick.AddListener(VelocityIncrease);
        powerUpIcon.sprite = icon;
        powerUpNameText.text = name;
    }

    private void VelocityIncrease()
    {
        PlayerInfo.instance.SetPlayerVelocity(2f);
        Time.timeScale = 1;
        UIManager.instance.SetPowerUpContainer(false);
    }
}
