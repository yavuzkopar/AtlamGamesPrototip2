using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] DynamicJoystick joystick;
    public int a;
    public Transform finalPos;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
       rb.velocity = new Vector3(joystick.Horizontal,0,joystick.Vertical) *7;
    }
    
}
