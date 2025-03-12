using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float spawnAngle;
    private float elapsedTime = 0;
    [SerializeField] private float spawnInterval = 0.2f;
    [SerializeField] private GameObject enemyTemplate;
    private GameObject gameController;
    private GameStart gameControllerScript;

    private void Start()
    {
    }

    private void Update()
    {
        gameController = GameObject.FindGameObjectWithTag("Start");
        gameControllerScript = gameController.GetComponent<GameStart>();

        if (gameControllerScript.gameStarted)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= spawnInterval)
            {
                GenerateEnemy();
                elapsedTime = 0;
            }
        }
    }

    private void GenerateEnemy()
    {
        spawnAngle = Random.Range(0, 2 * Mathf.PI);
        Vector3 spawnDirection = new Vector3(Mathf.Cos(spawnAngle), Mathf.Sin(spawnAngle), 0);
        Vector3 spawnLocation = spawnDirection * 10.29f;
        Instantiate(enemyTemplate, spawnLocation, Quaternion.identity);
    }
}