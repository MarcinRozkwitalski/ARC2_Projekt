using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabInputFieldRegister : MonoBehaviour
{
    public InputField usernameInput; // 0
    public InputField emailInput; // 1
    public InputField passwordInput; // 2

    public int InputSelected;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
        {
            InputSelected--;
            if (InputSelected < 0) InputSelected = 2;
            SelectInputField();
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            InputSelected++;
            if (InputSelected > 2) InputSelected = 0;
            SelectInputField();
        }

        void SelectInputField()
        {
            switch (InputSelected)
            {
                case 0: usernameInput.Select();
                    break;
                case 1: emailInput.Select();
                    break;
                case 2: passwordInput.Select();
                    break;
            }
        }
    }

    public void UsernameSelected() => InputSelected = 0;
    public void EmailSelected() => InputSelected = 1;
    public void PasswordSelected() => InputSelected = 2;
}