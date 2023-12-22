using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _ammoText;
    [SerializeField] Gun _ammoGun;

    // Start is called before the first frame update
    void Start()
    {
        _ammoGun.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _ammoText.text = _ammoGun.shoots.ToString();
    }
}
