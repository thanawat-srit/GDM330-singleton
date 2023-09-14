
using SuperGame;

using UnityEngine;

public class SurviveTime : Achievement
{

    private void CheckProgress(float progress)
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }
        if (data.Progress < data.MaxProgress)
        {
            
            data.Progress = LevelManager.Instance.CurrentLevel * GameManager.Instance.levelEndTimer.duration - progress;
        }
        else if(data.Progress == data.MaxProgress)
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
