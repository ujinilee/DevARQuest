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
        //�Լ��� ����� �Ŀ� �����Ǵ� plane�� material�� �ٲ�
        prefabMeshRenderer.material = redMaterial;

        //�̹� ������ plane�� ���� �ٲٰ� ���� ��
        foreach(var plane in planeManager.trackables) //collection(palneManager.trackable=�÷��� �Ŵ����� �ν��ϰ� �ִ�)�ȿ� �ִ� item(palne)�� �ϳ��� ���� ���� ��
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
