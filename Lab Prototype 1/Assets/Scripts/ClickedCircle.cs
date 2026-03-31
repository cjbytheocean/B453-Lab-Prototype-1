using UnityEngine;

public class ClickedCircle : MonoBehaviour
{
    public GameBehavior gb;

    void Awake()
    {
        gb = FindAnyObjectByType<GameBehavior>();
    }
    void OnMouseDown()
    {
        gb.timerRunning = false;
    }
}
