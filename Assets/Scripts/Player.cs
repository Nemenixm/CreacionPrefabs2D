using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] private Jetpack _jetpack;

    private void Awake()
    {
        _anim=GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_jetpack.Flying)
        {
            _anim.SetBool("flying", _jetpack.Flying);
        }
    }
}
