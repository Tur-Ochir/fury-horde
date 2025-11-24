using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [HideInInspector] public PlayerInputManager playerInput;
    [HideInInspector] public PlayerMovement playerMovement;
    [HideInInspector] public PlayerCombatManager playerCombat;
    
    public Transform camTransform;
    void Awake()
    {
        playerInput = GetComponent<PlayerInputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        playerCombat = GetComponent<PlayerCombatManager>();
        
        camTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
