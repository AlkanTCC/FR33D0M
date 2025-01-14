using UnityEngine;

[CreateAssetMenu(fileName = "NPCObject", menuName = "Scriptable Objects/NPCObject")]
public class NPCObject : ScriptableObject
{
    [Header("Type")]
    public bool enemy;
    public bool civilian;

    [Header("Stats")]
    public float health;
    public float speed;
}