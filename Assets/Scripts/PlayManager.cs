using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayManager : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] GameObject finishedCanvas;
    [SerializeField] CustomEvent gameOverEvent;
    [SerializeField] CustomEvent playerWinEvent;
    [SerializeField] TMP_Text finishedText;
    [SerializeField] TMP_Text timeText;
    [SerializeField] TMP_Text countdownText;
    [SerializeField] float timeRemaining;
    [SerializeField] float countdownRemaining;

    // int coin;
    bool isWin;

     private void Update() 
    {
        if(countdownRemaining >= 0)
        {
            countdownRemaining -= Time.deltaTime;
            countdownText.text = countdownRemaining.ToString("0");
        }
        else
        {
             countdownText.text = "";

            if(timeRemaining > 0 && isWin != true)
            {
                timeRemaining -= Time.deltaTime;
                timeText.text = timeRemaining.ToString("0");
            }
            else if(isWin == true)
            {
                timeRemaining = timeRemaining;
            }
            else
            {
                GameOver();
            }
        }

    }

    private void OnEnable() 
    {
        gameOverEvent.OnInvoked.AddListener(GameOver);
        playerWinEvent.OnInvoked.AddListener(PlayerWin);
    }

    private void OnDisable() 
    {
        gameOverEvent.OnInvoked.RemoveListener(GameOver);
        playerWinEvent.OnInvoked.RemoveListener(PlayerWin);       
    }

    public void GameOver()
    {
        ball.GetComponent<Rigidbody>().isKinematic = true;
        finishedText.text = "You Failed!";
        finishedCanvas.SetActive(true);
    }

    public void PlayerWin()
    {
        isWin = true;
        finishedText.text = "You Win!\nRemaining Time : " + timeText.text + " s";
        finishedCanvas.SetActive(true);
    }

    // private int GetCoin()
    // {
    //     return coin * 10;
    // }
}
