using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ChangeMaterial : MonoBehaviour
{

    public ARPlaneManager planeManager;

    public MeshRenderer prefabMeshRenderer;

    public Material redMaterial;

    public Material blueMaterial;

    void Start()
    {
        
    }

    public void OnChangeRed()
    {
        //함수가 실행된 후에 감지되는 plane의 material을 바꿈
        prefabMeshRenderer.material = redMaterial;

        //이미 인지된 plane의 색을 바꾸고 싶을 때
        foreach(var plane in planeManager.trackables) //collection(palneManager.trackable=플레인 매니저가 인식하고 있는)안에 있는 item(palne)을 하나씩 빼서 갖다 씀
        {
            plane.GetComponent<MeshRenderer>().material = redMaterial;
        }
    } 


    public void OnChangeBlue()
    {
        prefabMeshRenderer.material = blueMaterial;
        foreach (var plane in planeManager.trackables)
        {
            plane.GetComponent<MeshRenderer>().material = blueMaterial;
        }
    }

}
