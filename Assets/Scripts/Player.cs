using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject showBlock;
    int score = 0;
    int lives = 3;
    [SerializeField] int gameOverDelay = 2;
    [SerializeField] int scoreIncrement = 100;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;

    [Header("SFX")]
    [SerializeField] AudioClip scoreSFX;
    [SerializeField] AudioClip lifeSFX;

    TileColor tileColor;
    AudioSource audioSource;

    bool isSame;

    void Awake()
    {
        tileColor = showBlock.GetComponent<TileColor>();
        audioSource = GetComponent<AudioSource>();

        scoreText.text = "Score: 0";
        livesText.text = "3 :Lives";
    }


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
        if (isSame == true && tileColor.isDefault == true)
        {
            scoreText.text = "Score: " + Scorer().ToString();
        }
        if (isSame == false && tileColor.isDefault == true)
        {
            livesText.text = Health().ToString() + " :Lives";
        }
    }

    public int Scorer()
    {
        score += scoreIncrement;
        audioSource.PlayOneShot(scoreSFX);
        return score;
    }

    public int Health()
    {
        lives--;
        audioSource.PlayOneShot(lifeSFX);
        if (lives <= 0)
        {
            StartCoroutine(GameOverDelay());
        }
        return lives;
    }

    IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(gameOverDelay);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }



}
