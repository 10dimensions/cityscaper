using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{   
    [SerializeField] private float RotateSpeed;
    [SerializeField] private float MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical")*MoveSpeed/100*Time.deltaTime);
        transform.Rotate(0, Input.GetAxis ("Horizontal")*RotateSpeed*Time.deltaTime, 0);
    }
}
