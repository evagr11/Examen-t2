using UnityEngine;

public class Habilidad5 : Director
{
    private float currentCooldown = 0f;
    [SerializeField] private ParticleSystem healingParticles;
    [SerializeField] private float healingMultiplier = 0;
    private GameObject gameManager;
    private GameStart gameStartScript;
    private GameObject player;
    private AtributosJugador playerStats;

    private void FixedUpdate()
    {
        if (currentCooldown > 0f)
        {
            currentCooldown -= Time.deltaTime;
            icon.fillAmount = 1 - (currentCooldown / cooldown);
        }
    }

    public override void Trigger()
    {
        gameManager = GameObject.FindGameObjectWithTag("Start");
        gameStartScript = gameManager.GetComponent<GameStart>();

        if (gameStartScript.gameStarted && currentCooldown <= 0f)
        {
            healingParticles.Play();
            player = GameObject.FindGameObjectWithTag("Player");
            playerStats = player.GetComponent<AtributosJugador>();

            playerStats.upgradeHealing *= healingMultiplier;
            Invoke("StopHealingBoost", 10);

            currentCooldown = cooldown;
            icon.fillAmount = 0;
        }
    }

    private void StopHealingBoost()
    {
        playerStats.upgradeHealing /= healingMultiplier;
    }
}
