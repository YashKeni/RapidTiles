using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class Leaderboard : MonoBehaviour
{
    string leadeboardKey = "rapidTilesHS";
    [SerializeField] TextMeshProUGUI playerNames;
    [SerializeField] TextMeshProUGUI playerScores;

    void Start()
    {

    }

    public IEnumerator SubmitScoreRoutine(int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leadeboardKey, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Score uploaded successfully");
                done = true;
            }
            else
            {
                Debug.Log("Failed: " + response.errorData.message);
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }

    public IEnumerator FetchTopHighScoreRoutine()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreList(leadeboardKey, 10, 0, (response) =>
        {
            if (response.success)
            {
                string tempPlayerNames = "Names\n";
                string tempPlayerScores = "Scores\n";

                LootLockerLeaderboardMember[] members = response.items;

                for (int i = 0; i < members.Length; i++)
                {
                    tempPlayerNames += members[i].rank + ". ";
                    if (members[i].player.name != "")
                    {
                        tempPlayerNames += members[i].player.name;
                    }
                    else
                    {
                        tempPlayerNames += members[i].player.id;
                    }
                    tempPlayerScores += members[i].score + "\n";
                    tempPlayerNames += "\n";
                }
                done = true;
                playerNames.text = tempPlayerNames;
                playerScores.text = tempPlayerScores;
            }
            else
            {
                Debug.Log("Failed: " + response.errorData.message);
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}
