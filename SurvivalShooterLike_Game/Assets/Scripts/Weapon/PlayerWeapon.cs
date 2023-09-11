using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform weapon;

    private Transform aimTransform;


    private void Awake()
    {
        aimTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        AimHandler();
        ShootingHandler(true);
    }

    #region Handlers
    private void AimHandler()
    {
        Vector3 mousePosition = GameManager.instance.GetMousePosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void ShootingHandler()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, weapon.position, weapon.rotation);
        }
    }   

    private void ShootingHandler(bool multiPowerUp)
    {
        if (Input.GetButtonDown("Fire1") && multiPowerUp)
        {
            Instantiate(bulletPrefab, weapon.position, weapon.rotation);
            Instantiate(bulletPrefab, weapon.position, Quaternion.Euler(0f, 0f, -60f));
            Instantiate(bulletPrefab, weapon.position, Quaternion.Euler(0f, 0f, -120f));
        }
    }
    #endregion
}
