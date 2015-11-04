using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextBoxManager : MonoBehaviour {

    public GameObject TopUI;
    public GameObject textBox;
    public TextAsset textFile;

    public string[] lines;
    public Text displayText;

    public int currentLine;
    public int endLine;
    public bool shouldDisplay = true;
	// Use this for initialization
	void Start () {
        TopUI.SetActive(false);
	    if(textFile != null)
        {
            lines = textFile.text.Split('\n');
        }

        if(endLine == 0)
        {
            endLine = lines.Length - 1;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (shouldDisplay)
        {
            displayText.text = lines[currentLine];

            if (Input.GetKeyDown(KeyCode.Space))
            {
                currentLine++;
            }

            if (currentLine > endLine)
            {
                textBox.SetActive(false);
                displayText.text = null;
                shouldDisplay = false;
                TopUI.SetActive(true);
            }
        }
	}
}
