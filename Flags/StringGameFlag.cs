using UnityEngine;

[CreateAssetMenu(menuName = "Bool Game Flag")]
public class StringGameFlag : GameFlag<string>
{
    public void Set(string value)
    {
        Value = value;
        SendChanged();
    }

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