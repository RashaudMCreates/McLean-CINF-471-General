using UnityEngine;
using UnityEngine.InputSystem;


public class UniGunner : MonoBehaviour
{

//New Experimental Code
    GunnerBaseState currentState;

    [HideInInspector]
    public GunnerIdleState idleState = new GunnerIdleState();

    [HideInInspector]
    public GunnerWalkState walkState = new GunnerWalkState();

    [HideInInspector]
    public GunnerSneakState sneakState = new GunnerSneakState();

    [HideInInspector]
    public GunnerSprintState sprintState = new GunnerSprintState();

    [HideInInspector]
    public GunnerSlideState slideState = new GunnerSlideState();

    [HideInInspector]
    public Vector2 movement;
    CharacterController controller;

    [SerializeField]
    public float default_speed = 1;

    [HideInInspector]
    public bool isSneaking = false;

    [HideInInspector]
    public bool isSprinting = false;

    [HideInInspector]
    public bool isSliding = false;

    //Will figure out how to make a sliding State Eventually




//Basic Movement Variable (Deleting reused variables)
    Vector2 mouseMovement;
    float cameraUpRotation = 0;
//End Of Basic Movement

    //Mouse Settings
    [SerializeField]
    float mouseSensitivity = 100;
    [SerializeField]
    GameObject cam;
    //End Of Mouse Settings

    //Bullet Variables
    [SerializeField]
    GameObject bulletSpawner;
    [SerializeField]
    GameObject bullet;
    //End Of Bullet Variables

    //Variable for minigun to spin
    [SerializeField]
    GameObject Minigun;

    //Jumping Code
    bool hasJumped = false;
    float ySpeed = 0;
    [SerializeField]
    float jumpHeight = 1.0f;
    [SerializeField]
    float gravityVal = 9.8f;
    //Jumping Code End

    //Sliding Variables
    public float slideScale = 0.5f;
    public float slideSize = 0.467f;
    public float normalSize = 0.967f;
    public Transform PlayerObject;
    public GameObject InsertPlayer;
    //Sliding Variables End



    void Start()
    {
        PlayerObject = InsertPlayer.GetComponent<Transform>();

        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;

        SwitchState(idleState);
    }

    void Update()
    {
        
        //Shooting Code
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
                Minigun.transform.Rotate(0, 150, 0);
            }
        //End of Shooting Code

        

        currentState.UpdateState(this);
    }

//Camera Stuff?
    void OnLook(InputValue lookVal)
    {
        mouseMovement = lookVal.Get<Vector2>();
    }
//End of Camera Stuff?

    void OnAttack()
    {
        Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
    }


    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();
    }

    void OnSprint()
    {
        if (isSprinting == false)
        {
            isSprinting = true;
        } else
        {
            isSprinting = false;
        }
    }

    void OnCrouch(InputValue crouchVal) 
    {
        if (crouchVal.isPressed) 
        {
            isSneaking = true;
        } else 
        {
            isSneaking = false;
        }
    }

    public void MovePlayer(float speed)
    {
        float moveX = movement.x;
        float moveZ = movement.y;

        Vector3 actual_movement = (transform.forward * moveZ) + (transform.right * moveX);
        

        //Jumping Code
            if (hasJumped)
            {
                hasJumped = false;
                ySpeed = jumpHeight;
            }

            //actual_movement.y = ySpeed;
        //Jumping Code End

        controller.Move(actual_movement * Time.deltaTime * speed);
    }

    public void ApplyGravity() 
    {
        ySpeed -= gravityVal * Time.deltaTime; //Apply gravity
        Vector3 gravity = new Vector3(0,ySpeed,0);
        controller.Move(gravity);

    }

    public void SwitchState(GunnerBaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }

//Jump Code Obv
    void OnJump()
    {
        Debug.Log("space pressed");
        if (controller.isGrounded)
        {
            hasJumped = true;
            Debug.Log("is grounded");
        }
    }
//Jump Code End

    public void CAMERALOOKY()
    {
    //Camera Controls
        float lookx = mouseMovement.x * Time.deltaTime * mouseSensitivity;
        float looky = mouseMovement.y * Time.deltaTime * mouseSensitivity;

        cameraUpRotation -= looky;

        cameraUpRotation = Mathf.Clamp(cameraUpRotation, -90, 90);

        cam.transform.localRotation = Quaternion.Euler(cameraUpRotation, 0, 0);

        transform.Rotate(Vector3.up * lookx);
    //End of Camera Controls
    }
}