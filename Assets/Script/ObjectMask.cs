using UnityEngine;
using UnityEngine.UI;

public class ObjectMask: Singleton<ObjectMask>
{ 
    [SerializeField] private GameObject mask;

    public void InstantiateMask(Vector3 pos , Vector3 rot , Vector3 scale , Mesh mesh)
    {
        MeshFilter meshFilter =Å@mask.GetComponent<MeshFilter>();
        meshFilter.mesh = mesh;

        mask.transform.localScale = new Vector3(scale.x, scale.y, scale.z);
        
             
        Instantiate(mask, pos, Quaternion.Euler(rot));
    }
}