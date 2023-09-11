using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpContainer : MonoBehaviour
{
    [SerializeField] private Transform lifePowerUP;
    [SerializeField] private Transform multiShotPowerUP;
    [SerializeField] private Transform velocityPowerUP;

    public Transform GetLifePowerUp()
    {
        return lifePowerUP;
    }    
    
    public Transform GetMultiShotPowerUp()
    {
        return multiShotPowerUP;
    }    
    
    public Transform GetVelocityPowerUp()
    {
        return velocityPowerUP;
    }

}
