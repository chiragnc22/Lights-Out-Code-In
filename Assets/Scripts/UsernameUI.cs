using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UsernameUI : MonoBehaviour
{
    public InputField usernameInput;
    public Text errorMessage;
    // public string UserID = "";

    public void submitButton()
    {
        if(usernameInput.text == null){
            errorMessage.text = "Please enter a username";
            return;
        }
        if(usernameInput.text.Length < 4){
            errorMessage.text = "Username must be at least 4 characters";
            return;
        }
        var request = new UpdateUserTitleDisplayNameRequest {
            DisplayName = usernameInput.text,
        };
        // UserID = usernameInput.text;
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError1);

    }

    public void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void OnError1(PlayFabError error) {
        Debug.Log("PlayFab Error");
        errorMessage.text = "User with same username already exists!";
    }

}

