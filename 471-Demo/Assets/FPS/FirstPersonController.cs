using UnityEngine;
using UnityEngine.InputSystem;


public class FirstPersonController : MonoBehaviour
{
Vector2 movement;
Vector2 mouseMovement;
float cameraUpRotation = 0;
CharacterController controller;
[SerializeField]
float speed = 2.0f;
[SerializeField]
float mouseSensitivity = 100;
[SerializeField]
GameObject cam;
[SerializeField]
GameObject bulletSpawner;
[SerializeField]
GameObject bullet;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
            Minigun.transform.Rotate(0, 150, 0);

        }

        float lookx = mouseMovement.x * Time.deltaTime * mouseSensitivity;
        float looky = mouseMovement.y * Time.deltaTime * mouseSensitivity;

        cameraUpRotation -= looky;

        cameraUpRotation = Mathf.Clamp(cameraUpRotation, -90, 90);

        cam.transform.localRotation = Quaternion.Euler(cameraUpRotation, 0, 0);

        transform.Rotate(Vector3.up * lookx);

        float moveX = movement.x;
        float moveZ = movement.y;

        Vector3 actual_movement = (transform.forward * moveZ) + (transform.right * moveX);

        //Jumping Code
        if (hasJumped)
        {
            hasJumped = false;
            ySpeed = jumpHeight;
        }


        ySpeed -= gravityVal * Time.deltaTime;
        actual_movement.y = ySpeed;
        //Jumping Code End

        controller.Move(actual_movement * Time.deltaTime * speed);
    }
    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();
    }

    void OnLook(InputValue lookVal)
    {
        mouseMovement = lookVal.Get<Vector2>();
    }

    void OnAttack()
    {
        Instantiate(bullet, bulletSpawner.transform.position, bulletSpawner.transform.rotation);
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
