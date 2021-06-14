using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    bool landing = false;
    bool up = false;
    bool left = false;
    bool right = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            up = true;
        }
        else
        {
            up = false;
        }
        if (Input.GetMouseButton(1))
        {
            landing = true;
        }
        else
        {
            landing = false;
        }
        left = Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.D);
    }

    private void FixedUpdate()
    {
        if (landing)
        {
            GetComponent<Rigidbody>().AddForce(transform.up * 9f);
        }
        else if (up)
        {
            GetComponent<Rigidbody>().AddForce(transform.up * 11f);
        }
        else
        {
            GetComponent<Rigidbody>().AddForce(transform.up * 9.8f);
        }

        if (left)
        {
            GetComponent<Rigidbody>().AddForce(-transform.right * 9.8f);
        }
        if (right)
        {
            GetComponent<Rigidbody>().AddForce(transform.right * 9.8f);
        }
    }
}
