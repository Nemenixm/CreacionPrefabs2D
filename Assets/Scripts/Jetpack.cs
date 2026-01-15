using UnityEngine;
using System;

 [RequireComponent(typeof(Rigidbody2D))]
public class Jetpack : MonoBehaviour
{
    public enum Direction
    {
        left,
        Right
    }
    //Propiedades públicas
    public float Energy {get;set;}
    //Fields
     private Rigidbody2D _target;
    [SerializeField]private float _maxEnergy;
    [SerializeField] private float _energyFlyingRatio;
    [SerializeField] private float _energyRegenerationRatio;
    [SerializeField] private float _horizontalForce;
    [SerializeField] private float _flyForce;
    private bool _flying= false;

    private void Awake()
    {
        _target=GetComponent<Rigidbody2D>();
    }
    //Public Methods
    public void FlyUp()
    {
        _flying=true;
    }
    public void StopFlying()
    {
        _flying=false;
    }
    public void Regenerate()
    {
        Energy+=_energyRegenerationRatio;
    }
    public void Regenerate(float energy)
    {
        Energy+=_energyRegenerationRatio;
    }
    public void FlyHorizontal(Direction flyDirection)
    {
        if (!_flying)
        {
            return;
        }
        if (flyDirection==Direction.left)
        {
            _target.AddForce(Vector2.left* _horizontalForce);
        }
        else
        {
            _target.AddForce(Vector2.right* _horizontalForce);
        }
    }
    void Start()
    {
       Energy=_maxEnergy;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_flying)
        {
            DoFly();
            
        }
        
    }

    private void DoFly()
    {
        if(Energy>0){
        _target.AddForce(Vector2.up * _flyForce);
            Energy -= _energyFlyingRatio;
    }
        else
        {
            _flying = false;
        }
    }

    
}
