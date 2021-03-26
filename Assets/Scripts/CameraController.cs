using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;

    private Vector3 offset;
    private float speed = 1.5f;

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null)
        {
            // Follows the player as they move
            transform.position = player.transform.position + offset;
        }
    }
}
