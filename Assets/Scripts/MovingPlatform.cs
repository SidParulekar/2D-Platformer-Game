using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private float speed = 0.5f;
    private float horizontal = 1f;

    public float start_pos;
    public float end_pos;

    private void Update()
    {
        MoveHorizontal();
    }

    private void MoveHorizontal()
    {
        Vector3 position = transform.position;
        if (position.x <= start_pos)
        {
            horizontal = 1f;
        }

        else if (position.x >= end_pos)
        {
            horizontal = -1f;
        }

        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;

    }

}
