using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingBehaviour : MonoBehaviour
{
    public void CheckDoor(GameObject door)
    {
        FindObjectOfType<DoorMovement>().MoveDoor(door);
    }
}
