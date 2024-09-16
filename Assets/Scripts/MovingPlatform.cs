using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : PatrollingEntity
{

    private void Update()
    {
        MoveHorizontal();
    }

    public float GetEndPos()
    {
        return endPos;
    }

}
