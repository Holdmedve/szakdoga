using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapIntoPlace : MonoBehaviour
{
    public GameObject destination;
    public Vector3 posOffset = new Vector3(0f, 0f, 0f);
    public Vector3 rotOffset = new Vector3(0f, 0f, 0f);

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
        Transform t = this.gameObject.transform;
        t.position = destination.transform.position;
        t.rotation = destination.transform.rotation;

        if (destinationTag == Params.PlaceHolderTag)
        {
            Destroy(this.GetComponent<Rigidbody>());
            Destroy(this.GetComponent<OVRGrabbable>());
            Destroy(destination);
        }
        else if (destinationTag == Params.HandTag)
        {
            Destroy(this.GetComponent<Rigidbody>());
            t.SetParent(destination.transform);
            t.localRotation = Quaternion.Euler(rotOffset.x, rotOffset.y, rotOffset.z);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Params.PlaceHolderTag || other.tag == Params.HandTag)
            Snap(other.tag);
    }
}
