using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MovementTypes : MonoBehaviour
{
    [SerializeField] private MovementStats currentStats;
    [SerializeField] private MovementStats[] availableMovements;
    private int currentMovementIndex = 0;


    private float displayTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentStats = availableMovements[currentMovementIndex];
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ChangeMovementMode();
        }

        displayTime -= Time.deltaTime;
        print( "Mode: " + currentStats.name);

    }

    private void ChangeMovementMode()
    {
        currentMovementIndex++;

        if (currentMovementIndex >= availableMovements.Length)
        {
            currentMovementIndex = 0;
        }

        currentStats = availableMovements[currentMovementIndex];

        
        displayTime = 2f;

        FindObjectOfType<Movement>().UpdateStats(currentStats);
    }
}

