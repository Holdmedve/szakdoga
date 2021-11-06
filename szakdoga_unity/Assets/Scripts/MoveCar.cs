using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    bool taskStarted;
    public bool move = false;
    public float increment = 1.0f;
    TaskManager taskManager;
    PlayerScore playerScore;
    // Start is called before the first frame update
    void Start()
    {
        taskManager = GameObject.Find("EventSystem").GetComponent<TaskManager>();
        playerScore = GameObject.Find("EventSystem").GetComponent<PlayerScore>();
        taskStarted = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (!taskStarted)
        {
            Transform t = this.gameObject.transform;
            if (move)
                t.position = new Vector3(t.position.x, t.position.y, t.position.z - increment);


            if (t.position.z < 16)
            {
                taskManager.StartInstallWheelTask();
                taskStarted = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "CustomHandLeft" && taskStarted == false)
        {
            PlayerPrefs.SetString(playerScore.userName, playerScore.failedSafetyInPrevious);
            PlayerPrefs.Save();
            taskManager.RestartScene();
            Debug.Log("hand detected");
        }

    }
}
