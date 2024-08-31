using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent (typeof(Image))]
public class VampireAbility : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private float _duration;
    [SerializeField] private float _recoil;
    [SerializeField] private float _damagePerSecond;

    private CircleCollider2D _circleCollider;
    private SpriteRenderer _spriteRenderer;
    private bool _isEnabled = false;
    private Coroutine _VampireJob;

    public event Action<float> HealthRecived;
    public event Action LevelChanged;

    public float CurrentLevel {  get; private set; }
    public float MaxLevel => 100;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    private void OnEnable()
    {
        _circleCollider.enabled = false;
        _spriteRenderer.enabled = false;
        CurrentLevel = MaxLevel;

        LevelChanged?.Invoke();
    }

    private void Update()
    {
        if (_input.isVampiring && _isEnabled == false)
            _VampireJob = StartCoroutine(StartVampirism());
    }

    private IEnumerator StartVampirism()
    {
        float Timer = 0;
        WaitForSeconds Updateduration = new WaitForSeconds(Time.fixedDeltaTime);

        _isEnabled = true;
        _circleCollider.enabled = true;
        _spriteRenderer.enabled=true;

        while (Timer < _duration)
        {
            yield return Updateduration;

            Timer += Time.fixedDeltaTime;
            CurrentLevel = Mathf.MoveTowards(CurrentLevel, 0,Timer/ _duration);

            LevelChanged?.Invoke();
        }

        _circleCollider.enabled = false;
        _spriteRenderer.enabled = false;
        Timer = 0;

        while (Timer < _recoil)
        {
            yield return Updateduration;

            Timer += Time.fixedDeltaTime;
            CurrentLevel = Mathf.MoveTowards(CurrentLevel, MaxLevel, Timer / _recoil);

            LevelChanged?.Invoke();
        }

        _isEnabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Creature creature))
        {
            creature.TakeDamage(_damagePerSecond * Time.fixedDeltaTime);

            HealthRecived?.Invoke(_damagePerSecond * Time.fixedDeltaTime);
        }
    }
}
