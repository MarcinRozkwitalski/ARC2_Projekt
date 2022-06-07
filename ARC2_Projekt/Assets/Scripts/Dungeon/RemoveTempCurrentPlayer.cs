using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveTempCurrentPlayer : MonoBehaviour
{
    public void DestroyTempCurrentPlayer()
    {
        Destroy(GameObject.Find("DoorHandler"));
    }
}