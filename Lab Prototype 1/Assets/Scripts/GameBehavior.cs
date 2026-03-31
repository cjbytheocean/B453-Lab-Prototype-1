using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    public bool gameStarted = false;
    public bool timerRunning = false;
    public bool circleClicked = false;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] GameObject instructionsText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S) && !gameStarted)
        {
            gameStarted = true;
            StartTheGame();
        }
    }

    void StartTheGame()
    {
        instructionsText.SetActive(false);

        
    }
}
