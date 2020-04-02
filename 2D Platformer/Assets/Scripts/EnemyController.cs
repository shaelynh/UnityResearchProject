using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Transform leftPoint, rightPoint;

    private bool movingRight;

    private Rigidbody2D theRB;

    public SpriteRenderer theSR;

    public float moveTime, waitTime;
    private float moveCount, waitCount;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        //get animation
        anim = GetComponent<Animator>();


        //get rid of parents on game start
        leftPoint.parent = null;
        rightPoint.parent = null;

        //give value
        moveCount = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveCount > 0) {

            moveCount -= Time.deltaTime;

            if (movingRight)
            {
                //how fast
                theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);

                //change direction
                theSR.flipX = true;

                if (transform.position.x > rightPoint.position.x)
                {
                    movingRight = false;
                }
            }
            else
            {
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);

                theSR.flipX = false;

                if (transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }
            }

            if (moveCount <= 0)
            {
                // waitCount = waitTime;

                //randomize - pick number between two waitTimes
                waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
            }

            anim.SetBool("isMoving", true);

        } else if(waitCount > 0) {

            waitCount -= Time.deltaTime;
            //dont move
            theRB.velocity = new Vector2(0f, theRB.velocity.y);

            if(waitCount <= 0)
            {
              //  moveCount = moveTime;
                  moveCount = Random.Range(moveTime * .75f, moveTime * .75f);
            }
            anim.SetBool("isMoving", false);
        }
    }
}
