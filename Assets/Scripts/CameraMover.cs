using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] Transform player;
    
    private void LateUpdate()
    {
        transform.position = player.position;
    }
}
