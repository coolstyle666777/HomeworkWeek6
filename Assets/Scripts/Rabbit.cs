using UnityEngine;

public class Rabbit : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _attackPeriod = 7;

    private static string AttackParametr = "Attack";
    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _attackPeriod)
        {
            _animator.SetTrigger(AttackParametr);
            _timer = 0;
        }
    }
}