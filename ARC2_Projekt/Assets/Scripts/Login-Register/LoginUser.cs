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

    private void Awake() {
        var players = FindObjectsOfType<CurrentPlayer>();
        if(players.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Login(){
        loginButton.interactable = false;
        loginButtonText.text = "Sending...";
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
            string result = loginRequest.downloadHandler.text;
            if (result == "1" || result == "2" || result == "5"){
                ErrorOnLoginMessage("Server Error");
            } else if (result == "3"){
                ErrorOnLoginMessage("Check Username");
            } else if (result == "4"){
                ErrorOnLoginMessage("Check Password");
            } else {
                var currentPlayer = Instantiate(currentPlayerObject, new Vector3(0, 0, 0), Quaternion.identity);
                currentPlayer.GetComponent<CurrentPlayer>().Username = result.Split(':')[0];
                // currentPlayer.GetComponent<CurrentPlayer>().Score = int.Parse(result.Split(':')[1]);
                currentPlayer.GetComponent<CurrentPlayer>().Money = int.Parse(result.Split(':')[1]);
                currentPlayer.GetComponent<CurrentPlayer>().Life = int.Parse(result.Split(':')[2]);
                currentPlayer.GetComponent<CurrentPlayer>().Level = int.Parse(result.Split(':')[3]);
                loginButton.GetComponent<Image>().color = Color.green;
                loginButtonText.text= "Logged in!";
                FindObjectOfType<SceneSwitcher>().LoadPlayerWelcomeScene();
            }
        } else {
            Debug.Log(loginRequest.error);
        }
    }
}
