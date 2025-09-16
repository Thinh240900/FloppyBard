using System;
using UnityEngine;

public class BirdScript : MonoBehaviour {
    public Rigidbody2D myRigidbody;

    public float flapStrength;

    public LogicScript logic;

    public AudioSource flapSound;

    public bool birdIsAlive = true;
    public float tiltSmooth = 30f;
    public float maxTiltAngle = 30f;
    public float minTiltAngle = -90f;
    public float flapHoldTime = 0.2f;

    private Quaternion _upRotation;
    private Quaternion _downRotation;
    private float _flapTimer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        _upRotation = Quaternion.Euler(0, 0, maxTiltAngle);
        _downRotation = Quaternion.Euler(0, 0, minTiltAngle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive){
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
            flapSound.Play();
            _flapTimer = flapHoldTime;
            
        }

        if (_flapTimer > 0){
            _flapTimer -= Time.deltaTime;
            transform.rotation = Quaternion.Lerp(transform.rotation, _upRotation, tiltSmooth * 5 * Time.deltaTime);
        }
        else{
            if (myRigidbody.linearVelocity.y > 0){
                transform.rotation = Quaternion.Lerp(transform.rotation, _upRotation, tiltSmooth * 5 * Time.deltaTime);
            }
            else{
                transform.rotation = Quaternion.Lerp(transform.rotation, _downRotation, tiltSmooth * Time.deltaTime);
            }
        }


        if (!birdIsAlive){
            // myRigidbody.linearVelocity = Vector2.down * (flapStrength * 3);
            transform.position = new Vector3(transform.position.x, transform.position.y - (flapStrength * 3) * Time.deltaTime, transform.position.z);
            
        }

        if (transform.position.y > 12.5 || transform.position.y < -12.5){
            logic.GameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdIsAlive){
            birdIsAlive = false;
            logic.GameOver();
        }
    }
}
