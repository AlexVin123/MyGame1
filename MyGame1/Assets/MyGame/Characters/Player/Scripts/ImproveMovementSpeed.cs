using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImproveMovementSpeed : MonoBehaviour
{
    [SerializeField] private Player _player;

    private int _currentLvl = 1;
    private int _maxLvl = 3;
    private MovementSpeed[] _allLvl;
    private MovementSpeed _paremeters;

    public void LoadAll()
    {
        _allLvl = Resources.LoadAll<MovementSpeed>("");
        Debug.Log(_allLvl.Length);

    }

    public void Improve()
    {
        LoadAll();
        _paremeters = Search();
        _player.ImproveSpeed(_paremeters.MaxSpeed);
    }

    private MovementSpeed Search()
    {
        foreach (var item in _allLvl)
        {
            if(item.Lvl == ++_currentLvl)
            {
                return item;
            }
            else
            {
                return null;
            }
        }

        return null;
    }
}
