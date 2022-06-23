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
    public List<int> lvl_1_requirements_list = new List<int>();
    public List<int> lvl_2_requirements_list = new List<int>();
    public List<int> lvl_3_requirements_list = new List<int>();
    public List<int> lvl_4_requirements_list = new List<int>();
    public List<int> lvl_5_requirements_list = new List<int>();
    public List<int> lvl_6_requirements_list = new List<int>();
    public List<int> lvl_7_requirements_list = new List<int>();
    public List<int> lvl_8_requirements_list = new List<int>();
    public List<int> lvl_9_requirements_list = new List<int>();
    public List<int> lvl_10_requirements_list = new List<int>();
    public int dungeon_lvl = 1;
    public int dungeon_zone = 0;
    public bool player_can_uncover = true;
    public int lvl_requirements = 0;
    public int lvl_progress = 0;
    public string lvl_buff = "Nothing";
    public bool action_done = false;

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
