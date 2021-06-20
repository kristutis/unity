using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float timer = 0f;
    bool colliding = false;
    // Update is called once per frame
    void Update()
    {
        if (timer > 1)
        {
            timer = 0f;
            if (colliding)
            {
                GetComponent<Rigidbody>().AddForce(0, 200, 0);
            }
        }
        else
        {
            timer += Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-0.02f, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.02f, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        colliding = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        colliding = false;
    }
}
