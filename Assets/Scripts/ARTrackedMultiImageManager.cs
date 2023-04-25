using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ARTrackedMultiImageManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] trackedPrefabs;
    private Dictionary<string, GameObject> spawnObjects = new Dictionary<string, GameObject>();
    private ARTrackedImageManager trackedImageManager;

    // Start is called before the first frame update
    void Awake()
    {
        trackedImageManager = GetComponent<ARTrackedImageManager>();

        foreach (GameObject prefab in trackedPrefabs)
        {
            GameObject clone = Instantiate(prefab);
            clone.name = prefab.name;
            clone.SetActive(false);
            spawnObjects.Add(clone.name, clone);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;


    }

    private void OnDisEnable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;


    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs evnetARgs)
    {
        foreach(var trackedImage in evnetARgs.added)
        {
            UpdateImage(trackedImage);
        }

        foreach(var trackedImage in evnetARgs.updated)
        {
            UpdateImage(trackedImage);
        }

        foreach(var trackedImage in evnetARgs.removed)
        {
            spawnObjects[trackedImage.name].SetActive(false);
        }
    }


    private void UpdateImage(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;
        GameObject trackedObject = spawnObjects[name];

        if(trackedImage.trackingState == TrackingState.Tracking)
        {
            trackedObject.transform.position = trackedImage.transform.position;
            trackedObject.transform.rotation = trackedImage.transform.rotation;
            trackedObject.SetActive(true);
        }

        else
        {
            trackedObject.SetActive(false);
        }
    }
}
