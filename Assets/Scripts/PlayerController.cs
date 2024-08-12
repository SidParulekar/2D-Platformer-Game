using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D boxCol;

    public float speed;
    public float jump;

    private Rigidbody2D rb2d;

    //Collider Variables
    private Vector2 boxColInitSize;
    private Vector2 boxColInitOffset;

    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //Fetching initial collider properties
        boxColInitSize = boxCol.size;
        boxColInitOffset = boxCol.offset;
    }

    private void Update()
    {
        //Change Movement Direction logic
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        MoveCharacter(horizontal, vertical);
        PlayMovementAnimation(horizontal, vertical);  

    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        transform.position = position;

        if(vertical>0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }

    private void PlayMovementAnimation(float horizontal, float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

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

        /*if(speed<0)
       {
           transform.rotation = Quaternion.Euler(transform.rotation.x, 180f, transform.rotation.y);
       }

       else if(speed>0)
       {
           transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.y);
       }*/

        //Crouch logic
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouch(true);
            animator.Play("Player_Crouch");
        }
        else
        {
            Crouch(false);
        }

        //Jump logic              
        PlayJumpAnimation(vertical);    
       
    }

    private void PlayJumpAnimation(float vertical)
    {  
        if(vertical>0)
        {
            animator.SetBool("Jump", true);
        }
        
        else
        {
            animator.SetBool("Jump", false);
        }
        
    }

    private void Crouch(bool crouch)
    {
        if (crouch == true) // Resizing collider box
        {
            float offX = -0.1147614f;     //Offset X
            float offY = 0.5882833f;      //Offset Y

            float sizeX = 0.9000893f;     //Size X
            float sizeY = 1.328038f;     //Size Y

            boxCol.size = new Vector2(sizeX, sizeY);   //Setting the size of collider
            boxCol.offset = new Vector2(offX, offY);   //Setting the offset of collider
        }

        else
        {
            //Reset collider to initial values
            boxCol.size = boxColInitSize;
            boxCol.offset = boxColInitOffset;
        }
        animator.SetBool("Crouch", crouch);
    }

    
}


