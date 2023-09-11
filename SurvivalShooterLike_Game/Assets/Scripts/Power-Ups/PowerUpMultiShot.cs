using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpMultiShot : MonoBehaviour
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
        button.onClick.AddListener(UnlockMultiShot);
        powerUpIcon.sprite = icon;
        powerUpNameText.text = name;
    }

    private void UnlockMultiShot()
    {
        PlayerWeapon.instance.multiShot = true;
        Time.timeScale = 1;
        UIManager.instance.SetPowerUpContainer(false);
        UIManager.instance.GetPowerUpContainer().GetComponent<PowerUpContainer>().GetMultiShotPowerUp().gameObject.SetActive(false);

    }
}
