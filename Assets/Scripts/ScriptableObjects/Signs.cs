using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sign", menuName = "Sign")]
public class Signs : ScriptableObject
{
    public string title;
    public int[] location;
    public string dialog;
}
