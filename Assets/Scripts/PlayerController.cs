using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(speed));

        /*if(speed<0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 180f, transform.rotation.y);
        }

        else if(speed>0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.y);
        }*/

        Vector3 scale  = transform.localScale;
        if(speed<0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }

        else if(speed>0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
         
    }
}


