using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTextUi : MonoBehaviour
{
    [SerializeField] Text _textToSet;
    // Start is called before the first frame update
    public void SetText(string text)
    {
        _textToSet.text = text;
    }
}
