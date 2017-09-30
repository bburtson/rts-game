using UnityEngine;

public interface IUnitPhysics
{
    void Move(Vector3 position);
    void AttackMove();
    void HoldPosition();
    void Patrol();
    void Stop();
}