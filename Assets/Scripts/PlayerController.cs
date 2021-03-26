using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController myController;

    private float movementSpeed = 0f;
    private float rotationSpeed = 1.5f;

    Quaternion startAngle = Quaternion.Euler (0,0,0);
    Quaternion rightAngle = Quaternion.Euler (0,90,0);
    Quaternion backAngle = Quaternion.Euler (0,180,0);
    Quaternion leftAngle = Quaternion.Euler (0,270,0);
    
    public Quaternion currentAngle;
    //movement Vector
    private Vector3 moving;

    [SerializeField] GameObject playerCanvas;
    [SerializeField] GameObject tutorialCanvas;

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

    public void Movement()
    {
        moving = new Vector3(0, 0, movementSpeed);
        moving = transform.rotation * moving;

        //move
        myController.Move(moving * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.W))
        {
            SetMovement();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            StopMovement();
        }
    }

    public void SetMovement()
    {
        movementSpeed = 2.5f;
    }

    public void StopMovement()
    {
        movementSpeed = 0f;
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
        this.transform.rotation = Quaternion.Slerp (this.transform.rotation,currentAngle,0.03f);
    }

    public void ChangeAngleLeft()
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
    public void ChangeAngleRight()
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
            playerCanvas.SetActive(true);
            FindObjectOfType<GameSession>().OpenDoor("MOUNTAINS");
        }
        if (other.tag == "Painting2")
        {
            playerCanvas.SetActive(true);
            FindObjectOfType<GameSession>().OpenDoor("HOUSE");
        }
        if (other.tag == "Painting3")
        {
            playerCanvas.SetActive(true);
            FindObjectOfType<GameSession>().OpenDoor("FLOWERS");
        }
        if (other.tag == "Painting4")
        {
            playerCanvas.SetActive(true);
            FindObjectOfType<GameSession>().OpenDoor("SUNRISE");
        }
        if (other.tag == "Painting5")
        {
            playerCanvas.SetActive(true);
            FindObjectOfType<GameSession>().OpenDoor("TREES");
        }
        if (other.tag == "Painting6")
        {
            playerCanvas.SetActive(true);
            FindObjectOfType<GameSession>().OpenDoor("CLIFFS");
        }
        if (other.tag == "PaintingTutorial")
        {
            playerCanvas.SetActive(true);
            tutorialCanvas.SetActive(false);
            FindObjectOfType<GameSession>().OpenDoor("BAY");
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
