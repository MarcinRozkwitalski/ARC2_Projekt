using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabInputFieldLogin : MonoBehaviour
{
    public InputField usernameInput; // 0
    public InputField passwordInput; // 1

    public int InputSelected;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
        {
            InputSelected--;
            if (InputSelected < 0) InputSelected = 1;
            SelectInputField();
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            InputSelected++;
            if (InputSelected > 1) InputSelected = 0;
            SelectInputField();
        }

        void SelectInputField()
        {
            switch (InputSelected)
            {
                case 0: usernameInput.Select();
                    break;
                case 1: passwordInput.Select();
                    break;
            }
        }
    }

    public void UsernameSelected() => InputSelected = 0;
    public void PasswordSelected() => InputSelected = 1;
}