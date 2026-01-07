using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "ScriptableObjects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int hp;
    public float speed;
    public int damage;
    public GameObject prefab;
    public LootItem[] lootTable; 
}