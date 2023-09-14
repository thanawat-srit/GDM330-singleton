using System;
using System.Collections;
using System.Collections.Generic;
using SuperGame;
using UnityEngine;

public class SurviveWithLowLifePoint : Achievement
{
    private float _surviveTime;
    private void CheckProgress(float time)
    {
        GameManager gameManager = GameManager.Instance;
        if (gameManager.lifeCount == 1)
        {
            _surviveTime += Time.deltaTime;
            data.Progress = _surviveTime;
        }
        if (data.Progress == data.MaxProgress)
        {
            data.Is_Complete = true;
            AchievementNotifications.Instance.OnAchievementComplete?.Invoke(data);
        }

    }

    protected override void OnEnable()
    {
        base.OnEnable();

        GameManager.Instance.levelEndTimer.OnTimeChange += CheckProgress;
    }


    protected override void OnDisable()
    {
        base.OnDisable();
        if (GameManager.Instance != null)
        {
            GameManager.Instance.levelEndTimer.OnTimeChange -= CheckProgress;
        }
    }
}
