using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<TruckDurability>(out TruckDurability player))
        {
            player.TakeDamage();
            gameObject.SetActive(false);
        }
    }
}
