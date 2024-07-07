using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private BallMove ball;
    [SerializeField] private GameObject playAgainScreen;
    [SerializeField] private TextMeshProUGUI winner_loser_text;
    [SerializeField] private GameObject playerPaddle;
    [HideInInspector] public int playerPoints;
    [HideInInspector] public int computerPoints;
    [HideInInspector] public bool readyToPlay = true;

    void Start()
    {
        playerPoints = 0;
        computerPoints = 0;
        playAgainScreen.SetActive(false);
    }

    void Update()
    {
        scoreText.text = "P " + playerPoints + " : " + computerPoints + " C";
        if (readyToPlay == true)
        {
            if (playerPoints == 5)
            {
                readyToPlay = false;
                playAgainScreen.SetActive(true);
                winner_loser_text.text = "You Won!";

            }
            if (computerPoints == 5)
            {
                readyToPlay = false;
                playAgainScreen.SetActive(true);
                winner_loser_text.text = "You lost!";
            }
        }
    }

    public void playAgainButtonPressed()
    {
        ball.Launch();
        readyToPlay = true;
        playerPoints = 0;
        computerPoints = 0;
        playAgainScreen.SetActive(false);
        playerPaddle.transform.position = new Vector2(playerPaddle.transform.position.x, 0f);
    }

    public void exitButtonPressed()
    {
        Application.Quit();
    }
}
