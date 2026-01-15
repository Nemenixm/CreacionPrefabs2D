using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField]private Jetpack _jetpack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Horizontal Fly
        if (Input.GetAxis("Horizontal") < 0)
        {
            _jetpack.FlyHorizontal(Jetpack.Direction.left);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            _jetpack.FlyHorizontal(Jetpack.Direction.Right);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            _jetpack.FlyUp();
        }
        else
        {
            _jetpack.StopFlying();
        }
    }
}
