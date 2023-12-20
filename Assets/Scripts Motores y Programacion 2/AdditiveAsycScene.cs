using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveAsycScene : MonoBehaviour
{

    [SerializeField] int _nextSceneNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Application.backgroundLoadingPriority = ThreadPriority.Low;
            AsyncOperation _asyncOperation = SceneManager.LoadSceneAsync(_nextSceneNumber, LoadSceneMode.Additive);
            this.gameObject.SetActive(false);
        }
    }
}
