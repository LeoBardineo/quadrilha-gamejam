using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepManager : MonoBehaviour
{
    public LevelLoader levelLoader;

    public void PassarDeDia()
    {
        Debug.Log("zzzzz");
        levelLoader.LoadNextLevel();
    }
}
