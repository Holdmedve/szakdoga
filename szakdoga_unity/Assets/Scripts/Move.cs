using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float increment = 0.005f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Transform t = this.gameObject.transform;
        t.position = new Vector3(t.position.x, t.position.y, t.position.z - increment);
    }
}
