using UnityEngine;

[CreateAssetMenu(menuName = "GameFlag/Int")]
public class IntGameFlag : GameFlag<int>
{
    public void Modify(int amount)
    {
        Set(Value + amount);
    }

    protected override void SetFromData(string value)
    {
        if(int.TryParse(value, out var intValue))
            Set(intValue);
    }
}