using System.Collections.Generic;
using UnityEngine;

public abstract class UIComponent : MonoBehaviour
{
    public void SetActive(bool _value)
    {
        gameObject.SetActive(_value);
    }
}
