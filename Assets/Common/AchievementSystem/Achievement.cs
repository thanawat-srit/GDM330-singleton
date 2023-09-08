using System.Collections;
using System.Collections.Generic;
using SuperGame;
using UnityEngine;

public class Achievement : MonoBehaviour
{
    public AchievementData data;
    protected virtual void OnEnable()
    {
        data.Progress = 0;
        data.Is_Complete = false;
        AchievementManager.Instance.AchievementsList.Add(data);
    }
    protected virtual void OnDisable()
    {
        data.Progress = 0;
        data.Is_Complete = false;
        AchievementManager.Instance.AchievementsList.Remove(data);
    }
}
