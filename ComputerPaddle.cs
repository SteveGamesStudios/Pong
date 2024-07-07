using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : MonoBehaviour
{
    private float speed = 5f;
    private float boundY = 4.2f;
    [SerializeField] private GameObject ball;
    [SerializeField] private Rigidbody2D rb;

    private void FixedUpdate()
    {
        Vector2 targetPosition = new Vector2(transform.position.x, Mathf.Clamp(ball.transform.position.y, -boundY, boundY));
        Vector2 newPos = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        rb.MovePosition(newPos);
    }
}
