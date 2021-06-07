using UnityEngine;

public class GameFlagTriggerIntArea : MonoBehaviour
{
    [SerializeField] private int _amount;
    [SerializeField] private IntGameFlag intGameFlag;

    private void OnTriggerEnter(Collider other) => intGameFlag.Modify(_amount);
}