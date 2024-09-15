using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ElevatorController : MonoBehaviour
{

    private float speed = 0.5f;

    [SerializeField] private float endPos;

    private bool elevator_active;

    private float initial_position;

    private void Start()
    {
        Vector3 position = transform.position;
        initial_position = position.y;
    }

    private void Update()
    {
        if(elevator_active)
        {
            Move();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            elevator_active = true; 
        }
    }

    private void Move()
    {
        
        Vector3 position = transform.position;

        if (initial_position> endPos)
        {
            if (position.y <= endPos)
            {
                elevator_active = false;
            }

            else
            {
                position.y = position.y - speed * Time.deltaTime;
                transform.position = position;
            }
        }

        else
        {
            if (position.y >= endPos)
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

}
