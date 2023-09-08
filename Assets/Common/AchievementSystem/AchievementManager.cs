using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PhEngine;
using PhEngine.Core;
using System;

namespace SuperGame
{
    public class AchievementManager : Singleton<AchievementManager>
    {
        [SerializeField] private List<GameObject> achievementsListGameObject = new List<GameObject>();
        public List<AchievementData> AchievementsList = new List<AchievementData>();


        protected override void InitAfterAwake()
        {
            foreach (GameObject achievement in achievementsListGameObject)
            {
                Instantiate(achievement, transform);
            }
        }
    

    }
    

}

