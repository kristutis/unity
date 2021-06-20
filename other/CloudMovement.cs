using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float force = 5f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<ParticleSystem>().Stop();
    }

    public float timer = 0f;
    private bool move = true;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer < 10)
        {
            MoveRandom();
        }
        else if (timer >= 10 && timer < 20 && move)
        {
            MoveCenter();
        }
        if (timer > 20)
        {
            MoveRandom();
        }
    }

    void MoveRandom()
    {
        GetComponent<Rigidbody>().AddForce(Random.Range(-force, force), 0, Random.Range(-force, force));
    }

    void MoveCenter()
    {
        if (transform.position.x > 0 && transform.position.z > 0)
        {
            GetComponent<Rigidbody>().AddForce(-force, 0, -force);
        }
        if (transform.position.x < 0 && transform.position.z < 0)
        {
            GetComponent<Rigidbody>().AddForce(force, 0, force);
        }
        if (transform.position.x < 0 && transform.position.z > 0)
        {
            GetComponent<Rigidbody>().AddForce(force, 0, -force);
        }
        if (transform.position.x > 0 && transform.position.z < 0)
        {
            GetComponent<Rigidbody>().AddForce(-force, 0, force);
        }
        if (Mathf.Abs(transform.position.x) < 5 && Mathf.Abs(transform.position.z) < 5)
        {
            move = false;
            transform.position = new Vector3(Random.Range(-2, 2), transform.position.y, Random.Range(-2, 2));
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            transform.localScale = new Vector3(Random.Range(0.5f, 2), 0.2f, Random.Range(0.5f, 2));
            GetComponentInChildren<ParticleSystem>().Play();
        }
    }
}
