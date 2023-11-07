using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject carPrefab;
    [SerializeField]
    private bool bIsGoingLeft = true;
    [SerializeField]
    private float spawnIntervalMin = 3f;
    [SerializeField] 
    private float spawnIntervalMax = 10f;

    private int enemiesLeft;
    private float randomTimer;
    // Start is called before the first frame update
    void Start()
    {
        randomTimer = Random.Range(spawnIntervalMin, spawnIntervalMax);


    }

    private void Update()
    {
        randomTimer -= Time.deltaTime;

        if(randomTimer <= 0f)
        {
            randomTimer = Random.Range(spawnIntervalMin, spawnIntervalMax);
            SpawnCar();
        }
    }

    void SpawnCar()
    {
 
            GameObject carInstance = Instantiate(carPrefab, transform.position, transform.rotation);

        Car car = carInstance.GetComponent<Car>();
        if(car != null )
        {
            car.SetIsGoingLeft(bIsGoingLeft);
        }
    }
}
