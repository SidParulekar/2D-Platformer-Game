using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnemyController : MonoBehaviour
{
    public Animator animator;

    private float speed = 2.5f;
    private float horizontal = -1f;

    public float start_pos;
    public float end_pos;

    private void Start()
    {
        animator.Play("Enemy_Charge");
    }

    private void Update()
    { 
       MoveEnemy();
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

    private void MoveEnemy()
    {
        Vector3 position = transform.position;
        if (position.x <= end_pos)
        {
            horizontal = 1f;
        }

        else if (position.x >= start_pos)
        {
            horizontal = -1f;
        }

        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 position = transform.position;
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            PlayerController player_controller = collision.gameObject.GetComponent<PlayerController>();
            if (horizontal > 0 && player_controller.getPlayerPosition() < position.x ||
                horizontal < 0 && player_controller.getPlayerPosition() > position.x)
            {

                if (horizontal > 0)
                {
                    horizontal = -1f;
                }

                else if (horizontal < 0)
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
