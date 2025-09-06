using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpUi : MonoBehaviour
{
    [SerializeField] GameObject _speedUpIcon;
    [SerializeField] GameObject _cleanSpeedUpIcon;
    [SerializeField] GameObject _revenuUpIcon;
    [SerializeField] GameObject _passIcon;
    [SerializeField] GameObject _megaphoneIcon;
    // Start is called before the first frame update
    public void SwitchSpeedUpIcon(bool flag)
    {
        _speedUpIcon.SetActive(flag);
    }
    public void SwitchCleanSpeedUpIcon(bool flag)
    {
       _cleanSpeedUpIcon.SetActive(flag);
    }
    public void SwitchRevenuUpIcon(bool flag)
    {
        _revenuUpIcon.SetActive(flag);
    }
    public void SwitchPasIcon(bool flag)
    {
       _passIcon.SetActive(flag);
    }
    public void SwitchMegaphoneIcon(bool flag)
    {
        _megaphoneIcon.SetActive(flag);
    }
}
