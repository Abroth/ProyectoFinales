using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetector : MonoBehaviour
{

    [SerializeField] float viewDistance;
    [SerializeField] Camera fpsCam;

    [SerializeField] GameObject objectText;

    [SerializeField] LayerMask keyMask;

    [SerializeField] IInventoryObject _myInventory;

    // Start is called before the first frame update
    void Start()
    {
        objectText.SetActive(false);
        _myInventory = GetComponent<IInventoryObject>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckObject();
    }

    void CheckObject()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, viewDistance, keyMask))
        {
            objectText.SetActive(true);

            string target = hit.transform.gameObject.name;

            if (Input.GetKeyDown(KeyCode.E))
            {
                _myInventory.AddObjectToInventory(target);
                hit.transform.GetComponent<Key>().DestroyObject();
            }

        }
        else
        {
            objectText.SetActive(false);
        }
    }
}
