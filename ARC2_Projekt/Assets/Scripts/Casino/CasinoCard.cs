using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CasinoCard : MonoBehaviour
{
    public Text TopValue;

    public Text BottomValue;

    public Text Symbol;

    public string cardValue;

    public char cardSymbol;

    public void AssignInfo()
    {
        TopValue.text = cardValue;
        BottomValue.text = cardValue;
        Symbol.text = cardSymbol.ToString();
    }
}
