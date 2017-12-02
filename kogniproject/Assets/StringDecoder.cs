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
                    matchesPossible = true;
                    string replacement_string = ReplaceCharsInMatch(_string, match, pattern);
                    _string = pattern.Replace(_string, replacement_string, 1);

                } else
                {
                    matchesPossible = false;
                }
            }

        }

    }

    private string ReplaceCharsInMatch (string original_string, Match match, Regex pattern)
    {
        string replacement_string = "";
        StringBuilder sb = new StringBuilder(original_string);
        for (int i = 0; i < match.Value.Length; i++)
        {
            char current_string_char = sb[match.Index + i];
            char current_pattern_char = pattern.ToString()[i];
            if (current_string_char == current_pattern_char)
            {
                current_string_char = '@'; //replace current char to disable detecting it as a match again

            }
            replacement_string += current_string_char.ToString();
        }
        return replacement_string;
    }
}
