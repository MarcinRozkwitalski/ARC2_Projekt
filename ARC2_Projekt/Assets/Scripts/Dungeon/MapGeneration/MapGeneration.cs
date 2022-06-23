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
            buff_lvl_10_panel,
            lvl_1_cover, lvl_2_cover, lvl_3_cover, lvl_4_cover, lvl_5_cover, lvl_6_cover, lvl_7_cover, lvl_8_cover, lvl_9_cover, lvl_10_cover;

    public GameObject IconPrefab, BuffIconPrefab, MapStatus, SceneSwitcher, TempPlayer;
    public List<GameObject> lvl_panels = new List<GameObject>();
    public List<string> devils = new List<string>();
    public List<string> skulls = new List<string>();
    public List<string> sadness = new List<string>();
    public List<string> treasures = new List<string>();
    public List<string> crosses = new List<string>();
    public List<string> exits = new List<string>();
    public List<string> torches = new List<string>();
    public List<string> events = new List<string>();
    public List<string> altars = new List<string>();
    public List<string> messengers = new List<string>();

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
    private bool player_can_uncover = false;
    public int lvl_requirements = 0;
    public int lvl_progress = 0;
    public string lvl_buff = "Nothing";


    void Awake()
    {
        SetPanelList();
        MapStatus = GameObject.Find("MapStatus");
        SceneSwitcher = GameObject.Find("SceneManager");
        TempPlayer = GameObject.Find("PlayerManager");
    }

    void Start()
    {

        if (MapStatus.GetComponent<MapStatus>().lvl_1_list.Count == 0)
        {
            ShowLevel();
            GenerateLevels();
        }
        else
        {
            if (MapStatus.GetComponent<MapStatus>().action_done == true) AfterAction();
            UpdateMapGeneration();
            ShowLevel();
            PutIconsToPanels();
            PutBuffIconsToPanels();
        }
    }

    public int GetDungeonLevelStatus()
    {
        return dungeon_lvl;
    }

    public void UseTreasuer()
    {
        // pop up? bar?
        int option = Random.Range(1, 4);
        switch (option)
        {
            case 1:
                if (lvl_buff == "IncreaseMoney") TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney += Mathf.RoundToInt(50 * ((dungeon_lvl + dungeon_zone * 10) * 5 + 25f) / 100);
                else TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney += Mathf.RoundToInt(50 * ((dungeon_lvl + dungeon_zone * 10) * 5) / 100);
                break;
            case 2:
                if (lvl_buff == "IncreaseMoney") TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney += Mathf.RoundToInt(50 * ((dungeon_lvl + dungeon_zone * 10) * 5 + 35f) / 100);
                else TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney += Mathf.RoundToInt(50 * ((dungeon_lvl + dungeon_zone * 10) * 5) / 100);
                break;
            case 3:
                if (lvl_buff == "IncreaseMoney") TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney += Mathf.RoundToInt(50 * ((dungeon_lvl + dungeon_zone * 10) * 5 + 45f) / 100);
                else TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney += Mathf.RoundToInt(50 * ((dungeon_lvl + dungeon_zone * 10) * 5) / 100);
                break;
        }
        AfterAction();
    }

    public void UseAltar()
    {
        // pop up? bar?
        TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerLife -= 20;
        int option = Random.Range(1, 4);
        switch (option)
        {
            case 1:
                if (lvl_buff == "IncreaseMoney") TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney += Mathf.RoundToInt(70 * ((dungeon_lvl + dungeon_zone * 10) * 5 + 25f) / 100);
                else TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney += Mathf.RoundToInt(50 * ((dungeon_lvl + dungeon_zone * 10) * 5) / 100);
                break;
            case 2:
                if (lvl_buff == "IncreaseMoney") TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney += Mathf.RoundToInt(70 * ((dungeon_lvl + dungeon_zone * 10) * 5 + 35f) / 100);
                else TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney += Mathf.RoundToInt(50 * ((dungeon_lvl + dungeon_zone * 10) * 5) / 100);
                break;
            case 3:
                if (lvl_buff == "IncreaseMoney") TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney += Mathf.RoundToInt(70 * ((dungeon_lvl + dungeon_zone * 10) * 5 + 45f) / 100);
                else TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney += Mathf.RoundToInt(50 * ((dungeon_lvl + dungeon_zone * 10) * 5) / 100);
                break;

        }
        AfterAction();
    }
    public void UseSadness()
    {
        // pop up? bar?
        int option = Random.Range(1, 4);
        switch (option)
        {
            case 1:
                TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney = Mathf.RoundToInt(TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney * 0.75f);
                break;
            case 2:
                TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney = Mathf.RoundToInt(TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney * 0.65f);
                break;
            case 3:
                TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney = Mathf.RoundToInt(TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney * 0.55f);
                break;
        }
        AfterAction();
    }

    public void UseEvent()
    {
        // pop up? bar? MUST !!!!
        int option = Random.Range(1, 5);
        switch (option)
        {
            case 1:
                TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerSaveMoney += 20;
                break;
            case 2:
                TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerLife -= 20;
                break;
            case 3:
                TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerLife += 20;
                break;
            case 4:
                TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney = Mathf.RoundToInt(TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney * 1.20f);
                break;
        }
        AfterAction();
    }

    public void UseMessenger()
    {
        // pop up? bar?
        TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerSaveMoney = Mathf.RoundToInt(TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney * 0.5f);
        TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerMoney = 0;
        AfterAction();
    }

    public void UseCross()
    {
        // pop up? bar?
        int option = Random.Range(1, 4);
        switch (option)
        {
            case 1:
                TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerLife += 20;
                if (TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerLife > 100) TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerLife = 100;
                break;
            case 2:
                TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerLife += 30;
                if (TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerLife > 100) TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerLife = 100;
                break;
            case 3:
                TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerLife += 40;
                if (TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerLife > 100) TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerLife = 100;
                break;
        }
        AfterAction();
    }
    public void UseTorch()
    {
        // Pop up?
        player_can_uncover = true;
        UpdateMapStatusPlayerCover();
        CheckIfOnlyTorchOnLevel();
    }
    public void CheckIfOnlyTorchOnLevel()
    {
        switch (dungeon_lvl)
        {
            case 1:
                if (lvl_1_list.Count == 1) AfterAction();
                break;
            case 2:
                if (lvl_2_list.Count == 1) AfterAction();
                break;
            case 3:
                if (lvl_3_list.Count == 1) AfterAction();
                break;
            case 4:
                if (lvl_4_list.Count == 1) AfterAction();
                break;
            case 5:
                if (lvl_5_list.Count == 1) AfterAction();
                break;
            case 6:
                if (lvl_6_list.Count == 1) AfterAction();
                break;
            case 7:
                if (lvl_7_list.Count == 1) AfterAction();
                break;
            case 8:
                if (lvl_8_list.Count == 1) AfterAction();
                break;
            case 9:
                if (lvl_9_list.Count == 1) AfterAction();
                break;
            case 10:
                if (lvl_10_list.Count == 1) AfterAction();
                break;
        }
    }
    public void UseExit()
    {
        SceneSwitcher.GetComponent<SceneSwitcher>().LoadPlayerWelcomeScene();
        Destroy(GameObject.Find("MapStatus"));
        Destroy(GameObject.Find("PlayerManager"));
        // zapis postępu w lochach i wyjście
    }

    public void AfterAction()
    {
        if (TempPlayer.GetComponent<TempCurrentPlayer>().TempPlayerLife <= 0) UseExit();
        UpdateLevelProgress();
        if (lvl_progress == lvl_requirements) NextLevel();
    }

    public void UpdateLevelProgress()
    {
        lvl_progress++;
    }

    public void NextLevel()
    {
        DisableUnusedButtons();
        UpdateDungeonLevel();
        ResetLevelProgress();
        CheckLevelRequirements();
        SetLevelBuff();
        DisableForbidenButtons();
    }

    public void UpdateDungeonLevel()
    {
        dungeon_lvl++;
        if (dungeon_lvl > 10)
        {
            dungeon_lvl = 1;
            dungeon_zone++;
            MapStatus.GetComponent<MapStatus>().dungeon_zone = dungeon_zone;
            MapStatus.GetComponent<MapStatus>().dungeon_lvl = dungeon_lvl;
            GenerateNewZone();
        }
        else
        {
            MapStatus.GetComponent<MapStatus>().dungeon_lvl = dungeon_lvl;
            ShowLevel();
        }
    }

    public void GenerateNewZone()
    {
        DestroyIcons();
        Coverlevels();
        ShowLevel();
        ClearAllLists();
        GenerateLevels();
    }

    public void ClearAllLists()
    {
        devils.Clear();
        skulls.Clear();
        sadness.Clear();
        treasures.Clear();
        crosses.Clear();
        exits.Clear();
        torches.Clear();
        events.Clear();
        altars.Clear();
        messengers.Clear();
        lvl_1_list.Clear();
        lvl_2_list.Clear();
        lvl_3_list.Clear();
        lvl_4_list.Clear();
        lvl_5_list.Clear();
        lvl_6_list.Clear();
        lvl_7_list.Clear();
        lvl_8_list.Clear();
        lvl_9_list.Clear();
        lvl_10_list.Clear();
        lvl_1_buff_list.Clear();
        lvl_2_buff_list.Clear();
        lvl_3_buff_list.Clear();
        lvl_4_buff_list.Clear();
        lvl_5_buff_list.Clear();
        lvl_6_buff_list.Clear();
        lvl_7_buff_list.Clear();
        lvl_8_buff_list.Clear();
        lvl_9_buff_list.Clear();
        lvl_10_buff_list.Clear();
        lvl_1_requirements_list.Clear();
        lvl_2_requirements_list.Clear();
        lvl_3_requirements_list.Clear();
        lvl_4_requirements_list.Clear();
        lvl_5_requirements_list.Clear();
        lvl_6_requirements_list.Clear();
        lvl_7_requirements_list.Clear();
        lvl_8_requirements_list.Clear();
        lvl_9_requirements_list.Clear();
        lvl_10_requirements_list.Clear();
    }

    public void Coverlevels()
    {
        lvl_1_cover.SetActive(true);
        lvl_2_cover.SetActive(true);
        lvl_3_cover.SetActive(true);
        lvl_4_cover.SetActive(true);
        lvl_5_cover.SetActive(true);
        lvl_6_cover.SetActive(true);
        lvl_7_cover.SetActive(true);
        lvl_8_cover.SetActive(true);
        lvl_9_cover.SetActive(true);
        lvl_10_cover.SetActive(true);
    }

    public void DestroyIcons()
    {
        var DungeonIcons = GameObject.FindGameObjectsWithTag("DungeonIcon");
        foreach (var icon in DungeonIcons)
        {
            Destroy(icon);
        }
        var DungeonBuffIcons = GameObject.FindGameObjectsWithTag("BuffDungeonIcon");
        foreach (var icon in DungeonBuffIcons)
        {
            Destroy(icon);
        }
    }

    public void ResetLevelProgress()
    {
        lvl_progress = 0;
        MapStatus.GetComponent<MapStatus>().lvl_progress = lvl_progress;
    }

    public void DisableUnusedButtons()
    {
        foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("DungeonIcon"))
        {
            if (gameObj.GetComponent<DungeonIcon>().icon_lvl == dungeon_lvl)
            {
                gameObj.GetComponent<DungeonIcon>().Disable();
            }
        }

    }

    public void DisableForbidenButtons()
    {
        foreach (GameObject gameObj in GameObject.FindGameObjectsWithTag("DungeonIcon"))
        {
            if (gameObj.GetComponent<DungeonIcon>().icon_lvl == dungeon_lvl)
            {
                if (lvl_buff == "BadChoice" && gameObj.GetComponent<DungeonIcon>().iconType == "Good" || lvl_buff == "BadChoice" && gameObj.GetComponent<DungeonIcon>().iconType == "Neutral")
                    gameObj.GetComponent<DungeonIcon>().Disable();
                if (lvl_buff == "GoodChoice" && gameObj.GetComponent<DungeonIcon>().iconType == "Bad" || lvl_buff == "GoodChoice" && gameObj.GetComponent<DungeonIcon>().iconType == "Neutral")
                    gameObj.GetComponent<DungeonIcon>().Disable();
                if (lvl_buff == "NeutralChoice" && gameObj.GetComponent<DungeonIcon>().iconType == "Bad" || lvl_buff == "NeutralChoice" && gameObj.GetComponent<DungeonIcon>().iconType == "Good")
                    gameObj.GetComponent<DungeonIcon>().Disable();
            }
        }

    }
    public void SetLevelBuff()
    {
        switch (dungeon_lvl)
        {
            case 1: lvl_buff = lvl_1_buff_list[0]; break;
            case 2: lvl_buff = lvl_2_buff_list[0]; break;
            case 3: lvl_buff = lvl_3_buff_list[0]; break;
            case 4: lvl_buff = lvl_4_buff_list[0]; break;
            case 5: lvl_buff = lvl_5_buff_list[0]; break;
            case 6: lvl_buff = lvl_6_buff_list[0]; break;
            case 7: lvl_buff = lvl_7_buff_list[0]; break;
            case 8: lvl_buff = lvl_8_buff_list[0]; break;
            case 9: lvl_buff = lvl_9_buff_list[0]; break;
            case 10: lvl_buff = lvl_10_buff_list[0]; break;
        }
        MapStatus.GetComponent<MapStatus>().lvl_buff = lvl_buff;
    }

    public void CheckLevelRequirements()
    {
        switch (dungeon_lvl)
        {
            case 1: lvl_requirements = lvl_1_requirements_list[0]; break;
            case 2: lvl_requirements = lvl_2_requirements_list[0]; break;
            case 3: lvl_requirements = lvl_3_requirements_list[0]; break;
            case 4: lvl_requirements = lvl_4_requirements_list[0]; break;
            case 5: lvl_requirements = lvl_5_requirements_list[0]; break;
            case 6: lvl_requirements = lvl_6_requirements_list[0]; break;
            case 7: lvl_requirements = lvl_7_requirements_list[0]; break;
            case 8: lvl_requirements = lvl_8_requirements_list[0]; break;
            case 9: lvl_requirements = lvl_9_requirements_list[0]; break;
            case 10: lvl_requirements = lvl_10_requirements_list[0]; break;
        }
        MapStatus.GetComponent<MapStatus>().lvl_requirements = lvl_requirements;
    }

    public void SetLevelsRequirements(List<string> buff, List<int> requirements)
    {
        switch (buff[0])
        {
            case "Nothing":
            case "DoubleMonsterDamage":
            case "DoubleDamage":
            case "IncreaseMonsterDamage":
            case "IncreaseDamage":
            case "IncreaseMonsterMoney":
            case "IncreaseMoney":
            case "NeutralChoice":
            case "BadChoice":
            case "GoodChoice":
                requirements.Add(1);
                break;
            case "MoreOptions":
                requirements.Add(2);
                break;

        }
    }

    public void SetLevelsBuffsAndRequirements()
    {
        SetLevelsRequirements(lvl_1_buff_list, lvl_1_requirements_list);
        SetLevelsRequirements(lvl_2_buff_list, lvl_2_requirements_list);
        SetLevelsRequirements(lvl_3_buff_list, lvl_3_requirements_list);
        SetLevelsRequirements(lvl_4_buff_list, lvl_4_requirements_list);
        SetLevelsRequirements(lvl_5_buff_list, lvl_5_requirements_list);
        SetLevelsRequirements(lvl_6_buff_list, lvl_6_requirements_list);
        SetLevelsRequirements(lvl_7_buff_list, lvl_7_requirements_list);
        SetLevelsRequirements(lvl_8_buff_list, lvl_8_requirements_list);
        SetLevelsRequirements(lvl_9_buff_list, lvl_9_requirements_list);
        SetLevelsRequirements(lvl_10_buff_list, lvl_10_requirements_list);
        CheckLevelRequirements();
        SetLevelBuff();
    }

    public void ShowLevel()
    {
        int load = 1;
        while (load <= dungeon_lvl)
            switch (load)
            {
                case 1:
                    lvl_1_cover.SetActive(false);
                    load++;
                    break;
                case 2:
                    lvl_2_cover.SetActive(false);
                    load++;
                    break;
                case 3:
                    lvl_3_cover.SetActive(false);
                    load++;
                    break;
                case 4:
                    lvl_4_cover.SetActive(false);
                    load++;
                    break;
                case 5:
                    lvl_5_cover.SetActive(false);
                    load++;
                    break;
                case 6:
                    lvl_6_cover.SetActive(false);
                    load++;
                    break;
                case 7:
                    lvl_7_cover.SetActive(false);
                    load++;
                    break;
                case 8:
                    lvl_8_cover.SetActive(false);
                    load++;
                    break;
                case 9:
                    lvl_9_cover.SetActive(false);
                    load++;
                    break;
                case 10:
                    lvl_10_cover.SetActive(false);
                    load++;
                    break;

            }
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

    public void UpdateMapStatusPlayerCover()
    {
        MapStatus.GetComponent<MapStatus>().player_can_uncover = player_can_uncover;
    }

    public GameObject GetPanel(int i)
    {
        GameObject panel = lvl_panels[i];
        return panel;
    }
    public void Lvl_1_Cover_Trun_Off()
    {
        if (player_can_uncover)
        {
            lvl_1_cover.SetActive(false);
            player_can_uncover = false;
            UpdateMapStatusPlayerCover();
        }
    }
    public void Lvl_2_Cover_Trun_Off()
    {
        if (player_can_uncover)
        {
            lvl_2_cover.SetActive(false);
            player_can_uncover = false;
            UpdateMapStatusPlayerCover();
        }
    }
    public void Lvl_3_Cover_Trun_Off()
    {
        if (player_can_uncover)
        {
            lvl_3_cover.SetActive(false);
            player_can_uncover = false;
            UpdateMapStatusPlayerCover();
        }
    }
    public void Lvl_4_Cover_Trun_Off()
    {
        if (player_can_uncover)
        {
            lvl_4_cover.SetActive(false);
            player_can_uncover = false;
            UpdateMapStatusPlayerCover();
        }
    }
    public void Lvl_5_Cover_Trun_Off()
    {
        if (player_can_uncover)
        {
            lvl_5_cover.SetActive(false);
            player_can_uncover = false;
            UpdateMapStatusPlayerCover();
        }
    }
    public void Lvl_6_Cover_Trun_Off()
    {
        if (player_can_uncover)
        {
            lvl_6_cover.SetActive(false);
            player_can_uncover = false;
            UpdateMapStatusPlayerCover();
        }
    }
    public void Lvl_7_Cover_Trun_Off()
    {
        if (player_can_uncover)
        {
            lvl_7_cover.SetActive(false);
            player_can_uncover = false;
            UpdateMapStatusPlayerCover();
        }
    }
    public void Lvl_8_Cover_Trun_Off()
    {
        if (player_can_uncover)
        {
            lvl_8_cover.SetActive(false);
            player_can_uncover = false;
            UpdateMapStatusPlayerCover();
        }
    }
    public void Lvl_9_Cover_Trun_Off()
    {
        if (player_can_uncover)
        {
            lvl_9_cover.SetActive(false);
            player_can_uncover = false;
            UpdateMapStatusPlayerCover();
        }
    }
    public void Lvl_10_Cover_Trun_Off()
    {
        if (player_can_uncover)
        {
            lvl_10_cover.SetActive(false);
            player_can_uncover = false;
            UpdateMapStatusPlayerCover();
        }
    }

    public void GenerateLevels()
    {
        GenerateTypeOfIcons();
        ShuffleIconsToLevelLists();
        PutIconsToPanels();
        GenerateBuffIcons();
        SetLevelsBuffsAndRequirements();
        UpdateMapStatus();
        DisableForbidenButtons();
    }

    public void PutBuffIconsToPanels()
    {
        int lvl = 1;
        while (lvl != 11)
        {
            switch (lvl)
            {
                case 1:
                    PutBuffIcon(buff_lvl_1_panel, lvl_1_buff_list);
                    break;
                case 2:
                    PutBuffIcon(buff_lvl_2_panel, lvl_2_buff_list);
                    break;
                case 3:
                    PutBuffIcon(buff_lvl_3_panel, lvl_3_buff_list);
                    break;
                case 4:
                    PutBuffIcon(buff_lvl_4_panel, lvl_4_buff_list);
                    break;
                case 5:
                    PutBuffIcon(buff_lvl_5_panel, lvl_5_buff_list);
                    break;
                case 6:
                    PutBuffIcon(buff_lvl_6_panel, lvl_6_buff_list);
                    break;
                case 7:
                    PutBuffIcon(buff_lvl_7_panel, lvl_7_buff_list);
                    break;
                case 8:
                    PutBuffIcon(buff_lvl_8_panel, lvl_8_buff_list);
                    break;
                case 9:
                    PutBuffIcon(buff_lvl_9_panel, lvl_9_buff_list);
                    break;
                case 10:
                    PutBuffIcon(buff_lvl_10_panel, lvl_10_buff_list);
                    break;
            }
            lvl++;
        }
    }

    public void GenerateBuffIcons()
    {
        int lvl = 1;
        while (lvl != 11)
        {
            switch (lvl)
            {
                case 1:
                    BuffPanel(buff_lvl_1_panel, lvl_1_list, lvl_1_buff_list);
                    break;
                case 2:
                    BuffPanel(buff_lvl_2_panel, lvl_2_list, lvl_2_buff_list);
                    break;
                case 3:
                    BuffPanel(buff_lvl_3_panel, lvl_3_list, lvl_3_buff_list);
                    break;
                case 4:
                    BuffPanel(buff_lvl_4_panel, lvl_4_list, lvl_4_buff_list);
                    break;
                case 5:
                    BuffPanel(buff_lvl_5_panel, lvl_5_list, lvl_5_buff_list);
                    break;
                case 6:
                    BuffPanel(buff_lvl_6_panel, lvl_6_list, lvl_6_buff_list);
                    break;
                case 7:
                    BuffPanel(buff_lvl_7_panel, lvl_7_list, lvl_7_buff_list);
                    break;
                case 8:
                    BuffPanel(buff_lvl_8_panel, lvl_8_list, lvl_8_buff_list);
                    break;
                case 9:
                    BuffPanel(buff_lvl_9_panel, lvl_9_list, lvl_9_buff_list);
                    break;
                case 10:
                    BuffPanel(buff_lvl_10_panel, lvl_10_list, lvl_10_buff_list);
                    break;
            }
            lvl++;
        }
    }

    public void BuffPanel(GameObject buffPanel, List<string> lvl_list, List<string> lvl_buff_list)
    {
        bool putIcon = true;
        while (putIcon)
        {
            int position = Random.Range(1, 12);
            switch (position)
            {
                case 1:
                    if (lvl_list.Contains("Skull") || lvl_list.Contains("Devil"))
                    {
                        if (Random.Range(1, 11) < 3)
                        {
                            lvl_buff_list.Add("DoubleMonsterDamage");
                            PutBuffIcon(buffPanel, lvl_buff_list);
                            putIcon = false;
                        }
                    }
                    break;
                case 2:
                    if (lvl_list.Contains("Skull") || lvl_list.Contains("Devil"))
                    {
                        if (Random.Range(1, 11) < 3)
                        {
                            lvl_buff_list.Add("DoubleDamage");
                            PutBuffIcon(buffPanel, lvl_buff_list);
                            putIcon = false;
                        }
                    }
                    break;
                case 3:
                    if (lvl_list.Contains("Skull") || lvl_list.Contains("Devil"))
                    {
                        if (Random.Range(1, 11) < 3)
                        {
                            lvl_buff_list.Add("IncreaseMonsterDamage");
                            PutBuffIcon(buffPanel, lvl_buff_list);
                            putIcon = false;
                        }
                    }
                    break;
                case 4:
                    if (lvl_list.Contains("Skull") || lvl_list.Contains("Devil"))
                    {
                        if (Random.Range(1, 11) < 3)
                        {
                            lvl_buff_list.Add("IncreaseDamage");
                            PutBuffIcon(buffPanel, lvl_buff_list);
                            putIcon = false;
                        }
                    }
                    break;
                case 5:
                    if (lvl_list.Contains("Skull") || lvl_list.Contains("Devil"))
                    {
                        if (Random.Range(1, 11) < 3)
                        {
                            lvl_buff_list.Add("IncreaseMonsterMoney");
                            PutBuffIcon(buffPanel, lvl_buff_list);
                            putIcon = false;
                        }
                    }
                    break;
                case 6:
                    if (lvl_list.Contains("Skull") || lvl_list.Contains("Devil") || lvl_list.Contains("Treasure") || lvl_list.Contains("Altar") || lvl_list.Contains("Event"))
                    {
                        if (Random.Range(1, 11) < 3)
                        {
                            lvl_buff_list.Add("IncreaseMoney");
                            PutBuffIcon(buffPanel, lvl_buff_list);
                            putIcon = false;
                        }
                    }
                    break;
                case 7:
                    if (lvl_list.Contains("Treasure") || lvl_list.Contains("Cross"))
                    {
                        if (Random.Range(1, 11) < 3)
                        {
                            lvl_buff_list.Add("GoodChoice");
                            PutBuffIcon(buffPanel, lvl_buff_list);
                            putIcon = false;
                        }
                    }
                    break;
                case 8:
                    if (lvl_list.Contains("Skull") || lvl_list.Contains("Devil") || lvl_list.Contains("Sadness"))
                    {
                        if (Random.Range(1, 11) < 3)
                        {
                            lvl_buff_list.Add("BadChoice");
                            PutBuffIcon(buffPanel, lvl_buff_list);
                            putIcon = false;
                        }
                    }
                    break;
                case 9:
                    if (lvl_list.Contains("Altar") || lvl_list.Contains("Exit") || lvl_list.Contains("Event") || lvl_list.Contains("Messenger"))
                    {
                        if (Random.Range(1, 11) < 3)
                        {
                            lvl_buff_list.Add("NeutralChoice");
                            PutBuffIcon(buffPanel, lvl_buff_list);
                            putIcon = false;
                        }
                    }
                    break;
                case 10:
                    if (lvl_list.Contains("Torch") && lvl_list.Count > 2 || !lvl_list.Contains("Torch") && lvl_list.Count > 1)
                    {
                        if (Random.Range(1, 11) < 3 && !lvl_list.Contains("Exit"))
                        {
                            lvl_buff_list.Add("MoreOptions");
                            PutBuffIcon(buffPanel, lvl_buff_list);
                            putIcon = false;
                        }
                    }
                    break;
                case 11:
                    if (Random.Range(1, 11) < 3)
                    {
                        lvl_buff_list.Add("Nothing");
                        PutBuffIcon(buffPanel, lvl_buff_list);
                        putIcon = false;
                    }
                    break;
            }
        }
    }

    public void PutBuffIcon(GameObject buffPanel, List<string> buffIconName)
    {
        var icon = Instantiate(BuffIconPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        icon.transform.SetParent(buffPanel.transform);
        GetBuffIconSymbol(buffIconName[0], icon);
    }

    public void GetBuffIconSymbol(string buffIconName, GameObject icon)
    {
        switch (buffIconName)
        {
            case "Nothing":
                icon.transform.Find("MoreOptions").gameObject.SetActive(false);
                icon.transform.Find("NeutralChoice").gameObject.SetActive(false);
                icon.transform.Find("BadChoice").gameObject.SetActive(false);
                icon.transform.Find("GoodChoice").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMoney").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMonsterMoney").gameObject.SetActive(false);
                icon.transform.Find("IncreaseDamage").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMonsterDamage").gameObject.SetActive(false);
                icon.transform.Find("DoubleDamage").gameObject.SetActive(false);
                icon.transform.Find("DoubleMonsterDamage").gameObject.SetActive(false);
                break;
            case "MoreOptions":
                icon.transform.Find("NeutralChoice").gameObject.SetActive(false);
                icon.transform.Find("BadChoice").gameObject.SetActive(false);
                icon.transform.Find("GoodChoice").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMoney").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMonsterMoney").gameObject.SetActive(false);
                icon.transform.Find("IncreaseDamage").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMonsterDamage").gameObject.SetActive(false);
                icon.transform.Find("DoubleDamage").gameObject.SetActive(false);
                icon.transform.Find("DoubleMonsterDamage").gameObject.SetActive(false);
                break;
            case "NeutralChoice":
                icon.transform.Find("MoreOptions").gameObject.SetActive(false);
                icon.transform.Find("BadChoice").gameObject.SetActive(false);
                icon.transform.Find("GoodChoice").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMoney").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMonsterMoney").gameObject.SetActive(false);
                icon.transform.Find("IncreaseDamage").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMonsterDamage").gameObject.SetActive(false);
                icon.transform.Find("DoubleDamage").gameObject.SetActive(false);
                icon.transform.Find("DoubleMonsterDamage").gameObject.SetActive(false);
                break;
            case "BadChoice":
                icon.transform.Find("MoreOptions").gameObject.SetActive(false);
                icon.transform.Find("NeutralChoice").gameObject.SetActive(false);
                icon.transform.Find("GoodChoice").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMoney").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMonsterMoney").gameObject.SetActive(false);
                icon.transform.Find("IncreaseDamage").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMonsterDamage").gameObject.SetActive(false);
                icon.transform.Find("DoubleDamage").gameObject.SetActive(false);
                icon.transform.Find("DoubleMonsterDamage").gameObject.SetActive(false);
                break;
            case "GoodChoice":
                icon.transform.Find("MoreOptions").gameObject.SetActive(false);
                icon.transform.Find("NeutralChoice").gameObject.SetActive(false);
                icon.transform.Find("BadChoice").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMoney").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMonsterMoney").gameObject.SetActive(false);
                icon.transform.Find("IncreaseDamage").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMonsterDamage").gameObject.SetActive(false);
                icon.transform.Find("DoubleDamage").gameObject.SetActive(false);
                icon.transform.Find("DoubleMonsterDamage").gameObject.SetActive(false);
                break;
            case "IncreaseMoney":
                icon.transform.Find("MoreOptions").gameObject.SetActive(false);
                icon.transform.Find("NeutralChoice").gameObject.SetActive(false);
                icon.transform.Find("BadChoice").gameObject.SetActive(false);
                icon.transform.Find("GoodChoice").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMonsterMoney").gameObject.SetActive(false);
                icon.transform.Find("IncreaseDamage").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMonsterDamage").gameObject.SetActive(false);
                icon.transform.Find("DoubleDamage").gameObject.SetActive(false);
                icon.transform.Find("DoubleMonsterDamage").gameObject.SetActive(false);
                break;
            case "IncreaseMonsterMoney":
                icon.transform.Find("MoreOptions").gameObject.SetActive(false);
                icon.transform.Find("NeutralChoice").gameObject.SetActive(false);
                icon.transform.Find("BadChoice").gameObject.SetActive(false);
                icon.transform.Find("GoodChoice").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMoney").gameObject.SetActive(false);
                icon.transform.Find("IncreaseDamage").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMonsterDamage").gameObject.SetActive(false);
                icon.transform.Find("DoubleDamage").gameObject.SetActive(false);
                icon.transform.Find("DoubleMonsterDamage").gameObject.SetActive(false);
                break;
            case "IncreaseDamage":
                icon.transform.Find("MoreOptions").gameObject.SetActive(false);
                icon.transform.Find("NeutralChoice").gameObject.SetActive(false);
                icon.transform.Find("BadChoice").gameObject.SetActive(false);
                icon.transform.Find("GoodChoice").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMoney").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMonsterMoney").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMonsterDamage").gameObject.SetActive(false);
                icon.transform.Find("DoubleDamage").gameObject.SetActive(false);
                icon.transform.Find("DoubleMonsterDamage").gameObject.SetActive(false);
                break;
            case "IncreaseMonsterDamage":
                icon.transform.Find("MoreOptions").gameObject.SetActive(false);
                icon.transform.Find("NeutralChoice").gameObject.SetActive(false);
                icon.transform.Find("BadChoice").gameObject.SetActive(false);
                icon.transform.Find("GoodChoice").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMoney").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMonsterMoney").gameObject.SetActive(false);
                icon.transform.Find("IncreaseDamage").gameObject.SetActive(false);
                icon.transform.Find("DoubleDamage").gameObject.SetActive(false);
                icon.transform.Find("DoubleMonsterDamage").gameObject.SetActive(false);
                break;
            case "DoubleDamage":
                icon.transform.Find("MoreOptions").gameObject.SetActive(false);
                icon.transform.Find("NeutralChoice").gameObject.SetActive(false);
                icon.transform.Find("BadChoice").gameObject.SetActive(false);
                icon.transform.Find("GoodChoice").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMoney").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMonsterMoney").gameObject.SetActive(false);
                icon.transform.Find("IncreaseDamage").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMonsterDamage").gameObject.SetActive(false);
                icon.transform.Find("DoubleMonsterDamage").gameObject.SetActive(false);
                break;
            case "DoubleMonsterDamage":
                icon.transform.Find("MoreOptions").gameObject.SetActive(false);
                icon.transform.Find("NeutralChoice").gameObject.SetActive(false);
                icon.transform.Find("BadChoice").gameObject.SetActive(false);
                icon.transform.Find("GoodChoice").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMoney").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMonsterMoney").gameObject.SetActive(false);
                icon.transform.Find("IncreaseDamage").gameObject.SetActive(false);
                icon.transform.Find("IncreaseMonsterDamage").gameObject.SetActive(false);
                icon.transform.Find("DoubleDamage").gameObject.SetActive(false);
                break;
        }
    }

    public void GenerateTypeOfIcons()
    {
        int numberOfIcons, badIcons, goodIcons;
        numberOfIcons = Random.Range(20, 41);
        badIcons = Mathf.RoundToInt(numberOfIcons * 0.6f);
        goodIcons = numberOfIcons - badIcons;
        Debug.Log("Icons = " + numberOfIcons + ", badIcons = " + badIcons + ", goodIcons = " + goodIcons);

        int skullsInt, devilsInt, sadnessInt, altarInt, messengerInt;
        devilsInt = Mathf.RoundToInt(badIcons * 0.1f);
        sadnessInt = Mathf.RoundToInt(badIcons * 0.3f);
        altarInt = Mathf.RoundToInt(badIcons * 0.1f);
        messengerInt = Mathf.RoundToInt(badIcons * 0.1f);
        skullsInt = badIcons - devilsInt - sadnessInt - altarInt - messengerInt;
        AddSkullsToList(skullsInt);
        AddDevilsToList(devilsInt);
        AddSadnessToList(sadnessInt);
        AddAltarsToList(altarInt);
        AddMessengersToList(messengerInt);
        Debug.Log("Skulls = " + skulls.Count + ", Devils = " + devils.Count + ", Sadness = " + sadness.Count + ", Altars = " + altars.Count + ", Messengers = " + messengers.Count);

        int treasureInt, crossInt, exitInt, torchInt, eventInt;
        eventInt = Mathf.RoundToInt(goodIcons * 0.1f);
        crossInt = Mathf.RoundToInt(goodIcons * 0.2f);
        exitInt = Mathf.RoundToInt(goodIcons * 0.1f);
        torchInt = Mathf.RoundToInt(goodIcons * 0.2f);
        treasureInt = goodIcons - crossInt - exitInt - torchInt - eventInt;
        AddTreasureToList(treasureInt);
        AddCrossToList(crossInt);
        AddExitToList(exitInt);
        AddTorchToList(torchInt);
        AddEventToList(eventInt);
        Debug.Log("Treasures = " + treasures.Count + ", Crosses = " + crosses.Count + ", Exits = " + exits.Count + ", Torches = " + torches.Count + ", Events = " + events.Count);
    }

    public void AddSkullsToList(int j)
    {
        if (j > 10) j = 10;
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
    public void AddAltarsToList(int j)
    {
        for (int i = 0; i < j; i++)
        {
            altars.Add("Altar");
        }
    }
    public void AddMessengersToList(int j)
    {
        for (int i = 0; i < j; i++)
        {
            messengers.Add("Messenger");
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

    public void AddEventToList(int j)
    {
        for (int i = 0; i < j; i++)
        {
            events.Add("Event");
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
        PutEvents();
        PutAltars();
        PutMessengers();
        PutSkulls();
    }

    public void UpdateMapGeneration()
    {
        lvl_1_list = MapStatus.GetComponent<MapStatus>().lvl_1_list;
        lvl_2_list = MapStatus.GetComponent<MapStatus>().lvl_2_list;
        lvl_3_list = MapStatus.GetComponent<MapStatus>().lvl_3_list;
        lvl_4_list = MapStatus.GetComponent<MapStatus>().lvl_4_list;
        lvl_5_list = MapStatus.GetComponent<MapStatus>().lvl_5_list;
        lvl_6_list = MapStatus.GetComponent<MapStatus>().lvl_6_list;
        lvl_7_list = MapStatus.GetComponent<MapStatus>().lvl_7_list;
        lvl_8_list = MapStatus.GetComponent<MapStatus>().lvl_8_list;
        lvl_9_list = MapStatus.GetComponent<MapStatus>().lvl_9_list;
        lvl_10_list = MapStatus.GetComponent<MapStatus>().lvl_10_list;

        lvl_1_buff_list = MapStatus.GetComponent<MapStatus>().lvl_1_buff_list;
        lvl_2_buff_list = MapStatus.GetComponent<MapStatus>().lvl_2_buff_list;
        lvl_3_buff_list = MapStatus.GetComponent<MapStatus>().lvl_3_buff_list;
        lvl_4_buff_list = MapStatus.GetComponent<MapStatus>().lvl_4_buff_list;
        lvl_5_buff_list = MapStatus.GetComponent<MapStatus>().lvl_5_buff_list;
        lvl_6_buff_list = MapStatus.GetComponent<MapStatus>().lvl_6_buff_list;
        lvl_7_buff_list = MapStatus.GetComponent<MapStatus>().lvl_7_buff_list;
        lvl_8_buff_list = MapStatus.GetComponent<MapStatus>().lvl_8_buff_list;
        lvl_9_buff_list = MapStatus.GetComponent<MapStatus>().lvl_9_buff_list;
        lvl_10_buff_list = MapStatus.GetComponent<MapStatus>().lvl_10_buff_list;

        lvl_1_requirements_list = MapStatus.GetComponent<MapStatus>().lvl_1_requirements_list;
        lvl_2_requirements_list = MapStatus.GetComponent<MapStatus>().lvl_2_requirements_list;
        lvl_3_requirements_list = MapStatus.GetComponent<MapStatus>().lvl_3_requirements_list;
        lvl_4_requirements_list = MapStatus.GetComponent<MapStatus>().lvl_4_requirements_list;
        lvl_5_requirements_list = MapStatus.GetComponent<MapStatus>().lvl_5_requirements_list;
        lvl_6_requirements_list = MapStatus.GetComponent<MapStatus>().lvl_6_requirements_list;
        lvl_7_requirements_list = MapStatus.GetComponent<MapStatus>().lvl_7_requirements_list;
        lvl_8_requirements_list = MapStatus.GetComponent<MapStatus>().lvl_8_requirements_list;
        lvl_9_requirements_list = MapStatus.GetComponent<MapStatus>().lvl_9_requirements_list;
        lvl_10_requirements_list = MapStatus.GetComponent<MapStatus>().lvl_10_requirements_list;

        dungeon_lvl = MapStatus.GetComponent<MapStatus>().dungeon_lvl;
        player_can_uncover = MapStatus.GetComponent<MapStatus>().player_can_uncover;
        lvl_requirements = MapStatus.GetComponent<MapStatus>().lvl_requirements;
        lvl_progress = MapStatus.GetComponent<MapStatus>().lvl_progress;
        lvl_buff = MapStatus.GetComponent<MapStatus>().lvl_buff;

    }

    public void UpdateMapStatus()
    {
        MapStatus.GetComponent<MapStatus>().lvl_1_list = lvl_1_list;
        MapStatus.GetComponent<MapStatus>().lvl_2_list = lvl_2_list;
        MapStatus.GetComponent<MapStatus>().lvl_3_list = lvl_3_list;
        MapStatus.GetComponent<MapStatus>().lvl_4_list = lvl_4_list;
        MapStatus.GetComponent<MapStatus>().lvl_5_list = lvl_5_list;
        MapStatus.GetComponent<MapStatus>().lvl_6_list = lvl_6_list;
        MapStatus.GetComponent<MapStatus>().lvl_7_list = lvl_7_list;
        MapStatus.GetComponent<MapStatus>().lvl_8_list = lvl_8_list;
        MapStatus.GetComponent<MapStatus>().lvl_9_list = lvl_9_list;
        MapStatus.GetComponent<MapStatus>().lvl_10_list = lvl_10_list;

        MapStatus.GetComponent<MapStatus>().lvl_1_buff_list = lvl_1_buff_list;
        MapStatus.GetComponent<MapStatus>().lvl_2_buff_list = lvl_2_buff_list;
        MapStatus.GetComponent<MapStatus>().lvl_3_buff_list = lvl_3_buff_list;
        MapStatus.GetComponent<MapStatus>().lvl_4_buff_list = lvl_4_buff_list;
        MapStatus.GetComponent<MapStatus>().lvl_5_buff_list = lvl_5_buff_list;
        MapStatus.GetComponent<MapStatus>().lvl_6_buff_list = lvl_6_buff_list;
        MapStatus.GetComponent<MapStatus>().lvl_7_buff_list = lvl_7_buff_list;
        MapStatus.GetComponent<MapStatus>().lvl_8_buff_list = lvl_8_buff_list;
        MapStatus.GetComponent<MapStatus>().lvl_9_buff_list = lvl_9_buff_list;
        MapStatus.GetComponent<MapStatus>().lvl_10_buff_list = lvl_10_buff_list;

        MapStatus.GetComponent<MapStatus>().lvl_1_requirements_list = lvl_1_requirements_list;
        MapStatus.GetComponent<MapStatus>().lvl_2_requirements_list = lvl_2_requirements_list;
        MapStatus.GetComponent<MapStatus>().lvl_3_requirements_list = lvl_3_requirements_list;
        MapStatus.GetComponent<MapStatus>().lvl_4_requirements_list = lvl_4_requirements_list;
        MapStatus.GetComponent<MapStatus>().lvl_5_requirements_list = lvl_5_requirements_list;
        MapStatus.GetComponent<MapStatus>().lvl_6_requirements_list = lvl_6_requirements_list;
        MapStatus.GetComponent<MapStatus>().lvl_7_requirements_list = lvl_7_requirements_list;
        MapStatus.GetComponent<MapStatus>().lvl_8_requirements_list = lvl_8_requirements_list;
        MapStatus.GetComponent<MapStatus>().lvl_9_requirements_list = lvl_9_requirements_list;
        MapStatus.GetComponent<MapStatus>().lvl_10_requirements_list = lvl_10_requirements_list;

        // po akcji
        MapStatus.GetComponent<MapStatus>().dungeon_lvl = dungeon_lvl;
        MapStatus.GetComponent<MapStatus>().player_can_uncover = player_can_uncover;
        MapStatus.GetComponent<MapStatus>().lvl_requirements = lvl_requirements;
        MapStatus.GetComponent<MapStatus>().lvl_progress = lvl_progress;
        MapStatus.GetComponent<MapStatus>().lvl_buff = lvl_buff;
    }

    public void PutSkulls()
    {
        if (lvl_1_list.Count == 4)
        {
            skulls.RemoveAt(skulls.Count - 1);
        }
        if (lvl_2_list.Count == 4)
        {
            skulls.RemoveAt(skulls.Count - 1);
        }
        if (lvl_3_list.Count == 4)
        {
            skulls.RemoveAt(skulls.Count - 1);
        }
        if (lvl_4_list.Count == 4)
        {
            skulls.RemoveAt(skulls.Count - 1);
        }
        if (lvl_5_list.Count == 4)
        {
            skulls.RemoveAt(skulls.Count - 1);
        }
        if (lvl_6_list.Count == 4)
        {
            skulls.RemoveAt(skulls.Count - 1);
        }
        if (lvl_7_list.Count == 4)
        {
            skulls.RemoveAt(skulls.Count - 1);
        }
        if (lvl_8_list.Count == 4)
        {
            skulls.RemoveAt(skulls.Count - 1);
        }
        if (lvl_9_list.Count == 4)
        {
            skulls.RemoveAt(skulls.Count - 1);
        }
        if (lvl_10_list.Count == 4)
        {
            skulls.RemoveAt(skulls.Count - 1);
        }
        Debug.Log(skulls.Count);
        while (skulls.Count > 0)
        {
            if (lvl_1_list.Count == 0 && skulls.Count > 0)
            {
                lvl_1_list.Add("Skull");
                skulls.RemoveAt(skulls.Count - 1);
            }
            if (lvl_2_list.Count == 0 && skulls.Count > 0)
            {
                lvl_2_list.Add("Skull");
                skulls.RemoveAt(skulls.Count - 1);
            }
            if (lvl_3_list.Count == 0 && skulls.Count > 0)
            {
                lvl_3_list.Add("Skull");
                skulls.RemoveAt(skulls.Count - 1);
            }
            if (lvl_4_list.Count == 0 && skulls.Count > 0)
            {
                lvl_4_list.Add("Skull");
                skulls.RemoveAt(skulls.Count - 1);
            }
            if (lvl_5_list.Count == 0 && skulls.Count > 0)
            {
                lvl_5_list.Add("Skull");
                skulls.RemoveAt(skulls.Count - 1);
            }
            if (lvl_6_list.Count == 0 && skulls.Count > 0)
            {
                lvl_6_list.Add("Skull");
                skulls.RemoveAt(skulls.Count - 1);
            }
            if (lvl_7_list.Count == 0 && skulls.Count > 0)
            {
                lvl_7_list.Add("Skull");
                skulls.RemoveAt(skulls.Count - 1);
            }
            if (lvl_8_list.Count == 0 && skulls.Count > 0)
            {
                lvl_8_list.Add("Skull");
                skulls.RemoveAt(skulls.Count - 1);
            }
            if (lvl_9_list.Count == 0 && skulls.Count > 0)
            {
                lvl_9_list.Add("Skull");
                skulls.RemoveAt(skulls.Count - 1);
            }

            int position = Random.Range(1, 11);
            if (skulls.Count > 0)
                switch (position)
                {
                    case 1:
                        if (!lvl_1_list.Contains("Skull") && lvl_1_list.Count < 4)
                        {
                            lvl_1_list.Add("Skull");
                            skulls.RemoveAt(skulls.Count - 1);
                        }
                        break;
                    case 2:
                        if (!lvl_2_list.Contains("Skull") && lvl_2_list.Count < 4)
                        {
                            lvl_2_list.Add("Skull");
                            skulls.RemoveAt(skulls.Count - 1);
                        }
                        break;
                    case 3:
                        if (!lvl_3_list.Contains("Skull") && lvl_3_list.Count < 4)
                        {
                            lvl_3_list.Add("Skull");
                            skulls.RemoveAt(skulls.Count - 1);
                        }
                        break;
                    case 4:
                        if (!lvl_4_list.Contains("Skull") && lvl_4_list.Count < 4)
                        {
                            lvl_4_list.Add("Skull");
                            skulls.RemoveAt(skulls.Count - 1);
                        }
                        break;
                    case 5:
                        if (!lvl_5_list.Contains("Skull") && lvl_5_list.Count < 4)
                        {
                            lvl_5_list.Add("Skull");
                            skulls.RemoveAt(skulls.Count - 1);
                        }
                        break;
                    case 6:
                        if (!lvl_6_list.Contains("Skull") && lvl_6_list.Count < 4)
                        {
                            lvl_6_list.Add("Skull");
                            skulls.RemoveAt(skulls.Count - 1);
                        }
                        break;
                    case 7:
                        if (!lvl_7_list.Contains("Skull") && lvl_7_list.Count < 4)
                        {
                            lvl_7_list.Add("Skull");
                            skulls.RemoveAt(skulls.Count - 1);
                        }
                        break;
                    case 8:
                        if (!lvl_8_list.Contains("Skull") && lvl_8_list.Count < 4)
                        {
                            lvl_8_list.Add("Skull");
                            skulls.RemoveAt(skulls.Count - 1);
                        }
                        break;
                    case 9:
                        if (!lvl_9_list.Contains("Skull") && lvl_9_list.Count < 4)
                        {
                            lvl_9_list.Add("Skull");
                            skulls.RemoveAt(skulls.Count - 1);
                        }
                        break;
                    case 10:
                        if (!lvl_10_list.Contains("Skull") && lvl_10_list.Count < 4)
                        {
                            lvl_10_list.Add("Skull");
                            skulls.RemoveAt(skulls.Count - 1);
                        }
                        break;

                }

        }
    }

    public void PutMessengers()
    {
        while (messengers.Count > 0)
        {
            int position = Random.Range(1, 10);
            switch (position)
            {
                case 1:
                    if (!lvl_1_list.Contains("Messenger") && lvl_1_list.Count < 4)
                    {
                        lvl_1_list.Add("Messenger");
                        messengers.RemoveAt(messengers.Count - 1);
                    }
                    break;
                case 2:
                    if (!lvl_2_list.Contains("Messenger") && lvl_2_list.Count < 4)
                    {
                        lvl_2_list.Add("Messenger");
                        messengers.RemoveAt(messengers.Count - 1);
                    }
                    break;
                case 3:
                    if (!lvl_3_list.Contains("Messenger") && lvl_3_list.Count < 4)
                    {
                        lvl_3_list.Add("Messenger");
                        messengers.RemoveAt(messengers.Count - 1);
                    }
                    break;
                case 4:
                    if (!lvl_4_list.Contains("Messenger") && lvl_4_list.Count < 4)
                    {
                        lvl_4_list.Add("Messenger");
                        messengers.RemoveAt(messengers.Count - 1);
                    }
                    break;
                case 5:
                    if (!lvl_5_list.Contains("Messenger") && lvl_5_list.Count < 4)
                    {
                        lvl_5_list.Add("Messenger");
                        messengers.RemoveAt(messengers.Count - 1);
                    }
                    break;
                case 6:
                    if (!lvl_6_list.Contains("Messenger") && lvl_6_list.Count < 4)
                    {
                        lvl_6_list.Add("Messenger");
                        messengers.RemoveAt(messengers.Count - 1);
                    }
                    break;
                case 7:
                    if (!lvl_7_list.Contains("Messenger") && lvl_7_list.Count < 4)
                    {
                        lvl_7_list.Add("Messenger");
                        messengers.RemoveAt(messengers.Count - 1);
                    }
                    break;
                case 8:
                    if (!lvl_8_list.Contains("Messenger") && lvl_8_list.Count < 4)
                    {
                        lvl_8_list.Add("Messenger");
                        messengers.RemoveAt(messengers.Count - 1);
                    }
                    break;
                case 9:
                    if (!lvl_9_list.Contains("Messenger") && lvl_9_list.Count < 4)
                    {
                        lvl_9_list.Add("Messenger");
                        messengers.RemoveAt(messengers.Count - 1);
                    }
                    break;
            }
        }
    }

    public void PutAltars()
    {
        while (altars.Count > 0)
        {
            int position = Random.Range(1, 11);
            switch (position)
            {
                case 1:
                    if (!lvl_1_list.Contains("Altar") && lvl_1_list.Count < 4)
                    {
                        lvl_1_list.Add("Altar");
                        altars.RemoveAt(altars.Count - 1);
                    }
                    break;
                case 2:
                    if (!lvl_2_list.Contains("Altar") && lvl_2_list.Count < 4)
                    {
                        lvl_2_list.Add("Altar");
                        altars.RemoveAt(altars.Count - 1);
                    }
                    break;
                case 3:
                    if (!lvl_3_list.Contains("Altar") && lvl_3_list.Count < 4)
                    {
                        lvl_3_list.Add("Altar");
                        altars.RemoveAt(altars.Count - 1);
                    }
                    break;
                case 4:
                    if (!lvl_4_list.Contains("Altar") && lvl_4_list.Count < 4)
                    {
                        lvl_4_list.Add("Altar");
                        altars.RemoveAt(altars.Count - 1);
                    }
                    break;
                case 5:
                    if (!lvl_5_list.Contains("Altar") && lvl_5_list.Count < 4)
                    {
                        lvl_5_list.Add("Altar");
                        altars.RemoveAt(altars.Count - 1);
                    }
                    break;
                case 6:
                    if (!lvl_6_list.Contains("Altar") && lvl_6_list.Count < 4)
                    {
                        lvl_6_list.Add("Altar");
                        altars.RemoveAt(altars.Count - 1);
                    }
                    break;
                case 7:
                    if (!lvl_7_list.Contains("Altar") && lvl_7_list.Count < 4)
                    {
                        lvl_7_list.Add("Altar");
                        altars.RemoveAt(altars.Count - 1);
                    }
                    break;
                case 8:
                    if (!lvl_8_list.Contains("Altar") && lvl_8_list.Count < 4)
                    {
                        lvl_8_list.Add("Altar");
                        altars.RemoveAt(altars.Count - 1);
                    }
                    break;
                case 9:
                    if (!lvl_9_list.Contains("Altar") && lvl_9_list.Count < 4)
                    {
                        lvl_9_list.Add("Altar");
                        altars.RemoveAt(altars.Count - 1);
                    }
                    break;
                case 10:
                    if (!lvl_10_list.Contains("Altar") && lvl_10_list.Count < 4)
                    {
                        lvl_10_list.Add("Altar");
                        altars.RemoveAt(altars.Count - 1);
                    }
                    break;
            }
        }
    }

    public void PutEvents()
    {
        while (events.Count > 0)
        {
            int position = Random.Range(1, 11);
            switch (position)
            {
                case 1:
                    if (!lvl_1_list.Contains("Event") && lvl_1_list.Contains("Sadness") && lvl_1_list.Count < 4 && Random.Range(1, 11) < 4 || !lvl_1_list.Contains("Event") && lvl_1_list.Contains("Treasure") && lvl_1_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_1_list.Add("Event");
                        events.RemoveAt(events.Count - 1);
                    }
                    else if (!lvl_1_list.Contains("Event") && lvl_1_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_1_list.Add("Event");
                        events.RemoveAt(events.Count - 1);
                    }
                    break;
                case 2:
                    if (!lvl_2_list.Contains("Event") && lvl_2_list.Contains("Sadness") && lvl_2_list.Count < 4 && Random.Range(1, 11) < 4 || !lvl_2_list.Contains("Event") && lvl_2_list.Contains("Treasure") && lvl_2_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_2_list.Add("Event");
                        events.RemoveAt(events.Count - 1);
                    }
                    else if (!lvl_2_list.Contains("Event") && lvl_2_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_2_list.Add("Event");
                        events.RemoveAt(events.Count - 1);
                    }
                    break;
                case 3:
                    if (!lvl_3_list.Contains("Event") && lvl_3_list.Contains("Sadness") && lvl_3_list.Count < 4 && Random.Range(1, 11) < 4 || !lvl_3_list.Contains("Event") && lvl_3_list.Contains("Treasure") && lvl_3_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_3_list.Add("Event");
                        events.RemoveAt(events.Count - 1);
                    }
                    else if (!lvl_3_list.Contains("Event") && lvl_3_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_3_list.Add("Event");
                        events.RemoveAt(events.Count - 1);
                    }
                    break;
                case 4:
                    if (!lvl_4_list.Contains("Event") && lvl_4_list.Contains("Sadness") && lvl_4_list.Count < 4 && Random.Range(1, 11) < 4 || !lvl_4_list.Contains("Event") && lvl_4_list.Contains("Treasure") && lvl_4_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_4_list.Add("Event");
                        events.RemoveAt(events.Count - 1);
                    }
                    else if (!lvl_4_list.Contains("Event") && lvl_4_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_4_list.Add("Event");
                        events.RemoveAt(events.Count - 1);
                    }
                    break;
                case 5:
                    if (!lvl_5_list.Contains("Event") && lvl_5_list.Contains("Sadness") && lvl_5_list.Count < 4 && Random.Range(1, 11) < 4 || !lvl_5_list.Contains("Event") && lvl_5_list.Contains("Treasure") && lvl_5_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_5_list.Add("Event");
                        events.RemoveAt(events.Count - 1);
                    }
                    else if (!lvl_5_list.Contains("Event") && lvl_5_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_5_list.Add("Event");
                        events.RemoveAt(events.Count - 1);
                    }
                    break;
                case 6:
                    if (!lvl_6_list.Contains("Event") && lvl_6_list.Contains("Sadness") && lvl_6_list.Count < 4 && Random.Range(1, 11) < 4 || !lvl_6_list.Contains("Event") && lvl_6_list.Contains("Treasure") && lvl_6_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_6_list.Add("Event");
                        events.RemoveAt(events.Count - 1);
                    }
                    else if (!lvl_6_list.Contains("Event") && lvl_6_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_6_list.Add("Event");
                        events.RemoveAt(events.Count - 1);
                    }
                    break;
                case 7:
                    if (!lvl_7_list.Contains("Event") && lvl_7_list.Contains("Sadness") && lvl_7_list.Count < 4 && Random.Range(1, 11) < 4 || !lvl_7_list.Contains("Event") && lvl_7_list.Contains("treasure") && lvl_7_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_7_list.Add("Event");
                        events.RemoveAt(events.Count - 1);
                    }
                    else if (!lvl_7_list.Contains("Event") && lvl_7_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_7_list.Add("Event");
                        events.RemoveAt(events.Count - 1);
                    }
                    break;
                case 8:
                    if (!lvl_8_list.Contains("Event") && lvl_8_list.Contains("Sadness") && lvl_8_list.Count < 4 && Random.Range(1, 11) < 4 || !lvl_8_list.Contains("Event") && lvl_8_list.Contains("Treasure") && lvl_8_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_8_list.Add("Event");
                        events.RemoveAt(events.Count - 1);
                    }
                    else if (!lvl_8_list.Contains("Event") && lvl_8_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_8_list.Add("Event");
                        events.RemoveAt(events.Count - 1);
                    }
                    break;
                case 9:
                    if (!lvl_9_list.Contains("Event") && lvl_9_list.Contains("Sadness") && lvl_9_list.Count < 4 && Random.Range(1, 11) < 4 || !lvl_9_list.Contains("Event") && lvl_9_list.Contains("Treasure") && lvl_9_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_9_list.Add("Event");
                        events.RemoveAt(events.Count - 1);
                    }
                    else if (!lvl_9_list.Contains("Event") && lvl_9_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_9_list.Add("Event");
                        events.RemoveAt(events.Count - 1);
                    }
                    break;
                case 10:
                    if (!lvl_10_list.Contains("Event") && lvl_10_list.Contains("Sadness") && lvl_10_list.Count < 4 && Random.Range(1, 11) < 4 || !lvl_10_list.Contains("Event") && lvl_10_list.Contains("Treasure") && lvl_10_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_10_list.Add("Event");
                        events.RemoveAt(events.Count - 1);
                    }
                    else if (!lvl_10_list.Contains("Event") && lvl_10_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_10_list.Add("Event");
                        events.RemoveAt(events.Count - 1);
                    }
                    break;
            }
        }
    }

    public void PutTreasures()
    {
        while (treasures.Count > 0)
        {
            int position = Random.Range(1, 11);
            switch (position)
            {
                case 1:
                    if (!lvl_1_list.Contains("Treasure") && lvl_1_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_1_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    break;
                case 2:
                    if (!lvl_2_list.Contains("Treasure") && lvl_2_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_2_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    else if (!lvl_2_list.Contains("Treasure") && lvl_2_list.Contains("Cross") && lvl_2_list.Count < 4 && Random.Range(1, 11) > 4)
                    {
                        lvl_2_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    break;
                case 3:
                    if (!lvl_3_list.Contains("Treasure") && lvl_3_list.Count < 4 && Random.Range(1, 11) < 4)
                    {
                        lvl_3_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    else if (!lvl_3_list.Contains("Treasure") && lvl_3_list.Contains("Cross") && lvl_3_list.Count < 4 && Random.Range(1, 11) > 4)
                    {
                        lvl_3_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    break;
                case 4:
                    if (!lvl_4_list.Contains("Treasure") && !lvl_4_list.Contains("Devil") && lvl_4_list.Count < 4 && Random.Range(1, 11) > 4)
                    {
                        lvl_4_list.Add("Treasure");
                        treasures.RemoveAt(treasures.Count - 1);
                    }
                    else if (!lvl_4_list.Contains("Treasure") && !lvl_4_list.Contains("Devil") && lvl_4_list.Contains("Cross") && lvl_4_list.Count < 4 && Random.Range(1, 11) > 4)
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
                    else if (!lvl_5_list.Contains("Treasure") && !lvl_5_list.Contains("Devil") && lvl_5_list.Contains("Cross") && lvl_5_list.Count < 4 && Random.Range(1, 11) > 4)
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
                    else if (!lvl_6_list.Contains("Treasure") && !lvl_6_list.Contains("Devil") && lvl_6_list.Contains("Cross") && lvl_6_list.Count < 4 && Random.Range(1, 11) > 4)
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
                    else if (!lvl_7_list.Contains("Treasure") && !lvl_7_list.Contains("Devil") && lvl_7_list.Contains("Cross") && lvl_7_list.Count < 4 && Random.Range(1, 11) > 4)
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
                    else if (!lvl_8_list.Contains("Treasure") && !lvl_8_list.Contains("Devil") && lvl_8_list.Contains("Cross") && lvl_8_list.Count < 4 && Random.Range(1, 11) > 4)
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
                    else if (!lvl_9_list.Contains("Treasure") && !lvl_9_list.Contains("Devil") && lvl_9_list.Contains("Cross") && lvl_9_list.Count < 4 && Random.Range(1, 11) > 4)
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
                    else if (!lvl_10_list.Contains("Treasure") && !lvl_10_list.Contains("Devil") && lvl_10_list.Contains("Cross") && lvl_10_list.Count < 4 && Random.Range(1, 11) > 4)
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
                        else if (!lvl_5_list.Contains("Exit") && lvl_5_list.Contains("Devil") && !lvl_6_list.Contains("Exit") && lvl_5_list.Count < 4 && Random.Range(1, 10) < 4)
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
                        else if (!lvl_5_list.Contains("Exit") && lvl_6_list.Contains("Devil") && !lvl_6_list.Contains("Exit") && !lvl_7_list.Contains("Exit") && lvl_6_list.Count < 4 && Random.Range(1, 10) < 4)
                        {
                            lvl_5_list.Add("Exit");
                            exits.RemoveAt(exits.Count - 1);
                        }
                        break;
                    case 3:
                        if (!lvl_6_list.Contains("Exit") && !lvl_7_list.Contains("Exit") && !lvl_7_list.Contains("Devil") && !lvl_8_list.Contains("Exit") && lvl_7_list.Count < 4)
                        {
                            lvl_7_list.Add("Exit");
                            exits.RemoveAt(exits.Count - 1);
                        }
                        else if (!lvl_6_list.Contains("Exit") && lvl_7_list.Contains("Devil") && !lvl_7_list.Contains("Exit") && !lvl_8_list.Contains("Exit") && lvl_7_list.Count < 4 && Random.Range(1, 10) < 4)
                        {
                            lvl_5_list.Add("Exit");
                            exits.RemoveAt(exits.Count - 1);
                        }
                        break;
                    case 4:
                        if (!lvl_7_list.Contains("Exit") && !lvl_8_list.Contains("Exit") && !lvl_8_list.Contains("Devil") && !lvl_9_list.Contains("Exit") && lvl_8_list.Count < 4)
                        {
                            lvl_8_list.Add("Exit");
                            exits.RemoveAt(exits.Count - 1);
                        }
                        else if (!lvl_7_list.Contains("Exit") && !lvl_8_list.Contains("Exit") && lvl_8_list.Contains("Devil") && !lvl_9_list.Contains("Exit") && lvl_8_list.Count < 4 && lvl_8_list.Count < 4 && Random.Range(1, 10) < 4)
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
            GetIconSymbol(lvl_1_list[i], icon, dungeon_lvl);
        }
        for (int i = 0; i < lvl_2_list.Count; i++)
        {
            var icon = Instantiate(IconPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            icon.transform.SetParent(GetPanel(1).transform);
            GetIconSymbol(lvl_2_list[i], icon, dungeon_lvl + 1);
        }
        for (int i = 0; i < lvl_3_list.Count; i++)
        {
            var icon = Instantiate(IconPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            icon.transform.SetParent(GetPanel(2).transform);
            GetIconSymbol(lvl_3_list[i], icon, dungeon_lvl + 2);
        }
        for (int i = 0; i < lvl_4_list.Count; i++)
        {
            var icon = Instantiate(IconPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            icon.transform.SetParent(GetPanel(3).transform);
            GetIconSymbol(lvl_4_list[i], icon, dungeon_lvl + 3);
        }
        for (int i = 0; i < lvl_5_list.Count; i++)
        {
            var icon = Instantiate(IconPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            icon.transform.SetParent(GetPanel(4).transform);
            GetIconSymbol(lvl_5_list[i], icon, dungeon_lvl + 4);
        }
        for (int i = 0; i < lvl_6_list.Count; i++)
        {
            var icon = Instantiate(IconPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            icon.transform.SetParent(GetPanel(5).transform);
            GetIconSymbol(lvl_6_list[i], icon, dungeon_lvl + 5);
        }
        for (int i = 0; i < lvl_7_list.Count; i++)
        {
            var icon = Instantiate(IconPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            icon.transform.SetParent(GetPanel(6).transform);
            GetIconSymbol(lvl_7_list[i], icon, dungeon_lvl + 6);
        }
        for (int i = 0; i < lvl_8_list.Count; i++)
        {
            var icon = Instantiate(IconPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            icon.transform.SetParent(GetPanel(7).transform);
            GetIconSymbol(lvl_8_list[i], icon, dungeon_lvl + 7);
        }
        for (int i = 0; i < lvl_9_list.Count; i++)
        {
            var icon = Instantiate(IconPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            icon.transform.SetParent(GetPanel(8).transform);
            GetIconSymbol(lvl_9_list[i], icon, dungeon_lvl + 8);
        }
        for (int i = 0; i < lvl_10_list.Count; i++)
        {
            var icon = Instantiate(IconPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            icon.transform.SetParent(GetPanel(9).transform);
            GetIconSymbol(lvl_10_list[i], icon, dungeon_lvl + 9);
        }

    }

    public void GetIconSymbol(string symbol, GameObject icon, int icon_lvl)
    {
        icon.GetComponent<DungeonIcon>().SetIconName(symbol, icon_lvl);
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
                icon.transform.Find("Event").gameObject.SetActive(false);
                icon.transform.Find("Altar").gameObject.SetActive(false);
                icon.transform.Find("Messenger").gameObject.SetActive(false);
                break;
            case "Devil":
                icon.transform.Find("GrayDirt").gameObject.SetActive(false);
                icon.transform.Find("Skull").gameObject.SetActive(false);
                icon.transform.Find("Treasure").gameObject.SetActive(false);
                icon.transform.Find("Cross").gameObject.SetActive(false);
                icon.transform.Find("Torch").gameObject.SetActive(false);
                icon.transform.Find("Exit").gameObject.SetActive(false);
                icon.transform.Find("Sadness").gameObject.SetActive(false);
                icon.transform.Find("Event").gameObject.SetActive(false);
                icon.transform.Find("Altar").gameObject.SetActive(false);
                icon.transform.Find("Messenger").gameObject.SetActive(false);
                break;
            case "Treasure":
                icon.transform.Find("GrayDirt").gameObject.SetActive(false);
                icon.transform.Find("Devil").gameObject.SetActive(false);
                icon.transform.Find("Skull").gameObject.SetActive(false);
                icon.transform.Find("Cross").gameObject.SetActive(false);
                icon.transform.Find("Torch").gameObject.SetActive(false);
                icon.transform.Find("Exit").gameObject.SetActive(false);
                icon.transform.Find("Sadness").gameObject.SetActive(false);
                icon.transform.Find("Event").gameObject.SetActive(false);
                icon.transform.Find("Altar").gameObject.SetActive(false);
                icon.transform.Find("Messenger").gameObject.SetActive(false);
                break;
            case "Cross":
                icon.transform.Find("GrayDirt").gameObject.SetActive(false);
                icon.transform.Find("Devil").gameObject.SetActive(false);
                icon.transform.Find("Treasure").gameObject.SetActive(false);
                icon.transform.Find("Skull").gameObject.SetActive(false);
                icon.transform.Find("Torch").gameObject.SetActive(false);
                icon.transform.Find("Exit").gameObject.SetActive(false);
                icon.transform.Find("Sadness").gameObject.SetActive(false);
                icon.transform.Find("Event").gameObject.SetActive(false);
                icon.transform.Find("Altar").gameObject.SetActive(false);
                icon.transform.Find("Messenger").gameObject.SetActive(false);
                break;
            case "Torch":
                icon.transform.Find("GrayDirt").gameObject.SetActive(false);
                icon.transform.Find("Devil").gameObject.SetActive(false);
                icon.transform.Find("Treasure").gameObject.SetActive(false);
                icon.transform.Find("Cross").gameObject.SetActive(false);
                icon.transform.Find("Skull").gameObject.SetActive(false);
                icon.transform.Find("Exit").gameObject.SetActive(false);
                icon.transform.Find("Sadness").gameObject.SetActive(false);
                icon.transform.Find("Event").gameObject.SetActive(false);
                icon.transform.Find("Altar").gameObject.SetActive(false);
                icon.transform.Find("Messenger").gameObject.SetActive(false);
                break;
            case "Exit":
                icon.transform.Find("GrayDirt").gameObject.SetActive(false);
                icon.transform.Find("Devil").gameObject.SetActive(false);
                icon.transform.Find("Treasure").gameObject.SetActive(false);
                icon.transform.Find("Cross").gameObject.SetActive(false);
                icon.transform.Find("Torch").gameObject.SetActive(false);
                icon.transform.Find("Skull").gameObject.SetActive(false);
                icon.transform.Find("Sadness").gameObject.SetActive(false);
                icon.transform.Find("Event").gameObject.SetActive(false);
                icon.transform.Find("Altar").gameObject.SetActive(false);
                icon.transform.Find("Messenger").gameObject.SetActive(false);
                break;
            case "Sadness":
                icon.transform.Find("GrayDirt").gameObject.SetActive(false);
                icon.transform.Find("Devil").gameObject.SetActive(false);
                icon.transform.Find("Treasure").gameObject.SetActive(false);
                icon.transform.Find("Cross").gameObject.SetActive(false);
                icon.transform.Find("Torch").gameObject.SetActive(false);
                icon.transform.Find("Skull").gameObject.SetActive(false);
                icon.transform.Find("Exit").gameObject.SetActive(false);
                icon.transform.Find("Event").gameObject.SetActive(false);
                icon.transform.Find("Altar").gameObject.SetActive(false);
                icon.transform.Find("Messenger").gameObject.SetActive(false);
                break;
            case "Event":
                icon.transform.Find("GrayDirt").gameObject.SetActive(false);
                icon.transform.Find("Devil").gameObject.SetActive(false);
                icon.transform.Find("Treasure").gameObject.SetActive(false);
                icon.transform.Find("Cross").gameObject.SetActive(false);
                icon.transform.Find("Torch").gameObject.SetActive(false);
                icon.transform.Find("Skull").gameObject.SetActive(false);
                icon.transform.Find("Exit").gameObject.SetActive(false);
                icon.transform.Find("Sadness").gameObject.SetActive(false);
                icon.transform.Find("Altar").gameObject.SetActive(false);
                icon.transform.Find("Messenger").gameObject.SetActive(false);
                break;
            case "Altar":
                icon.transform.Find("GrayDirt").gameObject.SetActive(false);
                icon.transform.Find("Devil").gameObject.SetActive(false);
                icon.transform.Find("Treasure").gameObject.SetActive(false);
                icon.transform.Find("Cross").gameObject.SetActive(false);
                icon.transform.Find("Torch").gameObject.SetActive(false);
                icon.transform.Find("Skull").gameObject.SetActive(false);
                icon.transform.Find("Exit").gameObject.SetActive(false);
                icon.transform.Find("Sadness").gameObject.SetActive(false);
                icon.transform.Find("Event").gameObject.SetActive(false);
                icon.transform.Find("Messenger").gameObject.SetActive(false);
                break;
            case "Messenger":
                icon.transform.Find("GrayDirt").gameObject.SetActive(false);
                icon.transform.Find("Devil").gameObject.SetActive(false);
                icon.transform.Find("Treasure").gameObject.SetActive(false);
                icon.transform.Find("Cross").gameObject.SetActive(false);
                icon.transform.Find("Torch").gameObject.SetActive(false);
                icon.transform.Find("Skull").gameObject.SetActive(false);
                icon.transform.Find("Exit").gameObject.SetActive(false);
                icon.transform.Find("Sadness").gameObject.SetActive(false);
                icon.transform.Find("Altar").gameObject.SetActive(false);
                icon.transform.Find("Event").gameObject.SetActive(false);
                break;
        }
    }
}
