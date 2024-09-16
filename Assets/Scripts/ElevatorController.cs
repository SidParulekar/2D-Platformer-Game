using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ElevatorController : MonoBehaviour
{

    private float speed = 0.5f;

    [SerializeField] private float endPos;

    private bool elevatorActive;

    private float initialPosition;

    private void Start()
    {
        Vector3 position = transform.position;
        initialPosition = position.y;
    }

    private void Update()
    {
        if(elevatorActive)
        {
            Move();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            elevatorActive = true; 
        }
    }

    private void Move()
    {
        
        Vector3 position = transform.position;

        if (initialPosition > endPos)
        {
            if (position.y <= endPos)
            {
                elevatorActive = false;
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
                elevatorActive = false;
            }

            else
            {
                position.y = position.y + speed * Time.deltaTime;
                transform.position = position;
            }
        }
    }

}
