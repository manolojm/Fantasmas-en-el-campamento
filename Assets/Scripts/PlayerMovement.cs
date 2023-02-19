using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody rb;
    public CharacterController characterController;
    public float speed = 10f;

    // Gravedad
    public float gravity = -9.8f;
    Vector3 velocity;

    //Salto
    public float jumpHeight = 300f;

    //GroundCheck
    public Transform groundCheck;
    public float sphereRadius = 0.3f;
    public LayerMask groundMask;
    bool isGrounded;

    // Respawn
    public GameObject puntoRespawn;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        // Movimiento
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);

        // Gravedad
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        //GroundCheck
        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);
        if (isGrounded && velocity.y < 0) {
            velocity.y = -2;
        }
        //Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Respawn")) {
            Respawn();
        }
    }

    private void Respawn() {
        Debug.Log("El punto: " + puntoRespawn.transform.position);
        Debug.Log("Estoy" + transform.position);
        //rb.transform.position = puntoRespawn.transform.position;
        transform.position = new Vector3(0, 0, 0);
    }
}
