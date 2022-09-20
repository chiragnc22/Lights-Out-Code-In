using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MazeDirectives : MonoBehaviour {

    public int keysToFind;

    public Text keysValueText;

    public MazeGoal mazeGoalPrefab;
    public MazeKey mazeKeyPrefab;

    MazeGoal mazeGoal;

    int foundKeys;

    List<Vector3> mazeKeyPositions;

    void Awake() {
        MazeGenerator.OnMazeReady += StartDirectives;
    }

    void Start() {
        SetKeyValueText();
    }

    void StartDirectives() {
        mazeGoal = Instantiate(mazeGoalPrefab, MazeGenerator.instance.mazeGoalPosition, Quaternion.identity) as MazeGoal;
        mazeGoal.transform.SetParent(transform);

        mazeKeyPositions = MazeGenerator.instance.GetRandomFloorPositions(keysToFind);

        for(int i = 0; i < mazeKeyPositions.Count; i++) {
            MazeKey mazeKey = Instantiate(mazeKeyPrefab, mazeKeyPositions[i], Quaternion.identity) as MazeKey;
            mazeKey.transform.SetParent(transform);
        }
    }

    public void OnGoalReached() {
        Debug.Log("Goal Reached");
        if(foundKeys == keysToFind) {
            Debug.Log("Escape the maze");
            SendEndLeaderboard(Time.realtimeSinceStartup.ToString("0"));
            SaveFinishTime();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void OnKeyFound() {
        foundKeys++;

        SetKeyValueText();

        if(foundKeys == keysToFind) {
            GetComponentInChildren<MazeGoal>().OpenGoal();
        }
    }

    void SetKeyValueText() {
        keysValueText.text = foundKeys.ToString() + " of " + keysToFind.ToString();
    }

    void OnError2(PlayFabError error) {
        Debug.Log("PlayFab Error");
    }

    public void SaveFinishTime(){
        var request = new UpdateUserDataRequest {
            Data = new Dictionary<string, string> {
                { "Launch To Escape", Time.realtimeSinceStartup.ToString("0")}
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnTimeSend, OnError2);
    }

    void OnTimeSend(UpdateUserDataResult result) {
        Debug.Log("Escape Time Sent"+ System.DateTime.Now);
    }

    public void SendEndLeaderboard(string score)
    {
        var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate {
                    StatisticName = "Total Session Time",
                    Value = int.Parse(score)
                }
                    
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request,OnEndLeaderboardUpdate, OnError2);
    }

    void OnEndLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Leaderboard data sent!");
    }

}
