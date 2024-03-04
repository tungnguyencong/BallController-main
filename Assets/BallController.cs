using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;
    public bool IsOnTheGround = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(x, 0, z) * 0.1f, ForceMode.Impulse);

        if (Input.GetButtonDown("Jump") && IsOnTheGround)
        {
            rb.AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);
            IsOnTheGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane")
        {
            IsOnTheGround = true;
        }

    }
}
