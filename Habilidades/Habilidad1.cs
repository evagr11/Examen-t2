using UnityEngine;
using UnityEngine.UI;

public class Habilidad1 : Director
{
    [SerializeField] private float scaleBase;
    [SerializeField] private Transform projectileSpawnPoint;  
    [SerializeField] private GameObject projectileTemplate;   
    private float currentCooldown = 0f;
    private GameObject gameManager;
    private GameStart gameStartScript;
    private GameObject player;
    private GameObject spawnedBullet;
    private Proyectil bulletBehavior;
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
            player = GameObject.FindGameObjectWithTag("Player");
            spawnedBullet = Instantiate(projectileTemplate, projectileSpawnPoint.position, Quaternion.identity);  
            bulletBehavior = spawnedBullet.GetComponent<Proyectil>();
            playerStats = player.GetComponent<AtributosJugador>();

            Vector3 direction = player.transform.up;  
            bulletBehavior.direction = direction; 

            spawnedBullet.transform.localScale = Vector3.one * (scaleBase * playerStats.strength);

            currentCooldown = cooldown;
            icon.fillAmount = 0;
        }
    }
}
