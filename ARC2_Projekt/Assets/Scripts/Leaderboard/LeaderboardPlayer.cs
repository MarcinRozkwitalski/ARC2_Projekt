using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardPlayer : MonoBehaviour
{
    public Text Username;
    public Text Score;
    public Text Rank;


    public string username;
    public int score;
    public int rank;
    public void AssignInfo()
    {
        Username.text = username;
        Score.text = score.ToString();
        Rank.text = rank.ToString() + ".";
    }
    
}
