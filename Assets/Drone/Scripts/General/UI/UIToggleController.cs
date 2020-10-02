using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public abstract class UIToggleController : MonoBehaviour
{
    Toggle toggle;

    public Toggle Toggle => toggle;
    public bool IsOn => toggle.isOn;
    
    public virtual void Awake()
    {
        toggle = GetComponent<Toggle>();

        if (toggle != null)
        {
            toggle.onValueChanged.AddListener(OnValueChanged);
        }
        else
        {
            Debug.Log("Toggle component is missing! game object: " + gameObject.name);
        }
    }


    public void SetIsOnWithoutNotify(bool _isOn)
    {
        toggle.SetIsOnWithoutNotify(_isOn);
    }

    protected abstract void OnValueChanged(bool _value);
}
