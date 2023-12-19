using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public enum Language
{
    eng,
    spa
}
public class LangManager : MonoBehaviour
{
    [SerializeField] private string _webURL;

    Dictionary<Language, Dictionary<string, string>> _languageManger;

    [SerializeField] private Language _currentLang;

    public event Action OnUpdate = delegate { };

    private void Awake()
    {
        StartCoroutine(DownloadCSV(_webURL));
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _currentLang = _currentLang == Language.eng ? Language.spa : Language.eng;

            //if (_currentLang == Language.eng) 
            //    _currentLang = Language.spa;

            //else _currentLang = Language.eng;

            OnUpdate();
        }
    }

    IEnumerator DownloadCSV(string url)
    {
        var www = new UnityWebRequest(url);

        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();

        _languageManger = LanguageSplit.LoadCodexFromString("www", www.downloadHandler.text);

        OnUpdate();
    }

    public void ChangeLanguage()
    {
        _currentLang = _currentLang == Language.eng ? Language.spa : Language.eng;

        OnUpdate();
    }

    public string GetTranslate(string ID)
    {
        //if (!_languageManger[_currentLang].ContainsKey(ID))
        //{
        //    return "Error 404";
        //}

        //return _languageManger[_currentLang][ID];


        //if (_languageManger.ContainsKey(_currentLang) && _languageManger[_currentLang].ContainsKey(ID))
        //{
        //    return _languageManger[_currentLang][ID];
        //}

        //return null;


        if (_languageManger != null && _languageManger.ContainsKey(_currentLang) && _languageManger[_currentLang].ContainsKey(ID))
        {
            return _languageManger[_currentLang][ID];
        }

        return null;
    }
}
