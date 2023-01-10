using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Abillities")]
public  abstract class Abillity : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private int _lvl;

    public int Lvl => _lvl;
}
