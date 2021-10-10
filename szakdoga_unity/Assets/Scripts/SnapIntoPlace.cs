using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapIntoPlace : MonoBehaviour
{
    public GameObject destination;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Snap(string destinationTag)
    {
        this.gameObject.transform.position = destination.transform.position;
        this.gameObject.transform.rotation = destination.transform.rotation;


        if (destinationTag == Params.PlaceHolderTag)
        {
            Destroy(this.GetComponent<Rigidbody>());
            Destroy(this.GetComponent<OVRGrabbable>());
            Destroy(destination);
        }
        else if (destinationTag == Params.HandTag)
        {
            Destroy(this.GetComponent<Rigidbody>());
            this.gameObject.transform.SetParent(destination.transform);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Params.PlaceHolderTag || other.tag == Params.HandTag)
            Snap(other.tag);



    }
}
