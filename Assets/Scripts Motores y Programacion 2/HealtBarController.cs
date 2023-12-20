using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBarController : MonoBehaviour
{
    [SerializeField] Player _myPlayer;
    [SerializeField] Image _healtBarIMG;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _healtBarIMG.fillAmount = _myPlayer.currentLife / 10f;
        
    }
}
