using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : PatrollingEntity
{

    public Animator animator;

    private void Update()
    {
        MoveHorizontal();
        SwitchDirection();
    }

    private void SwitchDirection()
    {
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }

        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 position = transform.position;
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            PlayerController player_controller = collision.gameObject.GetComponent<PlayerController>();
            if (horizontal>0 && player_controller.getPlayerPosition()<position.x || 
                horizontal<0 && player_controller.getPlayerPosition()>position.x)
            {
                
                if(horizontal>0)
                {
                    horizontal = -1f;
                }

                else if(horizontal<0)
                {
                    horizontal = 1f;
                }
            }
            SoundManager.Instance.Play(Sounds.EnemyAttack);
            animator.Play("Enemy_Attack");
            player_controller.KillPlayer();           
        }
    }

}
