using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

  

public class PlayFabManage : MonoBehaviour
{
    [Header("UI")]
    public Text messageText;
    public Text messageText2;
    public InputField emailInput;
    public InputField passwordInput;
    public float startDelay = 1.5f;


    public void RegisterButton(){
        if (passwordInput.text.Length < 6 && passwordInput.text.Length > 0) {
            messageText.text = "PASSWORD TOO SHORT!";
            messageText2.text = "PASSWORD SHOULD BE ATLEAST 6 CHARACTERS LONG!";
            return;
        }
        if (emailInput==null || passwordInput == null) {
            messageText.text = "INVALID USERNAME OR PASSWORD!";
            messageText2.text = "";
            return;
        }
        var request = new RegisterPlayFabUserRequest {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result) {
        messageText.text = "REGISTERED SUCCESSFULLY!";
        messageText2.text = "LOGIN AGAIN TO PROCEED FURTHER";
        emailInput.text = "";
        passwordInput.text = "";
    }

    public void LogInButton() {

        var request = new LoginWithEmailAddressRequest {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }
    void OnLoginSuccess(LoginResult result) {
        messageText.text = "LOGGED IN SUCCESSFULLY!";
        messageText2.text = "LOADING GAME...";
        Invoke("Begin", startDelay);
    }

    void OnError(PlayFabError error) {
        Debug.Log("PlayFab Error");
        messageText.text = "SOME ERROR OCCURED!";
        messageText2.text = "MAYBE IT'S YOUR NETWORK CONNECTIVITY ISSUE";
    }

    public void Begin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
