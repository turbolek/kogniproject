using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    [SerializeField]

    private Button[] _buttons;
    private int _activeButtonIndex = 0;

    private void Start()
    {
        HighlightButton(_buttons[_activeButtonIndex]);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            DehighlightButton(_buttons[_activeButtonIndex]);
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                _activeButtonIndex--;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                _activeButtonIndex++;
            }
            _activeButtonIndex = Mathf.Clamp(_activeButtonIndex, 0, _buttons.Length - 1);
            HighlightButton(_buttons[_activeButtonIndex]);

            if (Input.GetKeyDown(KeyCode.Return)) {
                _buttons[_activeButtonIndex].onClick.Invoke();
            }
        }

    }

    public void LoadLevel(string levelName)
    {
        LevelManager levelManager = FindObjectOfType<LevelManager>();
        levelManager.LoadScene(levelName);
    }

    private void HighlightButton(Button button)
    {
        Text text = button.GetComponentInChildren<Text>();
        if (text != null) text.fontSize = 40;
    }

    private void DehighlightButton(Button button)
    {
        Text text = button.GetComponentInChildren<Text>();
        if (text != null) text.fontSize = 30;
    }
}
