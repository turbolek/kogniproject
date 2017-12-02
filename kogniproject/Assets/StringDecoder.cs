using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Text;

public class StringDecoder : MonoBehaviour {


    Regex[] patterns = new Regex[] {
       new Regex(@"gg......rr", RegexOptions.IgnoreCase),
       new Regex(@"oo......bb", RegexOptions.IgnoreCase)
};
    

	// Use this for initialization
	void Start () {
        CheckStringForMatches("xxgggxxxxxrrrxx");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CheckStringForMatches (string _string)
    {
        bool matchesPossible = true;
        foreach (Regex pattern in patterns)
        {
            while (matchesPossible)
            {
                Match match = pattern.Match(_string);
                if (match.Success)
                {
                    //TODO: change this to true after fixing endless loop
                    matchesPossible = true;
                    Debug.Log("Match found: " + match.Value + " at index : " + match.Index);
                    string replacement_string = "";
                    for (int i = 0; i < match.Value.Length; i++ )
                    {
                        
                        StringBuilder sb = new StringBuilder(_string);
                        if (sb[match.Index + i] == pattern.ToString()[i]) 
                        {
                            sb[match.Index + i] = '@';
                            
                        }
                        replacement_string += sb[match.Index + i].ToString();
                    }
                    _string = pattern.Replace(_string, replacement_string, 1);
                    Debug.Log("Formatted string : " + _string);

                } else
                {
                    matchesPossible = false;
                }
            }

        }

    }
}
