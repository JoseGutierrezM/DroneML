using UnityEngine;
using TMPro;

public class UILabel : UIComponent
{
    public TextMeshProUGUI label;

    protected virtual void Awake()
    {
        label = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetLabel(string _label)
    {
        label.text = _label;
    }
}
