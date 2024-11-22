using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaycastManager : MonoBehaviour
{
    [SerializeField] private float range = 10.0f;

    public GameObject dialogBox;

    Mesh mesh;

    public TextMeshProUGUI nameTX;
    public TextMeshProUGUI tagTX;
    public TextMeshProUGUI posTX;
    public TextMeshProUGUI rotateTX;
    public TextMeshProUGUI scaleTX;

    void Start()
    {
        dialogBox.SetActive(false);
        nameTX.text = "";
        tagTX.text = "";
        posTX.text = "";
        rotateTX.text = "";
        scaleTX.text = "";
    }

    void Update()
    {
        Raycast();       
    }

    public void Raycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit objectStatus;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out objectStatus, range))
            {
                if (GameObject.Find("MaskCube(Clone)"))
                {
                    MaskDestroy.Instance.Delete();
                }

                GameObject obj = objectStatus.transform.gameObject;

                if (obj.GetComponent<MeshFilter>() != null)
                {
                    MeshFilter meshFilter = obj.GetComponent<MeshFilter>();
                    mesh = meshFilter.sharedMesh;
                }
                else if(obj.transform.childCount != 0)
                {
                    for (int n = 0; n < obj.transform.childCount; n++)
                    {
                        GameObject child = obj.transform.GetChild(n).gameObject;

                        if (child.GetComponent<MeshFilter>() != null)
                        {
                            MeshFilter meshFilter = child.GetComponent<MeshFilter>();
                            mesh = meshFilter.sharedMesh;
                            break;
                        }
                    }
                }
                else
                {
                }

                Vector3 objPos = objectStatus.transform.position;
                Vector3 objRot = objectStatus.transform.rotation.eulerAngles;
                Vector3 objScale = objectStatus.transform.localScale;

                ObjectMask.Instance.InstantiateMask(objPos , objRot , objScale , mesh);

                dialogBox.SetActive(true);
                nameTX.text = objectStatus.collider.name;
                tagTX.text = objectStatus.collider.tag;
                posTX.text = VectorFormat(objPos);
                rotateTX.text = VectorFormat(objRot);
                scaleTX.text = VectorFormat(objScale);
            }
            else
            {
                dialogBox.SetActive(false);

                if (GameObject.Find("MaskCube(Clone)"))
                {
                    MaskDestroy.Instance.Delete();
                }
            }
        }

    }

    public string VectorFormat(Vector3 vector)
    {
        return $"X{vector.x:000.00} Y{vector.y:000.00} Z{vector.z:000.00}";
    }
}
