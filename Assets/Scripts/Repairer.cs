using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repairer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<TruckDurability>(out TruckDurability player))
        {
            player.Repair();
            gameObject.SetActive(false);
        }
    }
}
