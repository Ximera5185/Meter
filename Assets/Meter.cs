using System.Collections;
using UnityEngine;

public class Meter : MonoBehaviour
{
    private Coroutine _currentCoroutine;

    private WaitForSeconds _waitForSeconds;

    private float _counter = 0;
    private float _timeDelay = 0.5f;

    private int _leftClick = 0;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_timeDelay);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(_leftClick))
        {
            if (_currentCoroutine == null)
            {
                _currentCoroutine = StartCoroutine(Counting());
            }
            else
            {
                StopCoroutine(_currentCoroutine);

                _currentCoroutine = null;
            }
        }
    }

    private IEnumerator Counting()
    {
        while (true)
        {
            _counter++;

            Debug.Log(_counter);

            yield return _waitForSeconds;
        }
    }
}