using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    public static PlayerWeapon instance;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform weapon;

    public Transform aimTransform { get; private set; }

    public bool multiShot { get; set; } = false;

    private void Awake()
    {
        #region Singleton
        if (instance == null)
        {
            instance = this;
        }
        #endregion
        aimTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        AimHandler();
        if (multiShot)
        {
            MultiShootingHandler();
        }
        SingleShootingHandler();
    }

    #region Handlers
    private void AimHandler()
    {
        Vector3 mousePosition = GameManager.instance.GetMousePosition();
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);
        FlipSpritesToAimDirection(aimDirection);
    }

    private void SingleShootingHandler()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, weapon.position, weapon.rotation.normalized);
        }

    }   

    private void MultiShootingHandler()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, weapon.position, weapon.rotation.normalized);
            Instantiate(bulletPrefab, weapon.position, weapon.rotation.normalized * Quaternion.Euler(0f, 0f, 15f));
            Instantiate(bulletPrefab, weapon.position, weapon.rotation.normalized * Quaternion.Euler(0f, 0f, -15f));
        }
    }
    #endregion

    private void FlipSpritesToAimDirection(Vector3 aimDirection)
    {
        if (aimDirection.x < 0)
        {
            PlayerInfo.instance.spriteRenderer.flipX = true;
            weapon.GetComponent<SpriteRenderer>().flipY = true;
        }
        else if (aimDirection.x > 0)
        {
            PlayerInfo.instance.spriteRenderer.flipX = false;
            weapon.GetComponent<SpriteRenderer>().flipY = false;
        }
    }

}
