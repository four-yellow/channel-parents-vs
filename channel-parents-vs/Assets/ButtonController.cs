using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public TMPro.TMP_Text text;

    public void OnSelect(BaseEventData eventData)
    {
        text.color = Color.black;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        text.color = Color.white;
    }
}
