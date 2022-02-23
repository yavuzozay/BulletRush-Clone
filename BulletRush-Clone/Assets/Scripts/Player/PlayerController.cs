using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    [SerializeField]private Joystick joystick;
    private Rigidbody playerRb;
    private Quaternion rot;
    [SerializeField][Range(10f,100f)] private float rotSpeed=10f;
    public bool isFireBtnPressed=false;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInputs();
        Debug.Log("v:"+verticalInput+"h"+horizontalInput);
    }
    private void FixedUpdate()
    {
        ApplyMovement();
        RotateSmoothly();
    }
    private void CheckInputs()
    {
        horizontalInput = joystick.Horizontal;
        verticalInput = joystick.Vertical;
        horizontalInput = NormalizeInput(horizontalInput);
        verticalInput = NormalizeInput(verticalInput);
      
    }
    private void ApplyMovement()
    {
        playerRb.velocity = new Vector3(horizontalInput, 0, verticalInput);
    }
    private void RotateSmoothly()
    {
        if (verticalInput == 1f&&horizontalInput==1f)//yukar� sa�a
        {
            rot = Quaternion.Euler(0, 45, 0);
        }
        else if (verticalInput == 1f && horizontalInput == -1f)//yukar� sola
        {
            rot = Quaternion.Euler(0, -45, 0);

        }
        else if (verticalInput == 1f && horizontalInput == 0)//yukar� d�z
        {
            rot = Quaternion.Euler(0, 0, 0);

        }
        else if (verticalInput == 0f && horizontalInput == 1f)// sa�a
        {
            rot = Quaternion.Euler(0, 90, 0);

        }
        else if (verticalInput == 0f && horizontalInput == 0)//d�z
        {
           //�nceki konumda kals�n

        }
        else if (verticalInput == 0f && horizontalInput == -1f)//sola
        {
            rot = Quaternion.Euler(0, -90, 0);


        }
        else if (verticalInput == -1f && horizontalInput == -1f)//a�a�� sola
        {
            rot = Quaternion.Euler(0, -135, 0);

        }

        else if (verticalInput == -1f && horizontalInput == 0f)//a�a�� 
        {
            rot = Quaternion.Euler(0, 180, 0);

        }
        else if (verticalInput == -1f && horizontalInput == 1f)//a�a�� sa�a
        {
            rot = Quaternion.Euler(0, 135, 0);

        }
        else// Buraya muhtemelen girmeyecek...
        {
            rot = Quaternion.Euler(0, 0, 0);

        }

        transform.rotation = Quaternion.Lerp(transform.rotation, rot, Time.fixedDeltaTime);
    }
    private float NormalizeInput(float input)
    {
        if (input < -0.25)
        {
            input = -1f;
        }
        else if (input > 0.25)
        {
            input = 1f;
        }
        else
        {
            input = 0;
        }
        return input;
    }
}
