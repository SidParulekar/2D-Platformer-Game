using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorUp : MonoBehaviour
{

    private float speed = 0.5f;

    public float end_pos;

    private bool elevator_active;

    private void Update()
    {
        if (elevator_active)
        {
            MoveUp();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            elevator_active = true;
        }
    }

    private void MoveUp()
    {
        Vector3 position = transform.position;

        if (position.y >= end_pos)
        {
            elevator_active = false;
        }

        else
        {
            position.y = position.y + speed * Time.deltaTime;
            transform.position = position;
        }   

    }
}
