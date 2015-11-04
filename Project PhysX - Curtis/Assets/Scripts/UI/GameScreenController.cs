using UnityEngine;
using System.Collections;

public class GameScreenController : MonoBehaviour {

    public GameObject changePhysicsPanel;
    public GameObject gamePanel;
    public int size;

    void Start(){
        changePhysicsPanel.SetActive(false);
        size = 1;
    }

    public void ChangePhysicsShow() {
        changePhysicsPanel.SetActive(true);
        gamePanel.SetActive(false);
    }

    public void HidePhysics() {
        gamePanel.SetActive(true);
        changePhysicsPanel.SetActive(false);
    }

    public void ChangeSize(int newSize) {
        size = newSize;
    }

}
