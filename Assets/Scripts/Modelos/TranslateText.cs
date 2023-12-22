using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TranslateText : MonoBehaviour
{

    [SerializeField] private string _ID;

    [SerializeField] private LangManager _manager;

    [SerializeField] private TextMeshProUGUI _myText;


    private void Start()
    {
        _manager = FindObjectOfType<LangManager>();
        _manager.OnUpdate += ChangeLang;
        ChangeLang();
    }

    void ChangeLang()
    {
        _myText.text = _manager.GetTranslate(_ID);
    }
}
