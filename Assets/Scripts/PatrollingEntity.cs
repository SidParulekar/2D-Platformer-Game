using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingEntity : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float horizontal;

    [SerializeField] protected float startPos;
    [SerializeField] protected float endPos;

    public void MoveHorizontal()
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
}
