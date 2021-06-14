using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    int counter = 0;
    float bounceForce = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            transform.position = new Vector3(0, 2, 0);
        }
        if (counter<10)
        {
            Bounce();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.parent.tag == "wall")
        {
            counter++;
            GetComponent<Renderer>().material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            float newSize = Random.Range(lowerSizeCap, upperSizeCap);
            this.GetComponent<Transform>().localScale = new Vector3(newSize, newSize, newSize);
        }
    }

    void Bounce()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(-bounceForce, bounceForce), 0, Random.Range(-bounceForce, bounceForce)), ForceMode.Impulse);
    }
}
