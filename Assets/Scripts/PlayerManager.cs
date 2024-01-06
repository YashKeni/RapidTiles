using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public Leaderboard leaderboard;
    public TMP_InputField playerNameInputField;
    public GameObject nameInputPanel;

    public bool nameEntered;

    void Start()
    {
        StartCoroutine(SetupRoutine());
    }

    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInputField.text, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Successfully Set Player Name");
                nameInputPanel.SetActive(false);
                nameEntered = true;
            }
            else
            {
                Debug.Log("Could not set Player Name: " + response.errorData.message);
            }
        });
    }

    IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        yield return leaderboard.FetchTopHighScoreRoutine();
    }

    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Player Logged in");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Could not start session");
                done = true;
            }
        }
        );
        yield return new WaitWhile(() => done == false);
    }

    void Update()
    {

    }
}
