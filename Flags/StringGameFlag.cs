using UnityEngine;

[CreateAssetMenu(menuName = "GameFlag/String")]
public class StringGameFlag : GameFlag<string>
{
    public void Append(string value)
    {
        Value += " " + value;
        SendChanged();
    }

    public void Preppend(string value)
    {
        Value = $"{value} {Value}";
        SendChanged();
    }
}