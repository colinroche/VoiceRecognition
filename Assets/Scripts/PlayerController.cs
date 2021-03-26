using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController myController;

    private float movementSpeed = 3.5f;
    private float rotationSpeed = 1.5f;

    Quaternion startAngle = Quaternion.Euler (0,0,0);
    Quaternion rightAngle = Quaternion.Euler (0,90,0);
    Quaternion backAngle = Quaternion.Euler (0,180,0);
    Quaternion leftAngle = Quaternion.Euler (0,270,0);
    
    public Quaternion currentAngle;
    //movement Vector
    private Vector3 moving;

    [SerializeField] GameObject door_2;
    [SerializeField] GameObject door_3;
    [SerializeField] GameObject door_4;
    [SerializeField] GameObject door_5;
    [SerializeField] GameObject door_6;
    [SerializeField] GameObject door_7;
    [SerializeField] GameObject door_8;

    private void Start()
    {
        currentAngle = startAngle;
        myController = GetComponent<CharacterController>();
        moving = Vector3.zero;
    }

    private void Update()
    {
        Movement();
        PlayerRotation();
    }

    private void Movement()
    {
        moving = new Vector3(0, 0, Input.GetAxis("Vertical")*movementSpeed);
        moving = transform.rotation * moving;

        //move
        myController.Move(moving * Time.deltaTime);
    }

    private void PlayerRotation()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            ChangeAngleRight();
        }

        else if(Input.GetKeyDown(KeyCode.A))
        {
            ChangeAngleLeft();
        }
        this.transform.rotation = Quaternion.Slerp (this.transform.rotation,currentAngle,0.05f);
        //transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal")*rotationSpeed, 0));
    }

    void ChangeAngleLeft()
    {
        if(currentAngle.eulerAngles.y == startAngle.eulerAngles.y)
        {
            currentAngle = leftAngle;
        }
        else if(currentAngle.eulerAngles.y == leftAngle.eulerAngles.y)
        {
            currentAngle = backAngle;
        }
        else if(currentAngle.eulerAngles.y == backAngle.eulerAngles.y)
        {
            currentAngle = rightAngle;
        }
        else if(currentAngle.eulerAngles.y == rightAngle.eulerAngles.y)
        {
            currentAngle = startAngle;
        }
    }
    void ChangeAngleRight()
    {
        if(currentAngle.eulerAngles.y == startAngle.eulerAngles.y)
        {
            currentAngle = rightAngle;
        }
        else if(currentAngle.eulerAngles.y == rightAngle.eulerAngles.y)
        {
            currentAngle = backAngle;
        }
        else if(currentAngle.eulerAngles.y == backAngle.eulerAngles.y)
        {
            currentAngle = leftAngle;
        }
        else if(currentAngle.eulerAngles.y == leftAngle.eulerAngles.y)
        {
            currentAngle = startAngle;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Painting1")
        {
            FindObjectOfType<GameSession>().OpenDoor("MOUNTAINS");
            FindObjectOfType<PaintingBehaviour>().CheckDoor(door_2);
        }
        if (other.tag == "Painting2")
        {
            FindObjectOfType<GameSession>().OpenDoor("HOUSE");
            FindObjectOfType<PaintingBehaviour>().CheckDoor(door_3);
        }
        if (other.tag == "Painting3")
        {
            FindObjectOfType<GameSession>().OpenDoor("FLOWERS");
            FindObjectOfType<PaintingBehaviour>().CheckDoor(door_4);
        }
        if (other.tag == "Painting4")
        {
            FindObjectOfType<GameSession>().OpenDoor("SUNRISE");
            FindObjectOfType<PaintingBehaviour>().CheckDoor(door_5);
        }
        if (other.tag == "Painting5")
        {
            FindObjectOfType<GameSession>().OpenDoor("TREES");
            FindObjectOfType<PaintingBehaviour>().CheckDoor(door_6);
        }
        if (other.tag == "Painting6")
        {
            FindObjectOfType<GameSession>().OpenDoor("CLIFFS");
            FindObjectOfType<PaintingBehaviour>().CheckDoor(door_7);
        }
        if (other.tag == "Painting7")
        {
            FindObjectOfType<GameSession>().OpenDoor("CLIFFS");
            FindObjectOfType<PaintingBehaviour>().CheckDoor(door_7);
        }
        if (other.tag == "PaintingTutorial")
        {
            FindObjectOfType<GameSession>().OpenDoor("BAY");
            FindObjectOfType<PaintingBehaviour>().CheckDoor(door_8);
        }

        if (other.tag == "EndTutorial")
        {
            FindObjectOfType<GameSession>().ResetGameSession();
        }

        if (other.tag == "End")
        {
            FindObjectOfType<GameSession>().EndGame();
        }
    }
}
