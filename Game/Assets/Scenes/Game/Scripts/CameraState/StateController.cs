using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour, ICameraStateSwitch
{
    [SerializeField] Transform startTarget;
    private CameraState currentState;
    [SerializeField] private List<CameraState> allStates;

    private void Start()
    {
        for (int i = 0; i < allStates.Count; i++)
            allStates[i].Init(this);
        currentState = allStates[0];
    }

    private void LateUpdate()
    {
        currentState.Run();
    }

    public void StateSwitch<T>() where T : CameraState
    {
        for (int i = 0; i < allStates.Count; i++)
            if (allStates[i].GetType() == typeof(T))
            {
                currentState = allStates[i];
                break;
            }      
    }

}
