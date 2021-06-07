using UnityEngine;

[CreateAssetMenu(menuName = "Double Game Flag")]
public class DecimalGameFlag : GameFlag<decimal>
{
    public void Modify(decimal amount)
    {
        Value += amount;
        SendChanged();
    }
}