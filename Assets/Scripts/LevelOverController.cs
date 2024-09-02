using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>())
        {
            SoundManager.Instance.Play(Sounds.PlayerTeleport);
            Debug.Log("Level completed!");
            LevelManager.Instance.LevelComplete();  
        }
    }
}
