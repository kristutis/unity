using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMovement : MonoBehaviour
{
    public int obstaclCount = 5;
    public GameObject obstacle;
    public float speed = 2f;

    private bool collidingPlane = true;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < obstaclCount; i++)
        {
            GameObject newObstacle = Instantiate(obstacle, new Vector3(0, 0.21f, Random.Range(5f, 40f)), Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && collidingPlane)
        {
            GetComponent<Rigidbody>().AddForce(transform.up * 200);
        }
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Respawn")
        {
            transform.position = new Vector3(0, 0.71f, 0);
        }
        if (collision.gameObject.name == "Plane")
        {
            collidingPlane = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            collidingPlane = false;
        }
    }
}
