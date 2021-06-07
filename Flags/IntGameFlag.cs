using UnityEngine;

[CreateAssetMenu(menuName = "Int Game Flag")]
public class IntGameFlag : GameFlag<int>
{
    public void Modify(int amount)
    {
        Value += amount;
        SendChanged();
    }
}