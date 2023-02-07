using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 6.0f;
    public float runSpeed = 8.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    public float mouseSensibility = 3.0f; 
    
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private Transform mainCamera;
    private bool gameStarted = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        mainCamera = Camera.main.transform;
    }
    
    void Update()
    {
        bool flagValue = SingletonGameStartFlag.Instance.flag;
        if (!gameStarted && flagValue)
        {
            Cursor.visible = false;
            gameStarted = true;

        }

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            
            float speed = walkSpeed;
            if (Input.GetKey(KeyCode.LeftShift))
                speed = runSpeed;
            
            moveDirection *= speed;
            
            if (Input.GetKeyDown(KeyCode.Space))
                moveDirection.y = jumpSpeed;
        }
        
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
        
        // Aiming with the mouse
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(new Vector3(0, mouseX * mouseSensibility, 0));
        mainCamera.Rotate(new Vector3(-mouseY * mouseSensibility, 0, 0));
    }
}
