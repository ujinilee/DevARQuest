using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARCore;
using Unity.Burst;
using Unity.Jobs;
using System;
using Unity.Collections; //NativeArray ������ �����ʿ�

public class ARFaceRegionManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] regionPrefabs;
    private ARFaceManager faceManager;
    private ARSessionOrigin sessionOrigin;


    //private NativeArray<ARCoreFaceRegionData> faceRegions;
    private NativeArray<ARCoreFaceRegionData> faceRegions; //face Regiond �����͸� ���� NativeArray

    
    

    // Start is called before the first frame update
    void Start()
    {
        faceManager = GetComponent<ARFaceManager>();
        sessionOrigin = GetComponent<ARSessionOrigin>();

        for(int i=0; i<regionPrefabs.Length; i++)
        {
            regionPrefabs[i] = Instantiate(regionPrefabs[i], sessionOrigin.trackablesParent);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        ARCoreFaceSubsystem subsystem = (ARCoreFaceSubsystem)faceManager.subsystem;

        foreach (ARFace face in faceManager.trackables)
        {
            subsystem.GetRegionPoses(face.trackableId, Allocator.Persistent, ref faceRegions);//�ش� �󱼿��� �� face region�� ��ġ�� ȸ���� ��� faceRegions NativeArray�� ����

            foreach (ARCoreFaceRegionData faceRegion in faceRegions)
            {
                ARCoreFaceRegion regionType = faceRegion.region;

                regionPrefabs[(int)regionType].transform.localPosition = faceRegion.pose.position;
                regionPrefabs[(int)regionType].transform.localRotation = faceRegion.pose.rotation;
            }
        }
        
    }
}
