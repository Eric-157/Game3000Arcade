using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody p1playerRb;
    private Rigidbody p2playerRb;
    private float playerSpeed = 2.0f;
    private float jumpForce = 5.0f;
    private float gravityModifier = 1.0f;
    private bool p1IsOnGround = false;
    private bool p2IsOnGround = false;
    public float p1horizontalInput;
    public float p1verticalInput;
    public float p2horizontalInput;
    public float p2verticalInput;
    private GameObject p1;
    private GameObject p2;
    private GameObject p1Cam;
    private GameObject p2Cam;
    //following 2 vars are for the gameOver variable.
    public GameObject script;
    private death deathScript;
    // Start is called before the first frame update
    void Start()
    {
        deathScript = script.GetComponent<death>();
        p1playerRb = GameObject.Find("Player1").GetComponent<Rigidbody>();
        p2playerRb = GameObject.Find("Player2").GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        p1 = GameObject.Find("Player1");
        p2 = GameObject.Find("Player2");
        p1Cam = GameObject.Find("Player1Cam");
        p2Cam = GameObject.Find("Player2Cam");
    }

    // Update is called once per frame
    void Update()
    {
        // Movement for both player 1 and player 2 if not game over
        if (!deathScript.gameOver)
        {
            p1horizontalInput = Input.GetAxis("P1Horizontal");
            p1.transform.Translate(Vector3.right * p1horizontalInput * playerSpeed * Time.deltaTime);
            p1verticalInput = Input.GetAxis("P1Vertical");
            p1.transform.Translate(Vector3.forward * p1verticalInput * playerSpeed * Time.deltaTime);

            p2horizontalInput = Input.GetAxis("P2Horizontal");
            p2.transform.Translate(Vector3.right * p2horizontalInput * playerSpeed * Time.deltaTime);
            p2verticalInput = Input.GetAxis("P2Vertical");
            p2.transform.Translate(Vector3.forward * p2verticalInput * playerSpeed * Time.deltaTime);
        }

        // Jump for player 1
        if (Input.GetKeyDown(KeyCode.Space) && p1IsOnGround && !deathScript.gameOver)
        {
            p1playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            p1IsOnGround = false;
        }

        // Jump for player 2
        if (Input.GetKeyDown(KeyCode.RightShift) && p2IsOnGround && !deathScript.gameOver)
        {
            p2playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            p2IsOnGround = false;
        }
        
        // Camera movement. Will only move on the z axis, with the other 2 axis' being locked.
        p1Cam.transform.position = new Vector3(-12, 16, p1.transform.position.z);
        p2Cam.transform.position = new Vector3(12, 16, p2.transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Following 2 check for respective player being on ground.
        if (collision.gameObject.CompareTag("p1Ground"))
        {
            p1IsOnGround = true;
        }

        if (collision.gameObject.CompareTag("p2Ground"))
        {
            p2IsOnGround = true;
        }
    }
}
