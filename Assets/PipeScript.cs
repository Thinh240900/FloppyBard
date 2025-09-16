using UnityEngine;

public class PipeScript : MonoBehaviour {
    public float pipeSpeed = 10;
    public float deadZone = -45;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.left * (pipeSpeed * Time.deltaTime);

        if (transform.position.x < deadZone){
            Destroy(gameObject);
        }
    }
}
