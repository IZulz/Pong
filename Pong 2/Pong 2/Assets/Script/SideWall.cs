using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    public PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Ball")
        {
            player.IncreamentScore();

            if (player.Score < gameManager.maxScore)
            {
                collision.gameObject.SendMessage("RestartGame", 2.0f, SendMessageOptions.RequireReceiver);
            }
        }
    }
}
