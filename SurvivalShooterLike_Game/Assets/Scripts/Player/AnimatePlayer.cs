using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlayer : MonoBehaviour
{

    void Update()
    {
        AnimationHandler();
    }

    #region Handlers
    private void AnimationHandler()
    {
        bool isMovingAnimation = PlayerInfo.instance.playerAnimator.GetBool("isMoving");
        bool isHurtAnimation = PlayerInfo.instance.playerAnimator.GetBool("isHurt");

        if (PlayerInfo.instance.isMoving && !isMovingAnimation)
        {
            PlayerInfo.instance.playerAnimator.SetBool("isMoving", true);
        }
        else if (!PlayerInfo.instance.isMoving && isMovingAnimation)
        {
            PlayerInfo.instance.playerAnimator.SetBool("isMoving", false);
        }

        if (PlayerInfo.instance.isHurt && !isHurtAnimation)
        {
            PlayerInfo.instance.playerAnimator.SetBool("isHurt", true);
            PlayerInfo.instance.isHurt = false;
        }
        else if (!PlayerInfo.instance.isHurt && isHurtAnimation)
        {
            PlayerInfo.instance.playerAnimator.SetBool("isHurt", false);
        }
    }
    #endregion

}
