using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    float timePassed = 0f;
    string installWheelText = "Install the wheel on the car.";
    string tightenScrewsText = "Tighten the screws on the wheel with the screwdriver";
    string firstTimeMovementHint = "You can move around with the left joystick "
        + "and grab objects with the trigger buttons.";

    string waitForCarText = "Wait here until the car stops!";

    PlayerScore playerScore;
    UIhandler uiHandler;

    public void WaitForCarToStop()
    {
        moveCar.move = true;
        if (playerScore.playerValue == playerScore.failedSafetyInPrevious)
        {
            uiHandler.SafetyReminderGo.SetActive(true);
        }
        uiHandler.taskGo.SetActive(true);
        uiHandler.taskText.text = waitForCarText;
    }

    public void StartInstallWheelTask()
    {
        uiHandler.SafetyReminderGo.SetActive(false);

        if (playerScore.playerValue == playerScore.firstTime)
        {
            uiHandler.FirstTimeHintGo.SetActive(true);
            uiHandler.FirstTimeHindText.text = firstTimeMovementHint;
        }

        timePassed = 0f;
        uiHandler.taskGo.SetActive(true);
        uiHandler.taskText.text = installWheelText;
    }

    public void EndInstallWheelTask()
    {
        uiHandler.FirstTimeHintGo.SetActive(false);
        uiHandler.taskGo.SetActive(false);
        playerScore.installWheelTimeSpent = timePassed;
        Debug.Log("Time spend installing wheel:\t" + timePassed);
        StartTightenWheelScrewsTask();
    }

    void StartTightenWheelScrewsTask()
    {
        uiHandler.taskGo.SetActive(true);
        timePassed = 0f;
        uiHandler.taskText.text = tightenScrewsText;
    }

    void EndTightenWheelScrewsTask()
    {
        uiHandler.taskGo.SetActive(false);
        playerScore.tightenWheelScrewsTimeSpent = timePassed;
        uiHandler.ShowResults();
    }

    MoveCar moveCar;
    // Start is called before the first frame update
    void Start()
    {
        moveCar = GameObject.Find("Classic_car_1955_style3").GetComponent<MoveCar>();
        playerScore = GetComponent<PlayerScore>();
        uiHandler = GetComponent<UIhandler>();

    }

    public void RestartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
    }
}
