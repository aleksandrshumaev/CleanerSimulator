using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Localizations : MonoBehaviour
{
    Dictionary<string,string[]> _localiztions = new Dictionary<string, string[]>();
    string _localizationsPath= "/Data/locals.txt";
    // Start is called before the first frame update
    private void Awake()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + _localizationsPath);
        foreach(string line in allLines)
        {
            string[] localizations = line.Split('/');
            List<string> localizationsList=new List<string>();
            for (int i=1;i<localizations.Length;i++)
            {
                localizationsList.Add(localizations[i]);
            }

            _localiztions.Add(localizations[0], localizationsList.ToArray());
        }
    }
    void Start()
    {
        
    }


    public string GetLocalizationFor(string key)
    {
        return _localiztions[key][0];
    }
}
