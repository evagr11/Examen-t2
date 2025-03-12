using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Event : MonoBehaviour
{
    private GameStart startScript;
    private AtributosJugador playerAttributesScript;
    private GameObject player;
    private GameObject enemy;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        GameObject gameStart = GameObject.FindGameObjectWithTag("Start");

        startScript = gameStart.GetComponent<GameStart>();
        playerAttributesScript = player.GetComponent<AtributosJugador>();

        GameEvents.PlayerDied.AddListener(PlayerDeath);
        GameEvents.GameStarted.AddListener(StartingGame);
    }

    private void PlayerDeath()
    {
        startScript.gameStarted = false;
        startScript.gameStartText.text = "Pulsa R para reiniciar";

    }

    private void StartingGame()
    {
        startScript.gameStarted = true;
        playerAttributesScript.health = playerAttributesScript.maxHealth;
        Destroy(enemy);
        player.transform.position = Vector2.zero;
        startScript.gameStartText.text = "";

    }
}
