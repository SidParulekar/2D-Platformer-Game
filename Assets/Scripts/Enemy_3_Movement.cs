using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_3_Movement : MonoBehaviour
{
    private float speed = 0.5f;
    private float horizontal = 1f;

    public float start_pos;
    public float end_pos;

    private void Update()
    {
        MoveEnemy();
        PlayMovementAnimation();
    }

    private void PlayMovementAnimation()
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
        if (position.x <= 17.5f)
        {
            horizontal = 1f;
        }

        else if (position.x >= 21.15f)
        {
            horizontal = -1f;
        }

        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;
    }
}
