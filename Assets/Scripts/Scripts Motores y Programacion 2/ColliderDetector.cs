using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetector : MonoBehaviour
{
    [SerializeField] GameObject _tutorialUI;

    private void Start()
    {
        _tutorialUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _tutorialUI.SetActive(false);
        }
    }
}
