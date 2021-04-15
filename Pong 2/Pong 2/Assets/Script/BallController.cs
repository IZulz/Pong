using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rigid;

    public float xInitialForce;
    public float yInitialForce;

    Vector2 trajectoryOrigin;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        trajectoryOrigin = transform.position;

        RestartGame();
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;    
    }

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }

    public void ResetBall()
    {
        transform.position = Vector2.zero;
        rigid.velocity = Vector2.zero;
    }

    void PushBall()
    {
        //float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);

        float yRandomInitialForce;
        float yInitialForceFix = Random.Range(0, 2);

        if (yInitialForceFix < 1)
        {
            yRandomInitialForce = -yInitialForce;
        }
        else
        {
            yRandomInitialForce = yInitialForce;
        }

        float randomDirection = Random.Range(0, 2);

        if (randomDirection < 1.0f)
        {
            rigid.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        else
        {
            rigid.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }

    }

    void RestartGame()
    {
        ResetBall();

        Invoke("PushBall", 2);
    }
}
