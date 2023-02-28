using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OnValueChangedUpdateText : MonoBehaviour
{
    [SerializeField] ScriptableData data;
    TextMeshProUGUI text;
    [SerializeField] string Prefix = "";
    [SerializeField] string Suffix = "";

    //void Start()
    //{
    //    UpdateText();
    //}

    private void OnEnable()
    {
        data.OnValueUpdated.AddListener(UpdateText);
    }

    private void OnDisable()
    {
        data.OnValueUpdated.RemoveListener(UpdateText);
    }

    void UpdateText()
    {
        if(text == null) text = GetComponent<TextMeshProUGUI>();
        text.text = new string(Prefix + data.Value.ToString() + Suffix);
    }
}
