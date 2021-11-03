using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void ProcessUserName(string userName)
    {
        Debug.Log(userName);

        if (PlayerPrefs.HasKey(userName))
        {
            Debug.Log("already have it");
        }
        else
        {
            Debug.Log("write it");
            PlayerPrefs.SetString(userName, "dummy_value");
        }

        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
