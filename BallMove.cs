using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    private float speed = 8f;
    public Rigidbody2D rb;
    [SerializeField] private GameManager gameManager;

    void Start()
    {
        Launch();
    }

    public void Launch()
    {
        float x = RandomL();
        float y = RandomL();

        Vector2 direction = new Vector2(x, y).normalized;
        rb.velocity = direction * speed;
    }

    private void Update()
    {
        if (gameManager.readyToPlay == false)
        {
            transform.position = new Vector2(0, 0);
            rb.velocity = Vector2.zero;
        }
    }

    public int RandomL()
    {
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LeftScore")
        {
            gameManager.computerPoints = gameManager.computerPoints + 1;
        }
        if (collision.tag == "RightScore")
        {
            gameManager.playerPoints = gameManager.playerPoints + 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!(gameManager.playerPoints == 5 || gameManager.computerPoints == 5))
        {
            if (collision.tag == "LeftScore" || collision.tag == "RightScore")
            {
                transform.position = new Vector2(0, 0);
                Launch();
            }
        }
    }
}
