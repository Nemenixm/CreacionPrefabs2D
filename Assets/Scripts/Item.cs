using UnityEngine;
using UnityEngine.Rendering;

public class Item : MonoBehaviour
{
    public enum ItemTypes
    {
        None,
        Nose,
        ErrorCode,
        PositiveWords
    }

    [field: SerializeField] public ItemTypes Type {get;set;}
    //  called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
