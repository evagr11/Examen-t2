using UnityEngine;

public class Habilidad6 : Director
{
    private float currentCooldown = 0f;
    private GameStart gameStartScript;
    private AtributosJugador playerStats;
    private GameObject gameStarter;
    private GameObject player;
    [SerializeField] private ParticleSystem strengthBoostEffect;
    [SerializeField] private float strengthFactor = 2;

    private void Start()
    {
        // Asignar referencias en Start
        gameStarter = GameObject.FindGameObjectWithTag("Start");
        player = GameObject.FindGameObjectWithTag("Player");
        playerStats = player.GetComponent<AtributosJugador>();
        gameStartScript = gameStarter.GetComponent<GameStart>();
    }

    private void FixedUpdate()
    {
        // Control del cooldown
        if (gameStartScript.gameStarted && currentCooldown > 0f)
        {
            currentCooldown -= Time.deltaTime;
            icon.fillAmount = 1 - (currentCooldown / cooldown);
        }
    }

    public override void Trigger()
    {
        if (gameStartScript.gameStarted && currentCooldown <= 0)
        {
            strengthBoostEffect.Play();
            playerStats.strength *= strengthFactor;
            Invoke("ResetStrengthBoost", 6f); 

            currentCooldown = cooldown;
            icon.fillAmount = 0;
        }
    }

    private void ResetStrengthBoost()
    {
        playerStats.strength /= strengthFactor;
    }
} 
