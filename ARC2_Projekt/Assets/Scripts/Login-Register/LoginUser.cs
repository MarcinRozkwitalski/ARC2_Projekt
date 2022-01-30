using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LoginUser : MonoBehaviour
{
    public InputField usernameInput;
    public InputField passwordInput;
    public Button loginButton;
    public Text loginButtonText;

    public GameObject currentPlayerObject;

    public void Login(){
        loginButton.interactable = false;
        if(usernameInput.text.Length < 3){
            ErrorOnLoginMessage("Check Username");
        }
        else if (passwordInput.text.Length < 3){
            ErrorOnLoginMessage("Check Password");
        } 
        else {
            StartCoroutine(SendLoginForm());
        }
    }

    public void ErrorOnLoginMessage(string message){
        loginButton.GetComponent<Image>().color = Color.red;
        loginButtonText.text = message;
        loginButtonText.fontSize = 60;
    }

    public void ResetLoginButton(){
        loginButton.GetComponent<Image>().color = Color.white;
        loginButtonText.text = "Login";
        loginButtonText.fontSize = 70;
        loginButton.interactable = true;
    }

    IEnumerator SendLoginForm(){
        WWWForm LoginInfo = new WWWForm();
        LoginInfo.AddField("apppassword", "thisisfromtheapp!");
        LoginInfo.AddField("username", usernameInput.text);
        LoginInfo.AddField("password", passwordInput.text);
        UnityWebRequest loginRequest = UnityWebRequest.Post("http://localhost/arcCruds/loginuser.php", LoginInfo);
        yield return loginRequest.SendWebRequest();
        if(loginRequest.error == null){
            Debug.Log("Form sent");
            Debug.Log(loginRequest.downloadHandler.text);
            var currentPlayer = Instantiate(currentPlayerObject, new Vector3(0, 0, 0), Quaternion.identity);
        } else{
            Debug.Log(loginRequest.error);
        }
    }
}
