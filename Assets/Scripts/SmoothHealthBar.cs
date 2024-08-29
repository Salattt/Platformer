using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothHealthBar : HeatlthView
{
    [SerializeField] private float _sliderSpeed;

    private Slider _slider;
    private Coroutine _valueChanger;
    private bool _isValueChanging = false;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private IEnumerator ChangeValue(float targetValue)
    {
        WaitForSeconds delay = new WaitForSeconds(Time.fixedDeltaTime);
        _isValueChanging = true;

        while (_slider.value != targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetValue, _sliderSpeed);

            yield return delay;
        }

        _isValueChanging = false;
    }

    protected override void UpdateHealth(float currentHealth, float maxHealth)
    {
        if (_isValueChanging)
            StopCoroutine(_valueChanger);

        _valueChanger = StartCoroutine(ChangeValue(currentHealth / maxHealth));
    }
}
