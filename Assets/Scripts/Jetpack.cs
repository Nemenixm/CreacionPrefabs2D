using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
public class Jetpack : MonoBehaviour
{
    public enum Direction { left, Right }

    // Propiedades públicas
    public float Energy
    {
        get => _energy;
        private set => _energy = Mathf.Clamp(value, 0f, _maxEnergy);
    }

    // Esto ahora sí dice la verdad
    public bool Flying => _flying;

    // Fields
    private Rigidbody2D _target;

    [SerializeField] private float _maxEnergy = 100f;

    [Tooltip("Energía consumida por segundo mientras vuelas")]
    [SerializeField] private float _energyFlyingRatio = 20f;

    [Tooltip("Energía regenerada por segundo cuando NO vuelas y estás casi parado")]
    [SerializeField] private float _energyRegenerationRatio = 10f;

    [SerializeField] private float _horizontalForce = 10f;
    [SerializeField] private float _flyForce = 10f;

    [Tooltip("Si la velocidad vertical es menor que esto, consideramos que estás 'parado' para regenerar")]
    [SerializeField] private float _regenVelThreshold = 0.1f;

    private bool _flying = false;
    private float _energy;

    private void Awake()
    {
        _target = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Energy = _maxEnergy;
    }

    // Public Methods
    public void FlyUp() => _flying = true;
    public void StopFlying() => _flying = false;

    public void Regenerate()
    {
        Regenerate(_energyRegenerationRatio * Time.fixedDeltaTime);
    }

    public void Regenerate(float energy)
    {
        Energy += energy;
    }

    public void FlyHorizontal(Direction flyDirection)
    {
        if (!_flying) return;

        if (flyDirection == Direction.left)
            _target.AddForce(Vector2.left * _horizontalForce);
        else
            _target.AddForce(Vector2.right * _horizontalForce);
    }

    private void FixedUpdate()
    {
        if (_flying)
        {
            DoFly();
        }
        else
        {
            // Solo regeneramos cuando NO volamos y estamos casi sin movimiento vertical
            if (Mathf.Abs(_target.linearVelocity.y) < _regenVelThreshold)
            {
                Regenerate();
            }
        }
    }

    private void DoFly()
    {
        if (Energy > 0f)
        {
            _target.AddForce(Vector2.up * _flyForce);
            Energy -= _energyFlyingRatio * Time.fixedDeltaTime;
        }
        else
        {
            _flying = false;
        }
    }
}
