using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InspectionManager : MonoBehaviour
{
    static Inspectable _currentInspectable;
    public static bool Inspecting => _currentInspectable != null;
    public static float InspectionProgress => _currentInspectable?.InspectionProgress ?? 0f;

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
