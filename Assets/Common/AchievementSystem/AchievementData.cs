using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Achievement")]
public class AchievementData : ScriptableObject
{
    public string AchievementName;
    public string AchievementDescription;
    public float MaxProgress;
    public float Progress;
    public bool Is_Complete;
}
