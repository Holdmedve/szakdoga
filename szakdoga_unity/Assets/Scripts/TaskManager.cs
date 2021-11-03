using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    float timePassed = 0f;
    string installWheelText = "Install the wheel on the car.";
    string tightenScrewsText = "Tighten the screws on the car with the screwdriver";


    PlayerScore playerScore;
    UIhandler uiHandler;

    void StartInstallWheelTask()
    {
        timePassed = 0f;
        uiHandler.taskGo.SetActive(true);
        uiHandler.taskText.text = installWheelText;
    }

    void EndInstallWheelTask()
    {
        uiHandler.taskGo.SetActive(false);
        playerScore.installWheelTimeSpent = timePassed;
    }

    void StartTightenWheelScrewsTask()
    {
        uiHandler.taskGo.SetActive(true);
        timePassed = 0f;
        uiHandler.taskText.text = installWheelText;
    }

    void EndTightenWheelScrewsTask()
    {
        uiHandler.taskGo.SetActive(false);
        playerScore.tightenWheelScrewsTimeSpent = timePassed;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerScore = GetComponent<PlayerScore>();
        uiHandler = GetComponent<UIhandler>();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
    }
}
