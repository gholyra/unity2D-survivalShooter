using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

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
        FlipSprite(moveX);
    }
    #endregion

    private void FlipSprite(float moveX)
    {
        if (moveX < 0)
        {
            PlayerInfo.instance.spriteRenderer.flipX = true;
        }
        else if (moveX > 0)
        {
            PlayerInfo.instance.spriteRenderer.flipX = false;
        }
    }

}
