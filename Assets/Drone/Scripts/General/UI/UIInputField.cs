using TMPro;
using UnityEngine;

public class UIInputField : UIComponent
{
    TextMeshProUGUI label;
    TMP_InputField inputField;

    public virtual void Awake()
    {
        label = GetComponentInChildren<UILabel>().GetComponent<TextMeshProUGUI>();
        inputField = GetComponentInChildren<TMP_InputField>();
    }

    public void SetLabelText(string _text)
    {
        label.text = _text;
    }

    public void SetValue(string _value)
    {
        inputField.SetTextWithoutNotify(_value);
    }

    public string GetValue()
    {
        return inputField.text;
    }
}