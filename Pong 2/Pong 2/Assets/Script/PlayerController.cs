using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public KeyCode upBtn = KeyCode.W;
    public KeyCode downBtn = KeyCode.S;

    public float speed = 10f;
    public float yBoundary = 9f;

    Rigidbody2D rigid;
    int score;

    ContactPoint2D lastContactPoint;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = rigid.velocity;

        if (Input.GetKey(upBtn))
        {
            velocity.y = speed;
        }
        else if (Input.GetKey(downBtn))
        {
            velocity.y = -speed;
        }
        else
        {
            velocity.y = 0f;
        }

        rigid.velocity = velocity;

        Vector3 position = transform.position;

        if(position.y > yBoundary)
        {
            position.y = yBoundary;
        }
        else if (position.y < -yBoundary)
        {
            position.y = -yBoundary;
        }

        transform.position = position;
    }

    public ContactPoint2D LastContactPoint
    {
        get { return lastContactPoint; }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Ball"))
        {
            lastContactPoint = collision.GetContact(0);
        }
    }

    public void IncreamentScore()
    {
        score++;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public int Score
    {
        get { return score; }
    }
}
