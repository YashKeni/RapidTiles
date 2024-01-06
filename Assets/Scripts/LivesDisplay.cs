using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesDisplay : MonoBehaviour
{
    TextMeshProUGUI livesText;
    GameSession gameSession;

    void Start()
    {
        livesText = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        livesText.text = gameSession.GetLives().ToString() + " :Lives";
    }
}
