// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using PlayFab;
// using PlayFab.CLientModels;
// using Newtonsoft.Json;
// using UnityEngine.UI;
  

// public class PlayFabManager : MonoBehaviour
// {
//     [Header("UI")]
//     public Text messageText;
//     public InputField emailInput;
//     public InputField passwordInput;

//     public void RegisterButton(){
//         if (passInput.text.Length < 6) {
//             messageText.text = "Password Too Short!";
//             return;
//         }
//         var request = new RegisterPlayFabUserRequest {
//             Email = emailInput.text,
//             Password = passwordInput.text,
//             RequiredBothUsernameAndEmail = false
//         };
//         PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
//     }
//     void OnRegisterSuccess(RegisterPlayFabUserResult result) {
//         messageText.text = "Registered and Logged In!";
//     }

//     public void LogInButton() {
//         var request = new LoginWithEmailAddressRequest {
//             Email = emailInput.text,
//             Password = passwordInput.text
//         };
//         PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
//     }
//     void OnLoginSuccess(LoginResult result) {
//         messageText.text = "Logged In Successfully!";
//     }
    
// }
