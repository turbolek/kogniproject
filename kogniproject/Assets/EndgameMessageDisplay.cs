using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndgameMessageDisplay : MonoBehaviour {

    void Awake()
    {
        gameObject.SetActive(false);
    }

    public void DisplayMessage (string text)
    {
        gameObject.SetActive(true);
        gameObject.GetComponent<Text>().text = text;
    }
}
