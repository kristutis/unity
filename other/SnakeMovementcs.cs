using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private float max = 4f;

    public GameObject snakeObj;
    public GameObject tailPrefab;
    public GameObject lastTail;
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            snakeObj.transform.Rotate(new Vector3(0, 90, 0));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            snakeObj.transform.Rotate(new Vector3(0, -90, 0));
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(snakeObj.transform.rotation.y);
        if (snakeObj.transform.rotation.y == 0f)
        {
            transform.position += new Vector3(0, 0, -speed);
        }
        if (snakeObj.transform.rotation.y == -1f)
        {
            
            transform.position += new Vector3(0, 0, speed);
        }
        if (snakeObj.transform.rotation.y == 90)
        {
            transform.position += new Vector3(0, 0, -speed);
        }
        if (snakeObj.transform.rotation.y == -90)
        {
            transform.position += new Vector3(0, 0, -speed);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "food")
        {
            other.gameObject.transform.position = new Vector3(Random.Range(-max, max), 0.2f, Random.Range(-max, max));
            GameObject newTail = Instantiate(tailPrefab, lastTail.transform.position + new Vector3(0, 0, 0.4f), Quaternion.identity);
            newTail.GetComponent<HingeJoint>().connectedBody = lastTail.GetComponent<Rigidbody>();
            lastTail = newTail;

            speed += 0.01f;
        }
    }
}
