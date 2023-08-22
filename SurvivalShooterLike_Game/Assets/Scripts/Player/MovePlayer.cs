using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        MoveHandler();
    }

    #region Handlers
    private void MoveHandler()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * PlayerInfo.instance.GetPlayerVelocity() * Time.deltaTime;
        float moveY = Input.GetAxisRaw("Vertical") * PlayerInfo.instance.GetPlayerVelocity() * Time.deltaTime;
        PlayerInfo.instance.playerTransform.Translate(new Vector2(moveX, moveY).normalized * PlayerInfo.instance.GetPlayerVelocity() * Time.deltaTime);
        PlayerInfo.instance.isMoving = moveX != 0 || moveY != 0;
    }
    #endregion

}
