using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SmoothAbilityBar : MonoBehaviour
{
    [SerializeField] private VampireAbility _vampire;
    [SerializeField] private float _sliderSpeed;

    private Slider _slider;
    private Coroutine _valueChanger;
    private bool _isValueChanging = false;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _vampire.LevelChanged += OnLevelChanhed;
    }

    private void OnDisable()
    {
        _vampire.LevelChanged -= OnLevelChanhed;
    }

    private void OnLevelChanhed()
    {
        if (_isValueChanging)
            StopCoroutine(_valueChanger);

        _valueChanger = StartCoroutine(ChangeValue(_vampire.CurrentLevel / _vampire.MaxLevel));
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
}
