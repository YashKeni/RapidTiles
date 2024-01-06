using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject mainGameCanvas;
    [SerializeField] GameObject finalScoreCanvas;
    [SerializeField] GameObject leaderboardPanel;

    private void Start()
    {
        finalScoreCanvas.SetActive(false);
        leaderboardPanel.SetActive(false);
    }

    public void ShowMainGameCanvas()
    {
        mainGameCanvas.SetActive(true);                  //--------------- 1
        finalScoreCanvas.SetActive(false);               //--------------- 0
    }


    public void ShowFinalScoreCanvas()
    {
        mainGameCanvas.SetActive(false);                 //--------------- 0 
        finalScoreCanvas.SetActive(true);                //--------------- 1
    }

    public void ShowLeaderboard()
    {
        leaderboardPanel.SetActive(true);
    }

    public void CloseLeaderboard()
    {
        leaderboardPanel.SetActive(false);
    }
}
