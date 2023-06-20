using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaUI : MonoBehaviour
{
    [SerializeField] public StaminaUnit unitsPrefab;
    [SerializeField] private GameObject _conteiner;
    [SerializeField] public int _count;
    private int _currentCount = 0;
    private List<StaminaUnit> _unitList = new List<StaminaUnit>();
    private StaminaUnit _current;

    public void Init(int count)
    {
        if(_count == 0)
        {
        _currentCount = count;
        _count = count;
        CreateUnit(_count);
        }
        else if(_count < count)
        {
            CreateUnit(count - _count);
            _count = count;
            _currentCount = count;
        }

        foreach (StaminaUnit unit in _unitList)
        {
            unit.Full();
        }

        _current = _unitList[_unitList.Count - 1];

    }

    public void OnAddedStaminaPoint(int count)
    {
        Init(count);
    }

    public void OnLoadStaminaPoint(float value, float maxValue)
    {
        _current.Load(value, maxValue);
    }

    public void OnChaingeCount(int currentCount)
    {
        _currentCount = currentCount;

        for(int i = _count; i != currentCount;)
        {
            _unitList[i-1].Null();
            i--;
        }

        if (currentCount != _count)
            _current = _unitList[currentCount]; 
    }

    private void CreateUnit(int count)
    {
        for (int i = 0; i < count; i++) 
            _unitList.Add(Instantiate(unitsPrefab, _conteiner.transform)); 
    }
}
