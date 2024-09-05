using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnemyTrigger : MonoBehaviour
{
    public GameObject charge_enemy_controller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            charge_enemy_controller.SetActive(true);
        }
    }           
}
