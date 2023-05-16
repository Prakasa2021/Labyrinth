using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayManager : MonoBehaviour
{
    [SerializeField] GameObject finishedCanvas;
    [SerializeField] TMP_Text finishedText;
    [SerializeField] CustomEvent gameOverEvent;
    [SerializeField] CustomEvent playerWinEvent;

    int coin;

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
        finishedText.text = "You Failed!";
        finishedCanvas.SetActive(true);
    }

    public void PlayerWin()
    {
        finishedText.text = "You Win!\nScore : " + GetCoin();
        finishedCanvas.SetActive(true);
    }

    private int GetCoin()
    {
        return coin * 10;
    }
}
