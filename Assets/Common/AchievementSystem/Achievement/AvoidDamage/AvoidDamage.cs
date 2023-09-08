using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperGame;

public class AvoidDamage : Achievement
{

    private void CheckProgress()
    {
        float currentLifeCount = GameManager.Instance.lifeCount;
        int currentLevel = LevelManager.Instance.CurrentLevel;
        if (currentLifeCount >= 3 && !data.Is_Complete)
        {
            data.Progress = currentLevel;
        }
        if (currentLifeCount == GameManager.Instance.maxLifeCount && currentLevel >= 3)
        {
            data.Is_Complete = true;
            AchievementNotifications.Instance.OnAchievementComplete?.Invoke(data);
            gameObject.SetActive(false);
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
