using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class TileColor : MonoBehaviour
{
    [SerializeField] public float randomToDefault = 5f;
    [SerializeField] float defaultToRandom = 3f;
    public bool isDefault;
    public List<Color> TintColors;
    int currentScore;

    GameSession gameSession;
    PlayerManager playerManager;

    void Start()
    {
        gameSession = FindObjectOfType<GameSession>();
        playerManager = FindObjectOfType<PlayerManager>();

        StartCoroutine(SwitchDefaultAndRandom());
    }

    private void Update()
    {
        DifficultyStatus();
    }

    IEnumerator SwitchDefaultAndRandom()
    {
        while (gameSession.GetLives() > 0)
        {
            DefaultColor();
            yield return new WaitForSeconds(defaultToRandom);
            RandomColor();
            yield return new WaitForSeconds(randomToDefault);
        }
    }

    private void RandomColor()
    {
        isDefault = false;
        Color color = TintColors[Random.Range(0, TintColors.Count)];
        GetComponent<Renderer>().material.color = color;

        Color32 objColor = gameObject.GetComponent<Renderer>().material.color;

        if (objColor.r == 255 && objColor.g == 0 && objColor.b == 0 && objColor.a == 255)
        {
            SetTriggerActive();
            gameObject.tag = "Red";
        }
        if (objColor.r == 255 && objColor.g == 128 && objColor.b == 0 && objColor.a == 255)
        {
            SetTriggerActive();
            gameObject.tag = "Orange";
        }
        if (objColor.r == 255 && objColor.g == 255 && objColor.b == 0 && objColor.a == 255)
        {
            SetTriggerActive();
            gameObject.tag = "Yellow";
        }
        if (objColor.r == 0 && objColor.g == 255 && objColor.b == 0 && objColor.a == 255)
        {
            SetTriggerActive();
            gameObject.tag = "Green";
        }
        if (objColor.r == 0 && objColor.g == 160 && objColor.b == 255 && objColor.a == 255)
        {
            SetTriggerActive();
            gameObject.tag = "LightBlue";
        }
        if (objColor.r == 0 && objColor.g == 0 && objColor.b == 255 && objColor.a == 255)
        {
            SetTriggerActive();
            gameObject.tag = "DarkBlue";
        }
        if (objColor.r == 103 && objColor.g == 0 && objColor.b == 255 && objColor.a == 255)
        {
            SetTriggerActive();
            gameObject.tag = "Purple";
        }
        if (objColor.r == 199 && objColor.g == 0 && objColor.b == 255 && objColor.a == 255)
        {
            SetTriggerActive();
            gameObject.tag = "Magenta";
        }
        if (objColor.r == 245 && objColor.g == 156 && objColor.b == 234 && objColor.a == 255)
        {
            SetTriggerActive();
            gameObject.tag = "Pink";
        }
    }

    public void DefaultColor()
    {
        isDefault = true;
        GetComponent<Renderer>().material.color = new Color(1, 1, 1, 1);
        gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        gameObject.tag = "White";
    }

    public void DifficultyStatus()
    {
        currentScore = gameSession.GetScore();
        switch (currentScore)
        {
            case int n when (n >= 100 && n < 200):
                Debug.Log("Speed Increased 1");
                randomToDefault = 4f;
                break;

            case int n when (n >= 200 && n < 300):
                Debug.Log("Speed Increased 2");
                randomToDefault = 3f;
                break;

            case int n when (n >= 300 && n < 400):
                Debug.Log("Speed Increased 3");
                randomToDefault = 2f;
                break;
        }
    }

    void SetTriggerActive()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

}
