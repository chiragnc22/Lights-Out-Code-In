using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void start_Game()
    {
        // SaveGameStartTime();
        SendLeaderboard(Time.realtimeSinceStartup.ToString("0"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Enjoy");
    }    

    void OnError0(PlayFabError error) {
        Debug.Log("PlayFab Error");
    }

    // public void SaveGameStartTime(){
    //     var request = new UpdateUserDataRequest {
    //         Data = new Dictionary<string, string> {
    //             { "Launch To Start", Time.realtimeSinceStartup.ToString("0")}
    //         }
    //     };
    //     PlayFabClientAPI.UpdateUserData(request, OnStartTimeSend, OnError0);
    // }

    // void OnStartTimeSend(UpdateUserDataResult result) {
    //     Debug.Log("Start Time Sent"+ System.DateTime.Now);
    // }

    public void SendLeaderboard(string score)
    {
        var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate {
                    StatisticName = "Launch To Start",
                    Value = int.Parse(score)
                }
                    
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request,OnLeaderboardUpdate, OnError0);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Leaderboard data sent!");
    }
}
