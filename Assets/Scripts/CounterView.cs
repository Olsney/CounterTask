using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private CounterModel _counterModel;
    
    public void OnEnable()
    {
        _counterModel.ValueChanged += ShowInfo;
    }

    public void OnDisable()
    {
        _counterModel.ValueChanged -= ShowInfo;
    }

    private void ShowInfo()
    {
        Debug.Log($"Количество монет: {_counterModel.Value}");
    }
}