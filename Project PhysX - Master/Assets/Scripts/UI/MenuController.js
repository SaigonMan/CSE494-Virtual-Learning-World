#pragma strict
var levelToLoad : String;
var instructions : GameObject;
var instructionsPanel : GameObject;
var titlePanel : GameObject;
var instructionsText : String; //enter in instructions for the player

function Start(){
    instructionsPanel.SetActive(false);
}

function LoadLevel() {
    Application.LoadLevel(levelToLoad);
}
function QuitApp() {
    Application.Quit();
}
function ShowInstructions() {
    instructionsPanel.SetActive(true);
    titlePanel.SetActive(false);
    var myText = instructions.GetComponent.<UI.Text>();
    myText.text = instructionsText;
}
function HideInstructions() {
    instructionsPanel.SetActive(false);
    titlePanel.SetActive(true);
}