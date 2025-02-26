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

    //Experimental Sliding Code
    /*[HideInInspector]
    public float maxSlideTime;
    public float slideForce;
    private float slideTimer;

    public float slideYScale;
    public float startYScale;

    public KeyCode slideKey = KeyCode.Z;
    private float horizontalInput;
    private float verticalInput;

    private bool isSliding;*/




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

    float scale = 0.5f;
    float y = 0.467f;
    float x = 0.967f;
    Transform t;
    public GameObject cube;



    void Start()
    {
        t = cube.GetComponent<Transform>();

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

        //Camera Controls
            float lookx = mouseMovement.x * Time.deltaTime * mouseSensitivity;
            float looky = mouseMovement.y * Time.deltaTime * mouseSensitivity;

            cameraUpRotation -= looky;

            cameraUpRotation = Mathf.Clamp(cameraUpRotation, -90, 90);

            cam.transform.localRotation = Quaternion.Euler(cameraUpRotation, 0, 0);

            transform.Rotate(Vector3.up * lookx);
        //End of Camera Controls

        currentState.UpdateState(this);

        //Sneaking Code (Mickey Moused it)
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isSneaking = true;
            Debug.Log("isSneaking=true");
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isSneaking = false;
            Debug.Log("isSneaking=false");
        }

        //Sliding Code
        if(isSprinting && isSneaking) 
        {
            isSliding = true;
            Debug.Log("isSliding=true");
            transform.localScale = new Vector3 (1,scale,1);
            transform.localPosition = new Vector3(t.position.x, y, t.position.z);
        } else
        {
            isSliding = false;
            Debug.Log("isSliding=false");
            transform.localScale = new Vector3 (1,1,1);
            transform.localPosition = new Vector3(t.position.x, x, t.position.z);
        }
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

    public void MovePlayer(float speed)
    {
        float moveX = movement.x;
        float moveZ = movement.y;

        Vector3 actual_movement = (transform.forward * moveZ) + (transform.right * moveX);
        controller.Move(actual_movement * Time.deltaTime * speed);

        //Jumping Code
            if (hasJumped)
            {
                hasJumped = false;
                ySpeed = jumpHeight;
            }


            ySpeed -= gravityVal * Time.deltaTime;
            actual_movement.y = ySpeed;
        //Jumping Code End
    }

    public void SwitchState(GunnerBaseState newState)
    {
        currentState = newState;
        currentState.EnterState(this);
    }


//Jump Code Obv
    void OnJump()
    {
        if (controller.isGrounded)
        {
            hasJumped = true;
        }
    }
//Jump Code End
}