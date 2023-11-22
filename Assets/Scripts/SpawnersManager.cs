using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class SpawnersManager : MonoBehaviour
{
    private bool _isWork;
    private Random _random = new Random();
    private Spawner[] _spavners;

    private void Awake()
    {
        _isWork = true;
        _spavners = GetComponentsInChildren<Spawner>();
        StartCoroutine(Spam());
    }

    private IEnumerator Spam()
    {
        while (_isWork)
        {
            _spavners[_random.Next(_spavners.Length)].SpamEnemy();
            yield return new WaitForSeconds(2);
        }
    }
}
