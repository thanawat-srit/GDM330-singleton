using System.Collections;
using System.Collections.Generic;
using SuperGame;
using UnityEngine;

public class TakeDamage : Achievement
{
    private void CheckProgress(float damageTaken)
    {
        data.Progress += damageTaken;
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
        PlayerManager.Instance.OnPlayerTakeDamage += CheckProgress;

    }
    protected override void OnDisable()
    {
        base.OnDisable();
        if(PlayerManager.Instance!=null)
            PlayerManager.Instance.OnPlayerTakeDamage -= CheckProgress;

    }
}
