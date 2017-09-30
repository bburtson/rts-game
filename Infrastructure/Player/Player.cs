using RTS_TEST.Assets.Shared.Enumerations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(InputListener))]
public class Player : MonoBehaviour
{

    public List<Unit> allUnits;
    public IEnumerable<IUnitPhysics> selectedUnits;

    void Start()
    {

        selectedUnits = FindObjectsOfType<GroundUnit>()
                        .Select(u => u as IUnitPhysics);


    }


    //private void OnPositionSet(InputModifierOptions modifier, Vector3 position)
    //{
        
    //    foreach (var unit in selectedUnits)
    //    {
    //        unit.Stop();
    //        unit.Move(position);
    //    }
    //}

}
