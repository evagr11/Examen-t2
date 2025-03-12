using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject gameStart;
    private GameStart startScript;

    void Update()
    {
        gameStart = GameObject.FindGameObjectWithTag("Start");
        startScript = gameStart.GetComponent<GameStart>();

        if (startScript.gameStarted)
        {
            HandleRotation();
        }
    }

    private void HandleRotation()
    {
        Vector3 mousePosition = Input.mousePosition;

        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;

        Vector3 direction = mousePosition - transform.position;

        float angle = Vector3.SignedAngle(Vector3.up, direction, Vector3.forward);

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
