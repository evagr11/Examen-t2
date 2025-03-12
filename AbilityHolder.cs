using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public bool habilitiesActive = true;
    [SerializeField] private Director[] availableAbilities;
    public int currentAbilityIndex;

    private void Update()
    {
        if (availableAbilities.Length > 0 && currentAbilityIndex >= 0 && currentAbilityIndex < availableAbilities.Length)
        {
            if (habilitiesActive)
            {
                if (Input.GetMouseButtonDown(0)) 
                {
                    availableAbilities[currentAbilityIndex].Trigger();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) { currentAbilityIndex = 0; }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { currentAbilityIndex = 1; }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { currentAbilityIndex = 2; }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { currentAbilityIndex = 3; }
        if (Input.GetKeyDown(KeyCode.Alpha5)) { currentAbilityIndex = 4; }
        if (Input.GetKeyDown(KeyCode.Alpha6)) { currentAbilityIndex = 5; }


        if (currentAbilityIndex < 0)
        {
            currentAbilityIndex = 0;  
        }
        else if (currentAbilityIndex >= availableAbilities.Length)
        {
            currentAbilityIndex = availableAbilities.Length - 1;  
        }
    }
}
