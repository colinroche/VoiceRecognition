using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    [SerializeField] GameObject door_1;
    
    private float speed = .4f;
    // Start is called before the first frame update
    void Start()
    {
       MoveDoor(door_1);
    }

    // Update is called once per frame
    void Update()
    {
        //door_2.transform.position += -transform.up * speed * Time.deltaTime;
    }

    public void MoveDoor(GameObject movement)
    {
        print("active");
        StartCoroutine(SetDoorMovement(movement));
    }

    IEnumerator SetDoorMovement(GameObject movement)
    {
        while(movement.transform.position.y >= -3)
        {
            movement.transform.position += -transform.up * speed * Time.deltaTime;
            yield return new WaitForSeconds(0f);
        }
    }
}
