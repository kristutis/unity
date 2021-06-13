using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3.0f;
    public float rotateSpeed = 1.0f;

    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        // Rotate around y - axis
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * speed);
    }
}
