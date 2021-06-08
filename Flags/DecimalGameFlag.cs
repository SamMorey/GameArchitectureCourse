using UnityEngine;

[CreateAssetMenu(menuName = "GameFlag/Decimal")]
public class DecimalGameFlag : GameFlag<decimal>
{
    public void Modify(decimal value)
    {
        Value += value;
        SendChanged();
    }
}