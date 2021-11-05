using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// should be placed on the active loose screw
public class Tighten : MonoBehaviour
{
    public GameObject tightenedScrew;
    TaskManager taskManager;
    // Start is called before the first frame update
    void Start()
    {
        taskManager = GameObject.Find("EventSystem").GetComponent<TaskManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "screwdriver_head")
        {
            tightenedScrew.SetActive(true);
            this.gameObject.SetActive(false);

            taskManager.tightenedScrew++;
            if (taskManager.tightenedScrew == 5)
                taskManager.EndTightenWheelScrewsTask();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
