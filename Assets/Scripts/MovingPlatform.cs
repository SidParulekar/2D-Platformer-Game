using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private float speed = 0.5f;
    private float horizontal = 1f;

    [SerializeField] private float startPos;
    [SerializeField] private float endPos;

    private void Update()
    {
        MoveHorizontal();
    }

    private void MoveHorizontal()
    {
        Vector3 position = transform.position;
        if (position.x <= startPos)
        {
            horizontal = 1f;
        }

        else if (position.x >= endPos)
        {
            horizontal = -1f;
        }

        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;

    }

    public float getEndPos()
    {
        return endPos;
    }

}
