using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapIntoPlace : MonoBehaviour
{
    public GameObject placeHolder;
    public Collider snapZone;
    // Start is called before the first frame update
    void Start()
    {
        //snapZone = placeHolder.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Snap()
    {
        Destroy(this.GetComponent<OVRGrabbable>());
        Destroy(this.GetComponent<Rigidbody>());
        this.gameObject.transform.position = placeHolder.transform.position;
        this.gameObject.transform.rotation = placeHolder.transform.rotation;

        Destroy(placeHolder);

    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == Params.PlaceHolderTag)
            Snap();
    }
}
