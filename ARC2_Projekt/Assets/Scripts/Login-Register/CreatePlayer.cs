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
        newPlayerInfo.AddField("username", usernameInput.text);
        newPlayerInfo.AddField("email", usernameInput.text);
        newPlayerInfo.AddField("password", usernameInput.text);
        UnityWebRequest CreatePostRequest = UnityWebRequest.Post("http://localhost/cruds/newplayer", newPlayerInfo);
        yield return CreatePostRequest.SendWebRequest();
        if (CreatePostRequest.error == null)
        {
            Debug.Log("Register successfull!");
            SetButtonToSuccess();
        }
        else
        {
            Debug.Log(CreatePostRequest.error);
        }
    }
}
