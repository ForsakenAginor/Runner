using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class InputHandler : MonoBehaviour
{
    private PlayerMover _mover;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if( Input.GetKeyUp(KeyCode.W) )
        {
            _mover.TryMoveUp();
        }

        if( Input.GetKeyUp(KeyCode.S) )
        {
            _mover.TryMoveDown();
        }
    }
}
