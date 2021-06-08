using UnityEngine;

[CreateAssetMenu(menuName = "GameFlag/Int")]
public class IntGameFlag : GameFlag<int>
{
    public void Modify(int amount)
    {
        Value += amount;
        SendChanged();
    }
}