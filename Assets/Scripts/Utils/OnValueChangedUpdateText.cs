using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OnValueChangedUpdateText : MonoBehaviour
{
    [SerializeField] ScriptableData data;
    //TextMeshProUGUI text;
    TMP_Text text;
    [SerializeField] string Prefix = "";
    [SerializeField] string Suffix = "";

    private void OnEnable()
    {
        data.OnValueUpdated.AddListener(UpdateText);
        UpdateText();
    }

    private void OnDisable()
    {
        data.OnValueUpdated.RemoveListener(UpdateText);
    }

    void UpdateText()
    {
        Debug.Log("update level text");
        if(text == null) text = GetComponent<TextMeshProUGUI>();
        text.text = new string(Prefix + data.Value.ToString() + Suffix);
    }
}
