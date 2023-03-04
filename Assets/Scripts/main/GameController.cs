using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public int targetFrameRate = 0;
    private float updateCount = 0;
    private float fixedUpdateCount = 0;
    void Awake() {
        Application.targetFrameRate = targetFrameRate;
    }
    // Start is called before the first frame update
    void Start() {
        gameObjects = new ArrayList<>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void Pause() {
        Time.timeScale = 0;
    }

    void Resume() {
        Time.timeScale = 1;
    }


    // updates the money amount based on income
    void updateCashBalance() {

    }

    int calculateCashStep(int steps) {
        int delta = 0;
        foreach (GameObject obj in gameObjects) {
            if (obj is AutoCashObject) {
                delta += obj.income;
            }
        }
    }
}
