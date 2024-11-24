using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private float horizontal;
    private float vertical;

    [SerializeField]
    private float moveSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward,new Vector3(1,0,1)).normalized;

        Vector3 moveForward = cameraForward * vertical + Camera.main.transform.right * horizontal;

        rb.velocity = moveForward * moveSpeed + new Vector3(0, rb.velocity.y, 0);

        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }
}
