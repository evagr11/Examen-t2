using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private ParticleSystem damageParticles;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Gradient healthColor;
    public ParticleSystem healthParticles;
    private AtributosJugador playerAttributesScript;
    private HealthEnemy enemyMovement;

    [SerializeField] private AbilityHolder player;
    Score score;
    [SerializeField] GameObject defeatScreen;
    [SerializeField] TMP_Text finalText;

    void Start()
    {
        score = FindObjectOfType<Score>();
        playerAttributesScript = GetComponent<AtributosJugador>();
        playerAttributesScript.health = playerAttributesScript.maxHealth;
        UpdateHealthColor();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }

        if (playerAttributesScript.health > playerAttributesScript.maxHealth)
        {
            playerAttributesScript.health = playerAttributesScript.maxHealth;
        }

        UpdateHealthColor();

        if (playerAttributesScript.health <= 0)
        {
            GameEvents.PlayerDied.Invoke();
            defeatScreen.SetActive(true);

            player.enabled = false;

            finalText.text = $"You got {score.score} points."; 
        }
    }

    private void UpdateHealthColor()
    {
        spriteRenderer.color = healthColor.Evaluate(1f * playerAttributesScript.health / playerAttributesScript.maxHealth);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyMovement = collision.gameObject.GetComponent<HealthEnemy>();
            playerAttributesScript.health -= enemyMovement.attackDamage;
            damageParticles.Play();
        }
    }
} 
