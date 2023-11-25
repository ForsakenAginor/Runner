using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refiller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<FuelTank>(out FuelTank player))
        {
            player.Refuel();
            gameObject.SetActive(false);
        }
    }
}
