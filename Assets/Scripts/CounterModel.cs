using System;
using System.Collections;
using UnityEngine;

class CounterModel : MonoBehaviour
{
    private Coroutine _coroutine;
    private WaitForSeconds _delay;
    private bool LeftMouseButtonIsPressed => 
        Input.GetMouseButtonDown(0);
    
    public int Value { get; private set; }
    public event Action ValueChanged;


    private void Start()
    {
        float amount = 0.5f;

        _delay = new WaitForSeconds(amount);
    }

    private void Update()
    {
        if (LeftMouseButtonIsPressed)
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(AddPoint());

                return;
            }

            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator AddPoint()
    {
        while (enabled)
        {
            Value++;

            ValueChanged?.Invoke();
            yield return _delay;
        }
    }
}