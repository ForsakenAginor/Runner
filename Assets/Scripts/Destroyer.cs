using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<EnemyMover>(out EnemyMover enemy))        
            enemy.gameObject.SetActive(false);        
    }
}
