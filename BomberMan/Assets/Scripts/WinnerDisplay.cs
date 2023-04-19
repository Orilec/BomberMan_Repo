using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WinnerDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private GlobalManager _globalManager;
    private void Update()
    {
        _text.text = _globalManager.players[0].playerName + " a gagné";
    }
}
