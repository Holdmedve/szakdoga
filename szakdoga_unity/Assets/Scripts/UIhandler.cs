using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIhandler : MonoBehaviour
{
    public InputField inputField;
    public Text taskText;
    public GameObject taskGo;
    public GameObject SafetyReminderGo;
    public GameObject FirstTimeHintGo;
    public Text FirstTimeHindText;
    PlayerScore playerScore;

    bool isUsernameProcessed;
    // Start is called before the first frame update
    void Start()
    {
        isUsernameProcessed = false;
        playerScore = GetComponent<PlayerScore>();

        // cursor blinks
        inputField.Select();
        inputField.ActivateInputField();
    }



    // Update is called once per frame
    void Update()
    {
        if (!isUsernameProcessed && Input.GetKeyDown(KeyCode.Return))
        {
            isUsernameProcessed = true;
            playerScore.ProcessUserName(inputField.text);
            inputField.gameObject.SetActive(false);
        }

    }
}
