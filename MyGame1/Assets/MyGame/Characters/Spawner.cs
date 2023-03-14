using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Enemy _enemy;
    [SerializeField] private Player player;
    [SerializeField] private float _timeSpawn;
    private float _timer;

    private void Awake()
    {
        _timer = 0;
    }

    private void Update()
    {
        if(_timer <= 0)
        {
            _timer = _timeSpawn;
            var t = Instantiate(_enemy,transform, true);
            t.Init(player.gameObject);
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
}
