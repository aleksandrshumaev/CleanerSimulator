using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorPage : Button
{
    [SerializeField] Text _tutorText;
    [SerializeField] GameObject _tutorPanel;

    public Text TutorText { get => _tutorText; set => _tutorText = value; }
    public GameObject TutorPanel { get => _tutorPanel; set => _tutorPanel = value; }

    // Start is called before the first frame update
    public virtual void OnTutorButton()
    {
        
        TutorPanel.SetActive(false);
    }
}
