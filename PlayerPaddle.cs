using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPaddle : MonoBehaviour
{
    private float speed = 8f;
    private float boundY = 4.2f;
    [SerializeField] private GameManager gameManager;

    void Update()
    {
        if (Input.GetKey(KeyCode.W) && gameManager.readyToPlay == true)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) && gameManager.readyToPlay == true)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        Vector2 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -boundY, boundY);
        transform.position = pos;
    }
}
