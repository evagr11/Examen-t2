using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HabilidadTeleport : Director
{
    private float currentCooldown = 0f;
    private GameStart gameStartScript;
    public GameObject player;
    public GameObject particleSystemPrefab;
    private ParticleSystem currentParticleSystem; 

    [SerializeField] private Renderer personajeRenderer;

    private void Start()
    {
        personajeRenderer = player.GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        if (gameStartScript != null && gameStartScript.gameStarted && currentCooldown > 0f)
        {
            currentCooldown -= Time.deltaTime;

            icon.fillAmount = 1 - (currentCooldown / cooldown);
        }
    }

    public override void Trigger()
    {
        gameStartScript = GameObject.FindGameObjectWithTag("Start").GetComponent<GameStart>();

        if (gameStartScript.gameStarted && currentCooldown <= 0)
        {
            Vector3 cursorPosition = GetCursorPosition();
            Teleportar(player, cursorPosition); 

            currentCooldown = cooldown; 
            icon.fillAmount = 0;
            ActivateParticles(personajeRenderer.material.color); 
        }
    }

    void Teleportar(GameObject obj, Vector3 targetPosition)
    {
        obj.transform.position = targetPosition;
    }

    Vector3 GetCursorPosition()
    {
        Vector3 cursorPos = Input.mousePosition;
        cursorPos = Camera.main.ScreenToWorldPoint(cursorPos);
        cursorPos.z = 0;
        return cursorPos;
    }

    void ActivateParticles(Color personajeRenderer)
    {
        if (currentParticleSystem != null)
        {
            Destroy(currentParticleSystem.gameObject); 
        }

        GameObject particleObject = Instantiate(particleSystemPrefab, player.transform.position, Quaternion.identity);
        currentParticleSystem = particleObject.GetComponent<ParticleSystem>();

        var mainModule = currentParticleSystem.main;
        mainModule.startColor = personajeRenderer; 

        currentParticleSystem.Play(); 
    }
}
