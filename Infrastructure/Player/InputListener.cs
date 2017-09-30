using RTS_TEST.Assets.Shared.Enumerations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void PositionSetHandler(InputModifierOptions modifier, Vector3 position);

public class InputListener : MonoBehaviour
{
    public event PositionSetHandler PositionSet;
    public InputModifierOptions currentModifier;

    void Start()
    {
        StartCoroutine("Listen");    
    }

    public IEnumerator Listen()
    {
        while (true)
        {
            if (Input.GetMouseButtonUp(1))
            {
                SetPosition();
            }

            yield return null;
        }
    }


    void SetPosition()
    {
        var pos = transform.position;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            if(PositionSet != null)
            {
                PositionSet(currentModifier, hit.point);
            }
            
        }
    }
}
