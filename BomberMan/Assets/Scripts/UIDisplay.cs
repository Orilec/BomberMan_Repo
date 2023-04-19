using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisplay : MonoBehaviour
{
    public void ShowUI(GameObject layer)
    {
        layer.SetActive(true);
    }
    public void HideUI( GameObject layer)
    {
        layer.SetActive(false);
    }
}
