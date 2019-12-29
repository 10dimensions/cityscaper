using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{   
    [SerializeField] private float RotateSpeed;
    [SerializeField] private float MoveSpeed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {   
        //transform.Translate(Vector3.forward * Input.GetAxis("Vertical")*MoveSpeed/100*Time.deltaTime);
        //rb.velocity = transform.forward * Input.GetAxis("Vertical")*MoveSpeed * Time.deltaTime;

        //rb.AddForce(transform.forward * Input.GetAxis("Vertical")*MoveSpeed * Time.deltaTime);

        rb.MovePosition(transform.localPosition + transform.forward * Input.GetAxis("Vertical")*MoveSpeed * Time.deltaTime);

        transform.Rotate(0, Input.GetAxis ("Horizontal")*RotateSpeed*Time.deltaTime, 0);
    }
}
