using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class IAStats : MonoBehaviour
{
    public IAStateType States;

    public void ChangeToState(IAStateType state)
    {
        if (States == state) return;

        States = state;
    }

}
