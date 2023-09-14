using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Linq;

namespace SuperGame
{
    public class FillStatusBar : MonoBehaviour
    {

        private float[] AchievementCurrent = new float[5];
        private float[] AchievementMax = new float[5];
        private string[] AchievementName = new string[5];
        private string[] AchievementDescription = new string[5];
        private float[] AchievementPercent = new float[5];
        private bool[] AchievementComplete = new bool[5];
        public Slider[] sliders = new Slider[5];
        public TextMeshProUGUI[] ShowTxtName = new TextMeshProUGUI[5];
        public TextMeshProUGUI[] ShowTxtDescript = new TextMeshProUGUI[5];
        public TextMeshProUGUI[] ShowTxtPercent = new TextMeshProUGUI[5];
        int Value = 5;
        public GameObject UiFillStatusBarAchievement;

        // void StartProgress()
        // {
        //     for (int i = 0; i < Value; i++)
        //     {
        //         sliders[i] = GameObject.Find(string.Format("Display2Progress ({0})", i + 1)).GetComponent<Slider>();
        //         ShowTxtName[i] = GameObject.Find(string.Format("Text (TMP) ({0})", i + 1)).GetComponent<TextMeshProUGUI>();
        //         // fillImages[i] = GameObject.Find(string.Format("Fill ({0})", i + 1)).GetComponent<Image>();
        //         ShowTxtDescript[i] = GameObject.Find(string.Format("TextDes ({0})", i + 1)).GetComponent<TextMeshProUGUI>();
        //         ShowTxtPercent[i] = GameObject.Find(string.Format("TextPer ({0})", i + 1)).GetComponent<TextMeshProUGUI>();
        //     }
        // }

        // Update is called once per frame
        void Update()
        {
            // GetAll();
            Value = GetIncompleteAchievementCount();
            PauseAndResume();
        }

        public void GetAll()
        {
            int index = 0;
            foreach (AchievementData Achievement in AchievementManager.Instance.AchievementsList)
            {
                if (!Achievement.Is_Complete && index < AchievementName.Length)
                {
                    AchievementName[index] = Achievement.AchievementName;
                    AchievementCurrent[index] = Achievement.Progress;
                    AchievementMax[index] = Achievement.MaxProgress;
                    AchievementDescription[index] = Achievement.AchievementDescription;

                    index++;
                }
                else if (Achievement.Is_Complete)
                {
                    // // If an achievement is completed, reset the values in your arrays at the current index.
                    // AchievementName[index] = Achievement.AchievementName;
                    // AchievementCurrent[index] = Achievement.Progress;
                    // AchievementMax[index] = Achievement.MaxProgress;
                    // AchievementDescription[index] = Achievement.AchievementDescription;

                    Debug.Log($"Achievement {Achievement.AchievementName} is completed and the values have been reset.");
                    AchievementComplete[index] = true;
                    Debug.Log(AchievementComplete[index]);
                    Debug.Log(Value);
                    index++;
                }
                else
                {
                    Debug.LogWarning("Achievement array is too small to hold all achievements!");
                }
            }
        }


        void UpdateUI()
        {
            for (int i = 0; i < 5; i++)
            {
                AchievementData achievementData = AchievementManager.Instance.AchievementsList[i];
                ShowTxtName[i].text = achievementData.AchievementName;
                float AchievementPercent;
                if(achievementData.Is_Complete){
                    AchievementPercent = 100;
                }else{
                    AchievementPercent = achievementData.Progress * 100 / achievementData.MaxProgress;
                }
                ShowTxtPercent[i].text = AchievementPercent.ToString("F2") + "%";
                ShowTxtDescript[i].text = achievementData.AchievementDescription;
                if (sliders[i] != null) { sliders[i].value = AchievementPercent / 100; }

                // if (AchievementComplete[i])
                // {
                //     if (ShowTxtPercent[i] != null) { ShowTxtPercent[i].text = "100.00%"; }
                //     if (sliders[i] != null) { sliders[i].value = 1f; }
                //     // if (fillImages[i] != null) { fillImages[i].fillAmount = 0; }
                // }
                // else
                // {
                //     // Otherwise, show the current progress towards the achievement
                //     float fillValue = AchievementCurrent[i] / AchievementMax[i];
                //     AchievementPercent[i] = fillValue * 100; // Calculate the percentage and store it in the array

                //     if (sliders[i] != null) { sliders[i].value = fillValue; }
                //     // if (fillImages[i] != null) { fillImages[i].fillAmount = fillValue; }
                //     if (ShowTxtName[i] != null) { ShowTxtName[i].text = AchievementName[i]; }
                //     if (ShowTxtDescript[i] != null) { ShowTxtDescript[i].text = AchievementDescription[i]; }
                //     if (ShowTxtPercent[i] != null) { ShowTxtPercent[i].text = $"{AchievementPercent[i]:0.00}%"; } // Display the percentage in the UI
                // }
            }
        }




        private bool isPaused = false;
        public void PauseAndResume()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    UiFillStatusBarAchievement.SetActive(true);
                    UpdateUI();
                    // StartProgress();
                    GameManager.Instance.Pause();

                }
                else
                {
                    GameManager.Instance.Resume();
                    UiFillStatusBarAchievement.SetActive(false);
                }
                isPaused = !isPaused;
            }
        }

        int GetIncompleteAchievementCount()
        {
            return AchievementManager.Instance.AchievementsList.Count(a => !a.Is_Complete);
        }
    }
}
