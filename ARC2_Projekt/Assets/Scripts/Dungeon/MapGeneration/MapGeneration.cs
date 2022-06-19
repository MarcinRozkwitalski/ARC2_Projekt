using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public GameObject

            Mainpanel,
            lvl_1_panel,
            lvl_2_panel,
            lvl_3_panel,
            lvl_4_panel,
            lvl_5_panel,
            lvl_6_panel,
            lvl_7_panel,
            lvl_8_panel,
            lvl_9_panel,
            lvl_10_panel,
            buff_lvl_1_panel,
            buff_lvl_2_panel,
            buff_lvl_3_panel,
            buff_lvl_4_panel,
            buff_lvl_5_panel,
            buff_lvl_6_panel,
            buff_lvl_7_panel,
            buff_lvl_8_panel,
            buff_lvl_9_panel,
            buff_lvl_10_panel;

    public GameObject IconPrefab;
    public List<GameObject> lvl_panels = new List<GameObject>();
    public List<string> devils = new List<string>();
    public List<string> skulls = new List<string>();
    public List<string> sadness = new List<string>();
    public List<string> treasures = new List<string>();
    public List<string> crosses = new List<string>();
    public List<string> exits = new List<string>();
    public List<string> torches = new List<string>();

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


    void Awake()
    {
        SetPanelList();
    }

    void Start()
    {
        GenerateLevels();
    }

    public void GenerateLevels()
    {
        GenerateTypeOfIcons();
        ShuffleIconsToLevelLists();
        PutIconsToPanels();


    }

    public void SetPanelList()
    {
        lvl_panels.Add(lvl_1_panel);
        lvl_panels.Add(lvl_2_panel);
        lvl_panels.Add(lvl_3_panel);
        lvl_panels.Add(lvl_4_panel);
        lvl_panels.Add(lvl_5_panel);
        lvl_panels.Add(lvl_6_panel);
        lvl_panels.Add(lvl_7_panel);
        lvl_panels.Add(lvl_8_panel);
        lvl_panels.Add(lvl_9_panel);
        lvl_panels.Add(lvl_10_panel);
    }

    public GameObject GetPanel(int i)
    {
        GameObject panel = lvl_panels[i];
        return panel;
    }

    public void GenerateTypeOfIcons()
    {
        int numberOfIcons, badIcons, goodIcons;
        numberOfIcons = 20;//Random.Range(20, 41);
        badIcons = Mathf.RoundToInt(numberOfIcons * 0.6f);
        goodIcons = numberOfIcons - badIcons;
        Debug.Log("Icons = " + numberOfIcons + ", badIcons = " + badIcons + ", goodIcons = " + goodIcons);

        int skullsInt, devilsInt, sadnessInt;
        devilsInt = Mathf.RoundToInt(badIcons * 0.1f);
        sadnessInt = Mathf.RoundToInt(badIcons * 0.3f);
        skullsInt = badIcons - devilsInt - sadnessInt;
        AddSkullsToList(skullsInt);
        AddDevilsToList(devilsInt);
        AddSadnessToList(sadnessInt);
        Debug.Log("Skulls = " + skulls.Count + ", Devils = " + devils.Count + ", Sadness = " + sadness.Count);

        int treasureInt, crossInt, exitInt, torchInt;
        crossInt = Mathf.RoundToInt(goodIcons * 0.2f);
        exitInt = Mathf.RoundToInt(goodIcons * 0.1f);
        torchInt = Mathf.RoundToInt(goodIcons * 0.2f);
        treasureInt = goodIcons - crossInt - exitInt - torchInt;
        AddTreasureToList(treasureInt);
        AddCrossToList(crossInt);
        AddExitToList(exitInt);
        AddTorchToList(torchInt);
        Debug.Log("Treasures = " + treasures.Count + ", Crosses = " + crosses.Count + ", Exits = " + exits.Count + ", Torches = " + torches.Count);
    }

    public void AddSkullsToList(int j)
    {
        for (int i = 0; i < j; i++)
        {
            skulls.Add("Skull");
        }
    }
    public void AddDevilsToList(int j)
    {
        for (int i = 0; i < j; i++)
        {
            devils.Add("Devil");
        }
    }
    public void AddSadnessToList(int j)
    {
        for (int i = 0; i < j; i++)
        {
            sadness.Add("Sadness");
        }
    }
    public void AddTreasureToList(int j)
    {
        for (int i = 0; i < j; i++)
        {
            treasures.Add("Treasure");
        }
    }
    public void AddCrossToList(int j)
    {
        for (int i = 0; i < j; i++)
        {
            crosses.Add("Cross");
        }
    }
    public void AddExitToList(int j)
    {
        for (int i = 0; i < j; i++)
        {
            exits.Add("Exit");
        }
    }
    public void AddTorchToList(int j)
    {
        for (int i = 0; i < j; i++)
        {
            torches.Add("Torch");
        }
    }

    public void ShuffleIconsToLevelLists()
    {
        PutDevils();
        PutExits();
        PutCrosses();
        PutTorches();
        PutSadness();
        PutTreasures();
    }

    public void PutTreasures()
    {
        while (treasures.Count > 0)
        {
            int position = Random.Range(1, 11);
            switch (position)
            {
                case 1:
                    if (!lvl_1_list.Contains("Treasure") && !lvl_1_list.Contains("Devil") && lvl_1_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_1_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    if (!lvl_1_list.Contains("Treasure") && !lvl_1_list.Contains("Devil") && lvl_1_list.Contains("Cross") && lvl_1_list.Count < 4 && Random.Range(1, 11) > 4)
                    {
                        lvl_1_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    break;
                case 2:
                    if (!lvl_2_list.Contains("Treasure") && !lvl_2_list.Contains("Devil") && lvl_2_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_2_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    if (!lvl_2_list.Contains("Treasure") && !lvl_2_list.Contains("Devil") && lvl_2_list.Contains("Cross") && lvl_2_list.Count < 4 && Random.Range(1, 11) > 4)
                    {
                        lvl_2_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    break;
                case 3:
                    if (!lvl_3_list.Contains("Treasure") && !lvl_3_list.Contains("Devil") && lvl_3_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_3_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    if (!lvl_3_list.Contains("Treasure") && !lvl_3_list.Contains("Devil") && lvl_3_list.Contains("Cross") && lvl_3_list.Count < 4 && Random.Range(1, 11) > 4)
                    {
                        lvl_3_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    break;
                case 4:
                    if (!lvl_4_list.Contains("Treasure") && !lvl_4_list.Contains("Devil") && lvl_4_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_4_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    if (!lvl_4_list.Contains("Treasure") && !lvl_4_list.Contains("Devil") && lvl_4_list.Contains("Cross") && lvl_4_list.Count < 4 && Random.Range(1, 11) > 4)
                    {
                        lvl_4_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    break;
                case 5:
                    if (!lvl_5_list.Contains("Treasure") && !lvl_5_list.Contains("Devil") && lvl_5_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_5_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    if (!lvl_5_list.Contains("Treasure") && !lvl_5_list.Contains("Devil") && lvl_5_list.Contains("Cross") && lvl_5_list.Count < 4 && Random.Range(1, 11) > 4)
                    {
                        lvl_5_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    break;
                case 6:
                    if (!lvl_6_list.Contains("Treasure") && !lvl_6_list.Contains("Devil") && lvl_6_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_6_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    if (!lvl_6_list.Contains("Treasure") && !lvl_6_list.Contains("Devil") && lvl_6_list.Contains("Cross") && lvl_6_list.Count < 4 && Random.Range(1, 11) > 4)
                    {
                        lvl_6_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    break;
                case 7:
                    if (!lvl_7_list.Contains("Treasure") && !lvl_7_list.Contains("Devil") && lvl_7_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_7_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    if (!lvl_7_list.Contains("Treasure") && !lvl_7_list.Contains("Devil") && lvl_7_list.Contains("Cross") && lvl_7_list.Count < 4 && Random.Range(1, 11) > 4)
                    {
                        lvl_7_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    break;
                case 8:
                    if (!lvl_8_list.Contains("Treasure") && !lvl_8_list.Contains("Devil") && lvl_8_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_8_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    if (!lvl_8_list.Contains("Treasure") && !lvl_8_list.Contains("Devil") && lvl_8_list.Contains("Cross") && lvl_8_list.Count < 4 && Random.Range(1, 11) > 4)
                    {
                        lvl_8_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    break;
                case 9:
                    if (!lvl_9_list.Contains("Treasure") && !lvl_9_list.Contains("Devil") && lvl_9_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_9_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    if (!lvl_9_list.Contains("Treasure") && !lvl_9_list.Contains("Devil") && lvl_9_list.Contains("Cross") && lvl_9_list.Count < 4 && Random.Range(1, 11) > 4)
                    {
                        lvl_9_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    break;
                case 10:
                    if (!lvl_10_list.Contains("Treasure") && !lvl_10_list.Contains("Devil") && lvl_10_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_10_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    if (!lvl_10_list.Contains("Treasure") && !lvl_10_list.Contains("Devil") && lvl_10_list.Contains("Cross") && lvl_10_list.Count < 4 && Random.Range(1, 11) > 4)
                    {
                        lvl_10_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    break;
            }
        }
    }

    public void PutSadness()
    {
        while (sadness.Count > 0)
        {
            int position = Random.Range(1, 11);
            switch (position)
            {
                case 1:
                    if (!lvl_1_list.Contains("Sadness") && lvl_1_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_1_list.Add("Sadness");
                        sadness.RemoveAt(sadness.Count - 1);
                    }
                    break;
                case 2:
                    if (!lvl_2_list.Contains("Sadness") && lvl_2_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_2_list.Add("Sadness");
                        sadness.RemoveAt(sadness.Count - 1);
                    }
                    break;
                case 3:
                    if (!lvl_3_list.Contains("Sadness") && lvl_3_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_3_list.Add("Sadness");
                        sadness.RemoveAt(sadness.Count - 1);
                    }
                    break;
                case 4:
                    if (!lvl_4_list.Contains("Sadness") && lvl_4_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_4_list.Add("Sadness");
                        sadness.RemoveAt(sadness.Count - 1);
                    }
                    else if (!lvl_4_list.Contains("Sadness") && lvl_4_list.Contains("Devil") && lvl_4_list.Count < 4 && Random.Range(1, 11) >= 4)
                    {
                        lvl_4_list.Add("Sadness");
                        sadness.RemoveAt(sadness.Count - 1);
                    }
                    break;
                case 5:
                    if (!lvl_5_list.Contains("Sadness") && lvl_5_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_5_list.Add("Sadness");
                        sadness.RemoveAt(sadness.Count - 1);
                    }
                    else if (!lvl_5_list.Contains("Sadness") && lvl_5_list.Contains("Devil") && lvl_5_list.Count < 4 && Random.Range(1, 11) >= 4)
                    {
                        lvl_5_list.Add("Sadness");
                        sadness.RemoveAt(sadness.Count - 1);
                    }
                    break;
                case 6:
                    if (!lvl_6_list.Contains("Sadness") && lvl_6_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_6_list.Add("Sadness");
                        sadness.RemoveAt(sadness.Count - 1);
                    }
                    else if (!lvl_6_list.Contains("Sadness") && lvl_6_list.Contains("Devil") && lvl_6_list.Count < 4 && Random.Range(1, 11) >= 4)
                    {
                        lvl_6_list.Add("Sadness");
                        sadness.RemoveAt(sadness.Count - 1);
                    }
                    break;
                case 7:
                    if (!lvl_7_list.Contains("Sadness") && lvl_7_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_7_list.Add("Sadness");
                        sadness.RemoveAt(sadness.Count - 1);
                    }
                    else if (!lvl_7_list.Contains("Sadness") && lvl_7_list.Contains("Devil") && lvl_7_list.Count < 4 && Random.Range(1, 11) >= 4)
                    {
                        lvl_7_list.Add("Sadness");
                        sadness.RemoveAt(sadness.Count - 1);
                    }
                    break;
                case 8:
                    if (!lvl_8_list.Contains("Sadness") && lvl_8_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_8_list.Add("Sadness");
                        sadness.RemoveAt(sadness.Count - 1);
                    }
                    else if (!lvl_8_list.Contains("Sadness") && lvl_8_list.Contains("Devil") && lvl_8_list.Count < 4 && Random.Range(1, 11) >= 4)
                    {
                        lvl_8_list.Add("Sadness");
                        sadness.RemoveAt(sadness.Count - 1);
                    }
                    break;
                case 9:
                    if (!lvl_9_list.Contains("Sadness") && lvl_9_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_9_list.Add("Sadness");
                        sadness.RemoveAt(sadness.Count - 1);
                    }
                    else if (!lvl_9_list.Contains("Sadness") && lvl_9_list.Contains("Devil") && lvl_9_list.Count < 4 && Random.Range(1, 11) >= 4)
                    {
                        lvl_9_list.Add("Sadness");
                        sadness.RemoveAt(sadness.Count - 1);
                    }
                    break;
                case 10:
                    if (!lvl_10_list.Contains("Sadness") && lvl_10_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_10_list.Add("Sadness");
                        sadness.RemoveAt(sadness.Count - 1);
                    }
                    else if (!lvl_10_list.Contains("Sadness") && lvl_10_list.Contains("Devil") && lvl_10_list.Count < 4 && Random.Range(1, 11) >= 4)
                    {
                        lvl_10_list.Add("Sadness");
                        sadness.RemoveAt(sadness.Count - 1);
                    }
                    break;
            }
        }
    }

    public void PutTorches()
    {
        while (torches.Count > 0)
        {
            int position = Random.Range(1, 6);
            switch (position)
            {
                case 1:
                    if (!lvl_3_list.Contains("Torch") && lvl_3_list.Count < 4)
                    {
                        lvl_3_list.Add("Torch");
                        torches.RemoveAt(torches.Count - 1);
                    }
                    break;
                case 2:
                    if (!lvl_4_list.Contains("Torch") && lvl_4_list.Count < 4)
                    {
                        lvl_4_list.Add("Torch");
                        torches.RemoveAt(torches.Count - 1);
                    }
                    break;
                case 3:
                    if (!lvl_5_list.Contains("Torch") && lvl_5_list.Count < 4)
                    {
                        lvl_5_list.Add("Torch");
                        torches.RemoveAt(torches.Count - 1);
                    }
                    break;
                case 4:
                    if (!lvl_6_list.Contains("Torch") && lvl_6_list.Count < 4)
                    {
                        lvl_6_list.Add("Torch");
                        torches.RemoveAt(torches.Count - 1);
                    }
                    break;
                case 5:
                    if (!lvl_7_list.Contains("Torch") && lvl_7_list.Count < 4)
                    {
                        lvl_7_list.Add("Torch");
                        torches.RemoveAt(torches.Count - 1);
                    }
                    break;
            }
        }
    }

    public void PutCrosses()
    {
        while (crosses.Count > 0)
        {
            int position = Random.Range(1, 10);
            switch (position)
            {
                case 1:
                    if (!lvl_2_list.Contains("Cross") && !lvl_3_list.Contains("Cross") && !lvl_4_list.Contains("Cross") && !lvl_5_list.Contains("Cross") && lvl_2_list.Count < 4)
                    {
                        lvl_2_list.Add("Cross");
                        crosses.RemoveAt(crosses.Count - 1);
                    }
                    break;
                case 2:
                    if (!lvl_2_list.Contains("Cross") && !lvl_3_list.Contains("Cross") && !lvl_4_list.Contains("Cross") && !lvl_5_list.Contains("Cross") && lvl_3_list.Count < 4)
                    {
                        lvl_3_list.Add("Cross");
                        crosses.RemoveAt(crosses.Count - 1);
                    }
                    break;
                case 3:
                    if (!lvl_2_list.Contains("Cross") && !lvl_3_list.Contains("Cross") && !lvl_4_list.Contains("Cross") && !lvl_5_list.Contains("Cross") && lvl_4_list.Count < 4)
                    {
                        lvl_4_list.Add("Cross");
                        crosses.RemoveAt(crosses.Count - 1);
                    }
                    break;
                case 4:
                    if (!lvl_2_list.Contains("Cross") && !lvl_3_list.Contains("Cross") && !lvl_4_list.Contains("Cross") && !lvl_5_list.Contains("Cross") && lvl_5_list.Count < 4)
                    {
                        lvl_5_list.Add("Cross");
                        crosses.RemoveAt(crosses.Count - 1);
                    }
                    break;
                case 5:
                    if (!lvl_6_list.Contains("Cross") && lvl_6_list.Count < 4)
                    {
                        lvl_6_list.Add("Cross");
                        crosses.RemoveAt(crosses.Count - 1);
                    }
                    break;
                case 6:
                    if (!lvl_7_list.Contains("Cross") && lvl_7_list.Count < 4)
                    {
                        lvl_7_list.Add("Cross");
                        crosses.RemoveAt(crosses.Count - 1);
                    }
                    break;
                case 7:
                    if (!lvl_8_list.Contains("Cross") && lvl_8_list.Count < 4)
                    {
                        lvl_8_list.Add("Cross");
                        crosses.RemoveAt(crosses.Count - 1);
                    }
                    break;
                case 8:
                    if (!lvl_9_list.Contains("Cross") && lvl_9_list.Count < 4)
                    {
                        lvl_9_list.Add("Cross");
                        crosses.RemoveAt(crosses.Count - 1);
                    }
                    break;
                case 9:
                    if (!lvl_10_list.Contains("Cross") && lvl_10_list.Count < 4)
                    {
                        lvl_10_list.Add("Cross");
                        crosses.RemoveAt(crosses.Count - 1);
                    }
                    break;
            }
        }
    }

    public void PutExits()
    {
        while (exits.Count > 0)
        {
            if (exits.Count == 1)
            {
                lvl_10_list.Add("Exit");
                exits.RemoveAt(exits.Count - 1);
            }
            else
            {
                int position = Random.Range(1, 5);
                switch (position)
                {
                    case 1:
                        if (!lvl_5_list.Contains("Exit") && !lvl_5_list.Contains("Devil") && !lvl_6_list.Contains("Exit") && lvl_5_list.Count < 4)
                        {
                            lvl_5_list.Add("Exit");
                            exits.RemoveAt(exits.Count - 1);
                        }
                        break;
                    case 2:
                        if (!lvl_5_list.Contains("Exit") && !lvl_6_list.Contains("Exit") && !lvl_6_list.Contains("Devil") && !lvl_7_list.Contains("Exit") && lvl_6_list.Count < 4)
                        {
                            lvl_6_list.Add("Exit");
                            exits.RemoveAt(exits.Count - 1);
                        }
                        break;
                    case 3:
                        if (!lvl_6_list.Contains("Exit") && !lvl_7_list.Contains("Exit") && !lvl_7_list.Contains("Devil") && !lvl_8_list.Contains("Exit") && lvl_7_list.Count < 4)
                        {
                            lvl_7_list.Add("Exit");
                            exits.RemoveAt(exits.Count - 1);
                        }
                        break;
                    case 4:
                        if (!lvl_7_list.Contains("Exit") && !lvl_8_list.Contains("Exit") && !lvl_8_list.Contains("Devil") && !lvl_9_list.Contains("Exit") && lvl_8_list.Count < 4)
                        {
                            lvl_8_list.Add("Exit");
                            exits.RemoveAt(exits.Count - 1);
                        }
                        break;
                }
            }
        }
    }

    public void PutDevils()
    {
        while (devils.Count > 0)
        {
            int position = Random.Range(1, 8);
            switch (position)
            {
                case 1:
                    if (!lvl_4_list.Contains("Devil") && !lvl_5_list.Contains("Devil") && lvl_4_list.Count < 4)
                    {
                        lvl_4_list.Add("Devil");
                        devils.RemoveAt(devils.Count - 1);
                    }
                    else if (!lvl_4_list.Contains("Devil") && lvl_5_list.Contains("Devil") && lvl_4_list.Count < 4 && Random.Range(1, 11) < 3)
                    {
                        lvl_4_list.Add("Devil");
                        devils.RemoveAt(devils.Count - 1);
                    }
                    break;
                case 2:
                    if (!lvl_4_list.Contains("Devil") && !lvl_5_list.Contains("Devil") && !lvl_6_list.Contains("Devil") && lvl_5_list.Count < 4)
                    {
                        lvl_5_list.Add("Devil");
                        devils.RemoveAt(devils.Count - 1);
                    }
                    else if (lvl_4_list.Contains("Devil") && !lvl_5_list.Contains("Devil") && !lvl_6_list.Contains("Devil") && lvl_5_list.Count < 4 && Random.Range(1, 11) < 3)
                    {
                        lvl_5_list.Add("Devil");
                        devils.RemoveAt(devils.Count - 1);
                    }
                    else if (!lvl_4_list.Contains("Devil") && !lvl_5_list.Contains("Devil") && lvl_6_list.Contains("Devil") && lvl_5_list.Count < 4 && Random.Range(1, 11) < 3)
                    {
                        lvl_5_list.Add("Devil");
                        devils.RemoveAt(devils.Count - 1);
                    }
                    break;
                case 3:
                    if (!lvl_5_list.Contains("Devil") && !lvl_6_list.Contains("Devil") && !lvl_7_list.Contains("Devil") && lvl_6_list.Count < 4)
                    {
                        lvl_6_list.Add("Devil");
                        devils.RemoveAt(devils.Count - 1);
                    }
                    else if (lvl_5_list.Contains("Devil") && !lvl_6_list.Contains("Devil") && !lvl_7_list.Contains("Devil") && lvl_6_list.Count < 4 && Random.Range(1, 11) < 3)
                    {
                        lvl_6_list.Add("Devil");
                        devils.RemoveAt(devils.Count - 1);
                    }
                    else if (!lvl_5_list.Contains("Devil") && !lvl_6_list.Contains("Devil") && lvl_7_list.Contains("Devil") && lvl_6_list.Count < 4 && Random.Range(1, 11) < 3)
                    {
                        lvl_6_list.Add("Devil");
                        devils.RemoveAt(devils.Count - 1);
                    }
                    break;
                case 4:
                    if (!lvl_6_list.Contains("Devil") && !lvl_7_list.Contains("Devil") && !lvl_8_list.Contains("Devil") && lvl_7_list.Count < 4)
                    {
                        lvl_7_list.Add("Devil");
                        devils.RemoveAt(devils.Count - 1);
                    }
                    else if (lvl_6_list.Contains("Devil") && !lvl_7_list.Contains("Devil") && !lvl_8_list.Contains("Devil") && lvl_7_list.Count < 4 && Random.Range(1, 11) < 3)
                    {
                        lvl_7_list.Add("Devil");
                        devils.RemoveAt(devils.Count - 1);
                    }
                    else if (!lvl_6_list.Contains("Devil") && !lvl_7_list.Contains("Devil") && lvl_8_list.Contains("Devil") && lvl_7_list.Count < 4 && Random.Range(1, 11) < 3)
                    {
                        lvl_7_list.Add("Devil");
                        devils.RemoveAt(devils.Count - 1);
                    }
                    break;
                case 5:
                    if (!lvl_7_list.Contains("Devil") && !lvl_8_list.Contains("Devil") && !lvl_9_list.Contains("Devil") && lvl_8_list.Count < 4)
                    {
                        lvl_8_list.Add("Devil");
                        devils.RemoveAt(devils.Count - 1);
                    }
                    else if (lvl_7_list.Contains("Devil") && !lvl_8_list.Contains("Devil") && !lvl_9_list.Contains("Devil") && lvl_8_list.Count < 4 && Random.Range(1, 11) < 3)
                    {
                        lvl_8_list.Add("Devil");
                        devils.RemoveAt(devils.Count - 1);
                    }
                    else if (!lvl_7_list.Contains("Devil") && !lvl_8_list.Contains("Devil") && lvl_9_list.Contains("Devil") && lvl_8_list.Count < 4 && Random.Range(1, 11) < 3)
                    {
                        lvl_8_list.Add("Devil");
                        devils.RemoveAt(devils.Count - 1);
                    }
                    break;
                case 6:
                    if (!lvl_8_list.Contains("Devil") && !lvl_9_list.Contains("Devil") && !lvl_10_list.Contains("Devil") && lvl_9_list.Count < 4)
                    {
                        lvl_9_list.Add("Devil");
                        devils.RemoveAt(devils.Count - 1);
                    }
                    else if (lvl_8_list.Contains("Devil") && !lvl_9_list.Contains("Devil") && !lvl_10_list.Contains("Devil") && lvl_9_list.Count < 4 && Random.Range(1, 11) < 3)
                    {
                        lvl_9_list.Add("Devil");
                        devils.RemoveAt(devils.Count - 1);
                    }
                    else if (!lvl_8_list.Contains("Devil") && !lvl_9_list.Contains("Devil") && lvl_10_list.Contains("Devil") && lvl_9_list.Count < 4 && Random.Range(1, 11) < 3)
                    {
                        lvl_9_list.Add("Devil");
                        devils.RemoveAt(devils.Count - 1);
                    }
                    break;
                case 7:
                    if (!lvl_9_list.Contains("Devil") && !lvl_10_list.Contains("Devil") && lvl_10_list.Count < 4)
                    {
                        lvl_10_list.Add("Devil");
                        devils.RemoveAt(devils.Count - 1);
                    }
                    else if (!lvl_10_list.Contains("Devil") && lvl_9_list.Contains("Devil") && lvl_10_list.Count < 4 && Random.Range(1, 11) < 3)
                    {
                        lvl_10_list.Add("Devil");
                        devils.RemoveAt(devils.Count - 1);
                    }
                    break;
            }
        }
    }

    public void PutIconsToPanels()
    {

        for (int i = 0; i < lvl_1_list.Count; i++)
        {
            var icon = Instantiate(IconPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            icon.transform.SetParent(GetPanel(0).transform);
            GetIconSymbol(lvl_1_list[i], icon);
        }
        for (int i = 0; i < lvl_2_list.Count; i++)
        {
            var icon = Instantiate(IconPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            icon.transform.SetParent(GetPanel(1).transform);
            GetIconSymbol(lvl_2_list[i], icon);
        }
        for (int i = 0; i < lvl_3_list.Count; i++)
        {
            var icon = Instantiate(IconPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            icon.transform.SetParent(GetPanel(2).transform);
            GetIconSymbol(lvl_3_list[i], icon);
        }
        for (int i = 0; i < lvl_4_list.Count; i++)
        {
            var icon = Instantiate(IconPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            icon.transform.SetParent(GetPanel(3).transform);
            GetIconSymbol(lvl_4_list[i], icon);
        }
        for (int i = 0; i < lvl_5_list.Count; i++)
        {
            var icon = Instantiate(IconPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            icon.transform.SetParent(GetPanel(4).transform);
            GetIconSymbol(lvl_5_list[i], icon);
        }
        for (int i = 0; i < lvl_6_list.Count; i++)
        {
            var icon = Instantiate(IconPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            icon.transform.SetParent(GetPanel(5).transform);
            GetIconSymbol(lvl_6_list[i], icon);
        }
        for (int i = 0; i < lvl_7_list.Count; i++)
        {
            var icon = Instantiate(IconPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            icon.transform.SetParent(GetPanel(6).transform);
            GetIconSymbol(lvl_7_list[i], icon);
        }
        for (int i = 0; i < lvl_8_list.Count; i++)
        {
            var icon = Instantiate(IconPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            icon.transform.SetParent(GetPanel(7).transform);
            GetIconSymbol(lvl_8_list[i], icon);
        }
        for (int i = 0; i < lvl_9_list.Count; i++)
        {
            var icon = Instantiate(IconPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            icon.transform.SetParent(GetPanel(8).transform);
            GetIconSymbol(lvl_9_list[i], icon);
        }
        for (int i = 0; i < lvl_10_list.Count; i++)
        {
            var icon = Instantiate(IconPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            icon.transform.SetParent(GetPanel(9).transform);
            GetIconSymbol(lvl_10_list[i], icon);
        }

    }

    public void GetIconSymbol(string symbol, GameObject icon)
    {
        switch (symbol)
        {
            case "Skull":
                icon.transform.Find("GrayDirt").gameObject.SetActive(false);
                icon.transform.Find("Devil").gameObject.SetActive(false);
                icon.transform.Find("Treasure").gameObject.SetActive(false);
                icon.transform.Find("Cross").gameObject.SetActive(false);
                icon.transform.Find("Torch").gameObject.SetActive(false);
                icon.transform.Find("Exit").gameObject.SetActive(false);
                icon.transform.Find("Sadness").gameObject.SetActive(false);
                break;
            case "Devil":
                icon.transform.Find("GrayDirt").gameObject.SetActive(false);
                icon.transform.Find("Skull").gameObject.SetActive(false);
                icon.transform.Find("Treasure").gameObject.SetActive(false);
                icon.transform.Find("Cross").gameObject.SetActive(false);
                icon.transform.Find("Torch").gameObject.SetActive(false);
                icon.transform.Find("Exit").gameObject.SetActive(false);
                icon.transform.Find("Sadness").gameObject.SetActive(false);
                break;
            case "Treasure":
                icon.transform.Find("GrayDirt").gameObject.SetActive(false);
                icon.transform.Find("Devil").gameObject.SetActive(false);
                icon.transform.Find("Skull").gameObject.SetActive(false);
                icon.transform.Find("Cross").gameObject.SetActive(false);
                icon.transform.Find("Torch").gameObject.SetActive(false);
                icon.transform.Find("Exit").gameObject.SetActive(false);
                icon.transform.Find("Sadness").gameObject.SetActive(false);
                break;
            case "Cross":
                icon.transform.Find("GrayDirt").gameObject.SetActive(false);
                icon.transform.Find("Devil").gameObject.SetActive(false);
                icon.transform.Find("Treasure").gameObject.SetActive(false);
                icon.transform.Find("Skull").gameObject.SetActive(false);
                icon.transform.Find("Torch").gameObject.SetActive(false);
                icon.transform.Find("Exit").gameObject.SetActive(false);
                icon.transform.Find("Sadness").gameObject.SetActive(false);
                break;
            case "Torch":
                icon.transform.Find("GrayDirt").gameObject.SetActive(false);
                icon.transform.Find("Devil").gameObject.SetActive(false);
                icon.transform.Find("Treasure").gameObject.SetActive(false);
                icon.transform.Find("Cross").gameObject.SetActive(false);
                icon.transform.Find("Skull").gameObject.SetActive(false);
                icon.transform.Find("Exit").gameObject.SetActive(false);
                icon.transform.Find("Sadness").gameObject.SetActive(false);
                break;
            case "Exit":
                icon.transform.Find("GrayDirt").gameObject.SetActive(false);
                icon.transform.Find("Devil").gameObject.SetActive(false);
                icon.transform.Find("Treasure").gameObject.SetActive(false);
                icon.transform.Find("Cross").gameObject.SetActive(false);
                icon.transform.Find("Torch").gameObject.SetActive(false);
                icon.transform.Find("Skull").gameObject.SetActive(false);
                icon.transform.Find("Sadness").gameObject.SetActive(false);
                break;
            case "Sadness":
                icon.transform.Find("GrayDirt").gameObject.SetActive(false);
                icon.transform.Find("Devil").gameObject.SetActive(false);
                icon.transform.Find("Treasure").gameObject.SetActive(false);
                icon.transform.Find("Cross").gameObject.SetActive(false);
                icon.transform.Find("Torch").gameObject.SetActive(false);
                icon.transform.Find("Skull").gameObject.SetActive(false);
                icon.transform.Find("Exit").gameObject.SetActive(false);
                break;
        }
    }
}
