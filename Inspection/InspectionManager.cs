using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InspectionManager : MonoBehaviour
{
    Inspectable _currentInspectable;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _currentInspectable = Inspectable.InspectablesInRange.FirstOrDefault();
        }

        if (Input.GetKey(KeyCode.E) && _currentInspectable != null)
        {
            _currentInspectable.Inspect();
        }
            
    }
}
