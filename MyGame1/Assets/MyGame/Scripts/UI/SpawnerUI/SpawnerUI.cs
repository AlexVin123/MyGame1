using UnityEngine;

public class SpawnerUI : MonoBehaviour
{
    [SerializeField] private PointWaveUI _prefab;
    [SerializeField] private GameObject _container;
    [SerializeField] private Bar _pogresWave;

    private PointWaveUI[] _poinst;
    public void Init(Spawner spawner)
    {
        InstatiatePoints(spawner.CountWave);
    }

    private void InstatiatePoints(int count)
    {
        _poinst = new PointWaveUI[count];

        for (int i = 0; i < count; i++)
        {
            _poinst[i] = Instantiate(_prefab,_container.transform,true);
            _poinst[i].IsActivePoint = false;
        }
    }

    public void OnChangeProgressWave(float value, float maxValue )
    {
        _pogresWave.ChaingeBar(value, maxValue);
    }

    public void OnChaigeWave(int vave)
    {
        _poinst[vave].IsActivePoint = true;
    }
}
