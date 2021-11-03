using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIhandler : MonoBehaviour
{
    public InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        inputField.Select();
        inputField.ActivateInputField();
    }

    void ProcessUserName()
    {
        string user = inputField.text;
        Debug.Log(user);
        inputField.gameObject.SetActive(false);

        if (PlayerPrefs.HasKey(user))
            Debug.Log("already have it");
        else
        {
            Debug.Log("write it");
            PlayerPrefs.SetString(user, "dummy_value");
        }

        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            ProcessUserName();

    }
}
