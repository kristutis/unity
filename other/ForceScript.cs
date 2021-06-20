using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceScript : MonoBehaviour
{
    private float power = 0f;
    private bool mouseWasOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mouseWasOn = true;
            power += Time.deltaTime;
            GetComponent<Renderer>().material.color = new Color(power, 0, 0);
        }

        if (mouseWasOn && !Input.GetMouseButton(0))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.position = Vector3.zero;
        }
    }

    void Shoot()
    {
        Debug.Log(power);
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().AddForce(power * 100, 0, 0);
        power = 0f;
        mouseWasOn = false;
    }
}
