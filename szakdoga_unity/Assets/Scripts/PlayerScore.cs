using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{

    string firstTime = "first_time";
    string failedSafetyInPrevious = "failed_safety_previously";
    string notFirstTime = "not_first_time";

    // Start is called before the first frame update
    void Start()
    {

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
