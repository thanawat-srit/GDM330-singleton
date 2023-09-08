using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PhEngine;
using PhEngine.Core;
using System;
using UnityEngine.UI;
using TMPro;

namespace SuperGame{
    public class AchievementNotifications : Singleton<AchievementNotifications>
    {
        [SerializeField] private GameObject notificationPrefab;
        // [SerializeField] private Image image;
        // [SerializeField] private TextMeshPro _name;
        // [SerializeField] private TextMeshPro _description;
        public Action<AchievementData> OnAchievementComplete;
        private List<AchievementData> achievementsList => AchievementManager.Instance.AchievementsList;
        protected override void InitAfterAwake()
        {
            

        }
        private void PushNotificationsPopup(AchievementData achievement){
            GameObject notification = Instantiate(notificationPrefab, transform);
            notification.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = achievement.AchievementName + " completed!!!";
            notification.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = achievement.AchievementDescription;
            Destroy(notification, 2f);
        }
        private void OnEnable() {
            OnAchievementComplete += PushNotificationsPopup;
        }
        private void OnDisable() {
            OnAchievementComplete -= PushNotificationsPopup;
        }
    }
}

