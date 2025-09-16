using UnityEngine;

public class PipeSpawnScript : MonoBehaviour {
    public GameObject pipe;

    public float spawnRate = 3;

    private float _timer = 0;

    public float heightOffSet = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer < spawnRate){
            _timer = _timer + Time.deltaTime;
        }
        else{
                   SpawnPipe();     
        }
    }

    private void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffSet;
        float highestPoint = transform.position.y + heightOffSet;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), transform.position.z), transform.rotation);
        _timer = 0;
    }
}
