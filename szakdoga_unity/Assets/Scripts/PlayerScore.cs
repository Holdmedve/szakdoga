using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    string firstTime = "first_time";
    string failedSafetyInPrevious = "failed_safety_previously";
    string notFirstTime = "not_first_time";

    float installWheelThd = 15f;
    public float installWheelTimeSpent;
    float tightenWheelScrewsThd = 30f;
    public float tightenWheelScrewsTimeSpent;

    string goodTime = "good";
    string poorTime = "poor";
    string unsatisfactoryTime = "unsatisfactory";
    string installWheelGrade;
    string tightenWheelScrewsGrade;

    // Start is called before the first frame update
    void Start()
    {

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
                PlayerPrefs.SetString(userName, notFirstTime);
            Debug.Log("already have:\t" + userName
                + "\tvalue:\t" + PlayerPrefs.GetString(userName));

        }
        else
        {
            PlayerPrefs.SetString(userName, firstTime);
            Debug.Log("write:\t" + userName + "current value:\t" +
                PlayerPrefs.GetString(userName));
        }

        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
