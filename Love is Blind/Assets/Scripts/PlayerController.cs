using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour {


    //Variables
    [SerializeField] private float moveSpeed;
    private float jumpVelocity = 14f;

    private float lowJumpMultiplyer = 3f;
    private float jumpCount;
    private float targetTime = 3f;
    private int flashCount = 3;

    public int numberOfLives = 3;

    public Text flashCounter;
    public bool used;

    //Potential Variables
    private bool isGrounded = true;
    private bool timerTriggered = false;
    public bool flashing;
    private Rigidbody myRigidBody;
    private GameObject worldSpawn;

    private void Start()
    {
        used = false;
        myRigidBody = GetComponent<Rigidbody>();
        worldSpawn = GameObject.FindGameObjectWithTag("World Spawn");
        flashCount = 3;
    }

    private void Update()
    {
        Flash();
        GroundCheck();
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }


    public void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0) * moveSpeed * Time.deltaTime;
        myRigidBody.MovePosition(gameObject.transform.position + movement);
        if(Input.GetAxisRaw("Horizontal")> 0f)
        {
            transform.localScale = new Vector3(1, 1, 1);

        }else if(Input.GetAxisRaw("Horizontal")< 0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
       
    }

    public void Jump()
    {
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myRigidBody.velocity = Vector3.up * jumpVelocity;
        }
        if(jumpCount != 1 && Input.GetButtonDown("Jump") && isGrounded)
        {
            myRigidBody.velocity = Vector3.up * jumpVelocity;
            jumpCount = 1;
        }
        if (myRigidBody.velocity.y < 0)
        {
            myRigidBody.velocity += Vector3.up * Physics.gravity.y * Time.deltaTime;
        }
        else if (myRigidBody.velocity.y > 0 && !Input.GetButtonDown("Jump"))
        {
            myRigidBody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplyer - 1) * Time.deltaTime;
        }
    }

    public void GroundCheck()
    {
        RaycastHit hit;
        Vector3 physicsCentre = this.transform.position + this.GetComponent<CapsuleCollider>().center;
        
        if(Physics.Raycast(physicsCentre, Vector3.down, out hit, 1f))
        {
            isGrounded = true;
            jumpCount = 0;
        }
        else
        {
            isGrounded = false;
        }
    }

    public void Flash()
    {

        if (Input.GetKeyDown(KeyCode.F) && flashCount != 0)
        {
            if (!flashing)
            {
                flashing = true;
                timerTriggered = true;
                flashCount -= 1;
                flashCounter.text = "\n" + flashCount.ToString();
            }
        }
        if (timerTriggered)
        {
            targetTime -= Time.deltaTime;
            if(targetTime <= 0)
            {
                flashing = false;
                targetTime = 3;
                timerTriggered = false;
            }
        }

    }


    public void TeleportToWorldSpawn()
    {
        gameObject.transform.position = worldSpawn.transform.position;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag.Contains("Goal"))
        {
            Debug.Log("You have reached your goal");
        }
        
    }
}
