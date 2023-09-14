using System.Collections;
using System.Collections.Generic;
using SuperGame;
using UnityEngine;

public class ClearLevel : Achievement
{
    private void CheckProgress()
    {
        data.Progress = LevelManager.Instance.CurrentLevel;
        if (data.Progress >= data.MaxProgress)
        {
            data.Is_Complete = true;
            AchievementNotifications.Instance.OnAchievementComplete?.Invoke(data);
            gameObject.SetActive(false);
        }
        else
        {
            data.Is_Complete = false;
        }
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        GameManager.Instance.levelEndTimer.OnDone += CheckProgress;
    }
    protected override void OnDisable()
    {
        base.OnDisable();
        if (GameManager.Instance != null)
        {
            GameManager.Instance.levelEndTimer.OnDone -= CheckProgress;
        }

    }
}
