using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;

    int floorMask;
    float camRayLength = 100f;
    public Vector3 jump;
    public float jumpForce = 3.0f;
    //public bool isGrounded;
    public AudioSource Rabbitjump;

    public int points = 0;
    public Text Cakepoint;
    public Text FloorTalking;

    public GameObject WinPanel;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        playerRigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        jump = new Vector3(0.0f, 3.0f, 0.0f);
    }

    void FixedUpdate()
    {
        float v = Input.GetAxisRaw("Horizontal") * 1;
        float h = Input.GetAxisRaw("Vertical") * -1;


        if (GameObject.Find("Canvas").GetComponent<StartgameButton>().gamestarted && points < 10)
        { 
        Move(h, v);
        Animating(h, v);
        Turning();
         }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            playerRigidbody.AddForce(jump * jumpForce, ForceMode.Impulse);
            FloorTalking.text = "Do you Know? You can jump more than one time!";
            Rabbitjump.Play();
        }

        if(points==10)
        {
            WinPanel.SetActive(true);
        }
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cake")
        {
            points += 1;
            Cakepoint.text = points + "/10";
            Destroy(other.gameObject);
        }
    }
}
/*
void OnCollisionExit(Collision other)
{
if (other.gameObject.tag == "Ground")
{
    isGrounded = false;
}
*/
