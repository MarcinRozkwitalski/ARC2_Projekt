using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapStatus : MonoBehaviour
{
    public List<string> lvl_1_list = new List<string>();
    public List<string> lvl_2_list = new List<string>();
    public List<string> lvl_3_list = new List<string>();
    public List<string> lvl_4_list = new List<string>();
    public List<string> lvl_5_list = new List<string>();
    public List<string> lvl_6_list = new List<string>();
    public List<string> lvl_7_list = new List<string>();
    public List<string> lvl_8_list = new List<string>();
    public List<string> lvl_9_list = new List<string>();
    public List<string> lvl_10_list = new List<string>();
    public List<string> lvl_1_buff_list = new List<string>();
    public List<string> lvl_2_buff_list = new List<string>();
    public List<string> lvl_3_buff_list = new List<string>();
    public List<string> lvl_4_buff_list = new List<string>();
    public List<string> lvl_5_buff_list = new List<string>();
    public List<string> lvl_6_buff_list = new List<string>();
    public List<string> lvl_7_buff_list = new List<string>();
    public List<string> lvl_8_buff_list = new List<string>();
    public List<string> lvl_9_buff_list = new List<string>();
    public List<string> lvl_10_buff_list = new List<string>();
    public int player_lvl = 1;
    public bool player_can_uncover = true;
    void Awake()
    {
        var mapStatus = FindObjectsOfType<MapStatus>();
        if (mapStatus.Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
