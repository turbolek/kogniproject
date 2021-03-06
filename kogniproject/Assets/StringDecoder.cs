﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Text;

public class StringDecoder : MonoBehaviour {

    public string[] codes;
    public Unit[] units;

    List<Regex> patterns = new List<Regex>();

    public List<Unit> unitsToSpawn = new List<Unit>();
    public List<Match> matches = new List<Match>();

	void Start () {
        foreach (string code in codes)
        {
            patterns.Add(new Regex(code, RegexOptions.IgnoreCase));
        }
	}

	void Update () {
		
	}

    public List<Unit> GetUnitsToSpawn (string _string)
    {
        unitsToSpawn = new List<Unit>();
        matches = new List<Match>();
        bool matchesPossible = true;
        foreach (Regex pattern in patterns)
        {
            matchesPossible = true;
            while (matchesPossible)
            {
                Match match = pattern.Match(_string);
                if (match.Success && IsContinousMatch(match))
                {
                    unitsToSpawn.Add(units[System.Array.IndexOf(codes, pattern.ToString())]);
                    matchesPossible = true;
                    string replacement_string = ReplaceCharsInMatch(_string, match, pattern);
                    _string = pattern.Replace(_string, replacement_string, 1);
                    matches.Add(match);

                } else
                {
                    matchesPossible = false;
                }
            }

        }
        return unitsToSpawn;

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

    private bool IsContinousMatch (Match match)
    {
        int firstIndex = match.Index;
        int lastIndex = match.Index + match.Length - 1;
        bool result = firstIndex % 6 < lastIndex % 6;
        return result;
    }
}
