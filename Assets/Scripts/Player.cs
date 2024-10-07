using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private float H,V;
    private Vector3 direction;

    [SerializeField]
    private float moveForce;

    [SerializeField]
    private float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        H = Input.GetAxisRaw("Horizontal");
        V = Input.GetAxisRaw("Vertical");
        direction = transform.forward * V + transform.right * H;
    }

    private void FixedUpdate()
    {
        rb.AddForce(direction.normalized * moveForce, ForceMode.Force);

        VelocidadLimitada();
    }

    private void VelocidadLimitada()
    {
        Vector3 velocidadPlanoZX = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        Vector3 velocidadDelimitada = Vector3.ClampMagnitude(velocidadPlanoZX, maxSpeed);
        rb.velocity = new Vector3(velocidadDelimitada.x, rb.velocity.y, velocidadDelimitada.z);
    }
}
