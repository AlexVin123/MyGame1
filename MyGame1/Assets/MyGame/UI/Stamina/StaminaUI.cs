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
        Stamina.ChaigeCount.AddListener(OnChaingeCount);
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
            unit.OnDis();
        }

    }

    private void CreateUnit(int count)
    {
        for (int i = 0; i < count; i++)
        {
            _unitList.Add(Instantiate(unitsPrefab, _conteiner.transform));
        }
    }

    public void OnChaingeCount(int currentCount)
    {
        _currentCount = currentCount;
        if (_currentCount < _count)
            _unitList[_currentCount].OnList();

        if (_currentCount + 1 < _count)
        {
            _unitList[_currentCount + 1].OnDis();
            _unitList[_currentCount + 1].Null();

        }
    }
}
