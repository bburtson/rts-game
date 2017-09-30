using UnityEngine;
using UnityEngine.AI;

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using RTS_TEST.Assets.Shared.Enumerations;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Unit : MonoBehaviour, IUnitPhysics
{

    protected NavMeshAgent agent { get { return transform.GetComponent<NavMeshAgent>(); } }
    public Vector3 CurrentTarget;
    public Player player;

    void Start()
    {
        player = FindObjectOfType(typeof(Player)) as Player;

        var listener = player.GetComponent<InputListener>();
        print(listener);
    }

    private void OnPositionSet(InputModifierOptions modifier, Vector3 position)
    {
        Move(position);
    }





    private void BeginAgentMove()
    {
         StartCoroutine("MoveRoutine");
    }

    private float velocityStopRange = 0.08f;
    public bool Enroute
    {
        get
        {

            return agent.velocity.x > velocityStopRange ||
                   agent.velocity.x < (0 - velocityStopRange) ||
                   agent.velocity.y > velocityStopRange ||
                   agent.velocity.y < (0 - velocityStopRange);
        }
    }


    private IEnumerator MoveRoutine()
    {
        
        while (Enroute)
        {
            agent.SetDestination(CurrentTarget);
            yield return null;
        }

        Stop();
    }





    public void Move(Vector3 position)
    {
        CurrentTarget = position;
        agent.SetDestination(CurrentTarget);
        agent.Resume();
        
        Invoke("BeginAgentMove", 0.01f);
    }

    public void AttackMove()
    {
        throw new NotImplementedException();
    }

    public void HoldPosition()
    {
        throw new NotImplementedException();
    }

    public void Patrol()
    {
        throw new NotImplementedException();
    }

    public void Stop()
    {
        print("StopCalled!" + gameObject.name);

        agent.Stop();
    }
}
