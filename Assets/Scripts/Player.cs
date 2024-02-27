using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject showBlock;
    [SerializeField] int gameOverDelay = 2;
    [SerializeField] int scoreIncrement = 100;

    [Header("SFX")]
    [SerializeField] AudioClip scoreSFX;
    [SerializeField] AudioClip lifeSFX;

    TileColor tileColorSB;
    TileColor[] tiles;
    AudioSource audioSource;
    GameSession gameSession;
    Leaderboard leaderboard;
    CanvasManager canvasManager;
    PlayerManager playerManager;

    public bool isSame;

    void Awake()
    {
        tileColorSB = showBlock.GetComponent<TileColor>();
        tiles = FindObjectsOfType<TileColor>();
        audioSource = GetComponent<AudioSource>();
        gameSession = FindObjectOfType<GameSession>();
        leaderboard = FindObjectOfType<Leaderboard>();
        canvasManager = FindObjectOfType<CanvasManager>();
        playerManager = FindObjectOfType<PlayerManager>();
    }

    private void Start()
    {
        // StartGameRoutine();
    }

    private void Update()
    {
        if (gameSession.GetLives() <= 0)
        {
            StartCoroutine(GameOverDelay());
        }
    }

    // public void StartGameRoutine()
    // {
    //     for (int i = 0; i < tiles.Length; i++)
    //     {
    //         StartCoroutine(tiles[i].SwitchDefaultAndRandom());
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.tag = other.gameObject.tag;
        if (gameObject.tag == showBlock.gameObject.tag)
        {
            isSame = true;
        }
        else
        {
            isSame = false;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (isSame == true && tileColorSB.isDefault == true)
        {
            gameSession.AddToScore(scoreIncrement);
            audioSource.PlayOneShot(scoreSFX);
        }
        if (isSame == false && tileColorSB.isDefault == true)
        {
            gameSession.DecreaseLives(1);
            audioSource.PlayOneShot(lifeSFX);
        }
    }

    IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(gameOverDelay);
        int finalScore = gameSession.GetScore();
        yield return leaderboard.SubmitScoreRoutine(finalScore);
        yield return leaderboard.FetchTopHighScoreRoutine();
        canvasManager.ShowFinalScoreCanvas();
    }
}
