using UnityEngine;
using System.Collections.Generic;

public class CircleProcGen : MonoBehaviour
{
[   SerializeField] float wallMargin = 10f;
    [SerializeField] float baseMargin = 10f;

    public GameObject[] circles;
    List<Vector2> spawnPositions = new List<Vector2>();

    public Vector2 minimum;
    public Vector2 maximum;

    public GameBehavior gb;

    void Update()
    {
        if (gb.gameStarted)
        {
            CircleGeneration();
        }
    }


    void CircleGeneration()
    {
        spawnPositions.Clear();
        Debug.Log(spawnPositions.Count);

        int t = 0;

        while (spawnPositions.Count < 1 && t < 5000)
        
        {
            t++;
            Debug.

            float xPosition = Random.Range(minimum.x + wallMargin, maximum.x - wallMargin);
            float yPosition = Random.Range(minimum.y + wallMargin, maximum.y - wallMargin);

            Vector2 spawned = new Vector2(xPosition, yPosition);

            if (WithinConstraints(spawned))
            {
                spawnPositions.Add(spawned);
            } 
        }

        for (int i = 0; i < spawnPositions.Count; i++)
        {
            Instantiate(circles[i], spawnPositions[i], Quaternion.identity);
            Debug.Log("circle printed");
        } 
    }

    bool WithinConstraints(Vector2 v)
    {
        foreach (Vector2 sp in spawnPositions)
        {
            if (Vector2.Distance(v, sp) < baseMargin)
            {
                return false;
            }
        }
        return true; 
    }
}
