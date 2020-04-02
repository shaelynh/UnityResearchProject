using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //variable to follow the player
    public Transform target;

    public float minHeight, maxHeight;

    //last position on x post
    //  private float lastXPos;
    private Vector2 lastPos;

    // Start is called before the first frame update
    void Start()
    {
        //where the camera starts
        // lastXPos = transform.position.x;
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //move position of camera // y position is horizontal
        //Vector 2 is x & y Vector3 ...

        /*
         *previous way
         * 
         * transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

          float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
          transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
          */

        //do not want to change z
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

        //  float amountToMoveX = transform.position.x - lastXPos;
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y - lastPos.y);

        // lastXPos = transform.position.x;
        lastPos = transform.position;
    }
}

