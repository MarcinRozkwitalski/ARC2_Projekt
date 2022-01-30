using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class CreatePlayer : MonoBehaviour
{
    public InputField usernameInput;
    public InputField emailInput;
    public InputField passwordInput;

    public Button RegisterButton;
    public Text RegisterButtonText;

    public void RegisterNewPlayer()
    {
        RegisterButton.interactable = false;
        if (usernameInput.text.Length < 5)
        {
            ErrorMessage("Username is to short!");
        }
        else if (emailInput.text.Length < 5)
        {
            ErrorMessage("Email is to short!");
        }
        else if (passwordInput.text.Length < 5)
        {
            ErrorMessage("Password is to short!");
        }
        else
        {
            SetButtonToSending();
            StartCoroutine(CreatePlayerPostRequest());
        }
    }

    public void ErrorMessage(string message)
    {
        RegisterButton.GetComponent<Image>().color = Color.red;
        RegisterButtonText.text = message;
        RegisterButtonText.fontSize = 50;
    }

    public void ResetRegisterButton()
    {
        RegisterButton.interactable = true;
        RegisterButton.GetComponent<Image>().color = Color.white;
        RegisterButtonText.text = "Register";
        RegisterButtonText.fontSize = 70;
    }

    public void SetButtonToSending()
    {
        RegisterButton.GetComponent<Image>().color = Color.blue;
        RegisterButtonText.text = "Sending...";
        RegisterButtonText.fontSize = 70;
    }

    public void SetButtonToSuccess()
    {
        RegisterButton.GetComponent<Image>().color = Color.green;
        RegisterButtonText.text = "Success";
        RegisterButtonText.fontSize = 70;
    }

    IEnumerator CreatePlayerPostRequest()
    {

        WWWForm newPlayerInfo = new WWWForm();
        newPlayerInfo.AddField("apppassword","thisisfromtheapp!");
        newPlayerInfo.AddField("username", usernameInput.text);
        newPlayerInfo.AddField("email", emailInput.text);
        newPlayerInfo.AddField("password", passwordInput.text);
        UnityWebRequest CreatePostRequest = UnityWebRequest.Post("http://localhost/arcCruds/newplayer.php", newPlayerInfo);
        yield return CreatePostRequest.SendWebRequest();
        if (CreatePostRequest.error == null)
        {
            Debug.Log(CreatePostRequest.downloadHandler.text);
            string response = CreatePostRequest.downloadHandler.text;
            if (response == "1" || response == "2" || response == "4" || response == "6")
            {
                ErrorMessage("Server Error");
            }
            else if (response == "3")
            {
                ErrorMessage("Username Already Exists");
            }
            else if (response == "5")
            {
                ErrorMessage("Eamil Already Exists");
            }
            else
            {
                SetButtonToSuccess();
            }
        }
        else
        {
            Debug.Log(CreatePostRequest.error);
        }
    }
}
