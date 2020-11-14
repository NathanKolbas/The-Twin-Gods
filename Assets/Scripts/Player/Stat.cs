using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{

    private Image _content;
    [SerializeField] private float lerpSpeed = 1;
    private float _currentFill;
    public float MaxValue { get; set; }
    public float CurrentValue
    {
        get => _currentValue;
        set
        {
            if (value > MaxValue)
            {
                _currentValue = MaxValue;
            }
            else if (value < 0)
            {
                _currentValue = 0;
            }
            else
            {
                _currentValue = value;
            }
            
            _currentFill = _currentValue / MaxValue;
        }
    }
    private float _currentValue;

    // Start is called before the first frame update
    void Start()
    {
        _content = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_currentFill != _content.fillAmount)
        {
            _content.fillAmount = Mathf.Lerp(_content.fillAmount, _currentFill, Time.deltaTime * lerpSpeed);
        }
    }

    public void Initialize(float currentValue, float maxValue)
    {
        MaxValue = maxValue;
        CurrentValue = currentValue;
    }
}
