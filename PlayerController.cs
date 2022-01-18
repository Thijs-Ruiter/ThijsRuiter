using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 30;
    private float turnSpeed = 90;
    public float check = 0;
    private float horizontalInput;
    private float forwardInput;
    private bool collided;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        // Move the vehicle forward
        if (collided)
        {
            speed = 30;
            collided = true;
        }
        if (!collided)
        {
            if (speed != 0)
            {
                speed = speed - 1;
            }
        }
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Forward");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }

    private void OnCollisionExit()
    {
        collided =false;
    }

    private void OnCollisionStay()
    {
        collided =true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            transform.position = new Vector3(0, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}