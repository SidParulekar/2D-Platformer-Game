using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            PlayerController player_controller = collision.gameObject.GetComponent<PlayerController>();
            player_controller.PickUpKey();
            Destroy(gameObject);
        }
    }
}
