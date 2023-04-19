using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARFaceMaterialSwitcher : MonoBehaviour
{
    [SerializeField]
    private Material[] materials;
    private ARFaceManager faceManaegr;
    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        faceManaegr = GetComponent<ARFaceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            index = (index + 1) % materials.Length;

            foreach(ARFace face in faceManaegr.trackables)
            {
                face.GetComponent<MeshRenderer>().material = materials[index];
            }
        }
        
    }
}
