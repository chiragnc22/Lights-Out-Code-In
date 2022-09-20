using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PasswordCheck : MonoBehaviour
{
    private string[] password = {"ABDT","Shadow1615","GJPRSS","xmc"};//
    public InputField UserInput;
    public string USERINPUT;
    public GameObject WrongPass;
    public bool passIsRight;
    public int keysCollected = 0;

    public void checkPassword()
    {
        USERINPUT = UserInput.text;

        if (USERINPUT != null)
        {   
            foreach (string j in password)
            {
                if(USERINPUT == j)
                {
                    passIsRight = true;
                    Debug.Log("right");
                    int numIndex = Array.IndexOf(password, j);
                    password = password.Where((val, idx) => idx != numIndex).ToArray();
                    SendLeaderboardProbNum(Time.realtimeSinceStartup.ToString("0"));
                    FindObjectOfType<GameManager>().resumeLevel();
                    UserInput.text = "";
                    showStatus();
                    keysCollected++;
                    break;
                }
                else
                {
                    passIsRight = false;
                    showStatus();             
                }          
            }
        }      
    }

    public void showStatus()
    {
        if(passIsRight)
        {
            Debug.Log("right answers");
            WrongPass.SetActive(false);
        }else
        {
            Debug.Log("wrong answers");
            WrongPass.SetActive(true);
        }
    }

    public void SendLeaderboardProbNum(string score)
    {
        if(keysCollected == 0){
            var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate {
                    StatisticName = "Time to 1st Problem",
                    Value = int.Parse(score)
                }
                    
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request,OnLeaderboardProbNumUpdate, OnErrorProbNum);
        }
        if(keysCollected == 1){
            var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate {
                    StatisticName = "Time to 2nd Problem",
                    Value = int.Parse(score)
                }
                    
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request,OnLeaderboardProbNumUpdate, OnErrorProbNum);
        }
        if(keysCollected == 2){
            var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate {
                    StatisticName = "Time to 3rd Problem",
                    Value = int.Parse(score)
                }
                    
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request,OnLeaderboardProbNumUpdate, OnErrorProbNum);
        }
        if(keysCollected == 3){
            var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate {
                    StatisticName = "Time to 4th Problem",
                    Value = int.Parse(score)
                }
                    
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request,OnLeaderboardProbNumUpdate, OnErrorProbNum);
        }
        Debug.Log(Time.realtimeSinceStartup);
    } 


    void OnLeaderboardProbNumUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Leaderboard data sent!");
    }

    void OnErrorProbNum(PlayFabError error) {
        Debug.Log("PlayFab Error");
    }
}
