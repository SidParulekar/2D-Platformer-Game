using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeEnemyTrigger : MonoBehaviour
{
    [SerializeField] private GameObject chargeEnemyController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            chargeEnemyController.SetActive(true);
        }
    }           
}
