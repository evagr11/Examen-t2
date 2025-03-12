using UnityEngine;
using UnityEngine.UI;

public class Habilidad2 : Director
{
    private float currentCooldown = 0f;
    [SerializeField] private ParticleSystem healingEffect;
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

        if (gameStartScript.gameStarted && currentCooldown <= 0)
        {
            healingEffect.Play();
            player = GameObject.FindGameObjectWithTag("Player");
            playerStats = player.GetComponent<AtributosJugador>();

            playerStats.health += playerStats.maxHealth;
            Invoke("StopHealingEffect", 1f);

            currentCooldown = cooldown;
            icon.fillAmount = 0;
        }
    }

    private void StopHealingEffect()
    {
        healingEffect.Stop();
    }
}
