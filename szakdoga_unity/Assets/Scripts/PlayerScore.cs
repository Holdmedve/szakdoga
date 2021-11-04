using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public string firstTime = "first_time";
    public string failedSafetyInPrevious = "failed_safety_previously";
    public string notFirstTime = "not_first_time";
    public string playerValue;

    float installWheelThd = 15f;
    public float installWheelTimeSpent;
    float tightenWheelScrewsThd = 30f;
    public float tightenWheelScrewsTimeSpent;

    string goodTime = "good";
    string poorTime = "poor";
    string unsatisfactoryTime = "unsatisfactory";
    string installWheelGrade;
    string tightenWheelScrewsGrade;
    TaskManager taskManager;

    // Start is called before the first frame update
    void Start()
    {
        taskManager = GetComponent<TaskManager>();
    }

    string GradeTime(float thd, float timeSpent)
    {
        float f = timeSpent / thd;
        if (f < thd * (2 / 3))
            return goodTime;
        else if (f <= thd)
            return poorTime;
        else
            return unsatisfactoryTime;
    }


    public void Evaluate()
    {
        installWheelGrade = GradeTime(installWheelThd, installWheelTimeSpent);
        tightenWheelScrewsGrade = GradeTime(tightenWheelScrewsThd, tightenWheelScrewsTimeSpent);
    }


    public void ProcessUserName(string userName)
    {
        if (PlayerPrefs.HasKey(userName))
        {
            if (PlayerPrefs.GetString(userName) == firstTime)
            {
                PlayerPrefs.SetString(userName, notFirstTime);
                playerValue = notFirstTime;
            }

        }
        else
        {
            playerValue = firstTime;
            PlayerPrefs.SetString(userName, firstTime);
        }

        PlayerPrefs.Save();
        taskManager.WaitForCarToStop();

    }

    // Update is called once per frame
    void Update()
    {

    }
}
