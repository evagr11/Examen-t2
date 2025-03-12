using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public bool gameStarted = false;
    [SerializeField] public TMP_Text gameStartText;

    [SerializeField] private AbilityHolder player1;
    Score score;
    [SerializeField] GameObject defeatScreen;
    [SerializeField] TMP_Text finalText;

    // Start is called before the first frame update
    void Start()
    {
        gameStarted = false;
        defeatScreen.SetActive(false);

        player1.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameStarted == false)
        {
            gameStartText.text = ("PRESS SPACE TO START");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameEvents.GameStarted.Invoke();

        }
    }

}