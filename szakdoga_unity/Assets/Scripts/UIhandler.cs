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
        Debug.Log(inputField.text);
        inputField.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            ProcessUserName();

    }
}
