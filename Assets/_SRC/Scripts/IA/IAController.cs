using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : MonoBehaviour
{
    [Header("Main Data")]
    [SerializeField] private EnemyScriptable brain;

    [Header("Player Reference")]
    [SerializeField] private Transform playerTransform;

    [Header("Transform Data")]
    [SerializeField] private Transform GFXTranform;

    [Header("Scripts References")]
    private IAStats IAStatsScript;
    private IAMovement IAMovementScript;
    private IACombat IACombatScript;
    private CharactersStatusManager IAStatusScript;
    private DamageHandler IADamageHandlerScript;

    [Header("References Check")]
    [SerializeField] private bool referencesOk;

    public void Init(EnemyScriptable pBrain)
    {
        referencesOk = false;

        IAStatsScript = GetComponent<IAStats>();
        IAMovementScript = GetComponent<IAMovement>();
        IACombatScript = GetComponent<IACombat>();
        IAStatusScript = GetComponent<CharactersStatusManager>();
        IADamageHandlerScript = GetComponent<DamageHandler>();

        brain = pBrain;

        IACombatScript.Init(brain);
        IAMovementScript.Init(brain);
        IAStatusScript.InitStatus(brain.Status);

        InstantiatateGraphics();
        FindPlayerReference();

        IADamageHandlerScript.Init();

        referencesOk = true;
    }

    private void Update()
    {
        if (referencesOk == false) return;
        if (playerTransform == null) return;
        if (IAStatsScript.States == IAStateType.CHASING)
        {
            ChaseBehaviour();
            return;
        }

        if (IAStatsScript.States == IAStateType.ATTACKING)
        {
            AttackBehaviour();
            return;
        }
    }

    void ChaseBehaviour()
    {
        if (playerTransform == null) return;
        if (IAMovementScript == null) return;

        var sucess =  IAMovementScript.Chase(playerTransform);

        if(sucess == false)
            IAStatsScript.ChangeToState(IAStateType.ATTACKING);
    }

    void AttackBehaviour()
    {
        var sucess = IACombatScript.CheckAndAttack(playerTransform);

        if(sucess == false)
            IAStatsScript.ChangeToState(IAStateType.CHASING);
    }

    void InstantiatateGraphics()
    {
        var gfx = Instantiate(brain.GFX, GFXTranform);
        gfx.transform.parent = this.transform;
    }

    void FindPlayerReference()
    {
        var playerReference = GameObject.FindGameObjectWithTag("Player");

        if (playerReference == null) return;
            playerTransform = playerReference.transform;
    }

}
