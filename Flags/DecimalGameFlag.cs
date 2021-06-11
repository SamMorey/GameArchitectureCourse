using UnityEngine;

[CreateAssetMenu(menuName = "GameFlag/Decimal")]
public class DecimalGameFlag : GameFlag<decimal>
{
    protected override void SetFromData(string value)
    { 
        if(decimal.TryParse(value, out var decimalValue))
            Set(decimalValue);
    }
}