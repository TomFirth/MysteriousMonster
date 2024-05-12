using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "Monster")]
public class Monster : ScriptableObject
{
    public string title;

    public Sprite sprite;

    public int level;

    public int hp;
    public int attack;
    public int defence;
    public int size;
    public int speed;
    public int special;
    public int rarity;
}
