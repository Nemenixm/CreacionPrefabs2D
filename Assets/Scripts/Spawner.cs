using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
   
    [SerializeField]private List<Item> _spawnList;
    [SerializeField]private float _maxSpawnTime=5;
    [SerializeField]private float _minSpawnTime=1;
    [SerializeField]private float _nextSpawnTime;
    [SerializeField]private float _cronoTime=0;
    
    void Start()
    {
        ResetTime();
    }

    // Update is called once per frame
    void Update()
    {
        _cronoTime += Time.deltaTime;
        if (_cronoTime > _nextSpawnTime)
        {
            SpawnItem(); 
            ResetTime();
        }
    }

    private void ResetTime()
    {
        _cronoTime=0;
        _nextSpawnTime = Random.Range(_minSpawnTime, _maxSpawnTime);
    }
    private void SpawnItem()
    {
        //Random object from a list
        int index =Random.Range(0,_spawnList.Count);
        //Random horizontal position
        float xPos= Random.Range (-7f, 7f);
        Vector2 itemPosition = new Vector2(xPos, transform.position.y);
        //Instanciacion
        Item newItem = Instantiate(_spawnList[index], itemPosition, Quaternion.identity);
        //Add Rotation Force
        float torqueForce= Random.Range (-70f, 70f);
        newItem.GetComponent<Rigidbody2D>().AddTorque(torqueForce);    
    }

}
