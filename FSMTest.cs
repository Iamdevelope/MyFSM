using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PJW.FSM;

public class FSMTest : MonoBehaviour {
    public float speed;
    private bool isMove;
    private PJWStateMechine stateMechine;

    private PJWState move;
    private PJWState idle;

    private PJWTransition moveToIdle;
    private PJWTransition idleToMove;

	void Start () {
        
        idle = new PJWState("idle");
        idle.ExitStateHandle += (IState state) =>
        {
            Debug.Log("退出Idle状态了");
        };

        move = new PJWState("move");
        move.OnEnterStateHandle += (IState state) =>
        {
            Debug.Log("进入了Move状态");
        };
        move.UpdateHandle += (float f) =>
        {
            transform.position += transform.forward * f * speed;
        };

        idleToMove = new PJWTransition("idleMove", idle, move);
        idleToMove.TransitionCheckHandle += () =>
        {
            return isMove;
        };
        
        idle.AddTransitions(idleToMove);

        
        moveToIdle = new PJWTransition("moveIdle", move, idle);
        moveToIdle.TransitionCheckHandle += () =>
        {
            return !isMove;
        };
        move.AddTransitions(moveToIdle);

        stateMechine = new PJWStateMechine("state", idle);
        stateMechine.AddState(move);
	}
	
	void Update () {
        stateMechine.UpdateCallBack(Time.deltaTime);
	}
    private void OnGUI()
    {
        if (GUILayout.Button("Move"))
        {
            isMove = true;
        }
        if (GUILayout.Button("Idle"))
        {
            isMove = false; 
        }
    }
}
