using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float _duration = 2f;
    public float Duration
    {
        get { return _duration; }
    }

    Light light;
    SphereCollider collider;
    MeshRenderer renderer;
    Animator anim;
    protected GameObject player;
    EnemyHealth enemyHealth;
    bool playerInRange;
    float timer;
    bool isGranted;

    AudioSource powerUpAudio;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        powerUpAudio = GetComponent<AudioSource>();
        renderer = GetComponent<MeshRenderer>();
        collider = GetComponent<SphereCollider>();
        light = GetComponent<Light>();
    }

    // Callback jika ada suatu object masuk ke dalam trigger
    void OnTriggerEnter(Collider other)
    {
        // Set player in range
        if (other.gameObject == player && other.isTrigger == false)
        {
            GrantPowerUp();
            powerUpAudio.Play();
            Hide();
            isGranted = true;
            //Destroy(gameObject);
        }
    }

    void Update()
    {
        if (isGranted)
        {
            timer += Time.deltaTime;
            if (timer >= _duration)
            {
                Reset();
                Destroy(gameObject);
            }
        }

    }

    public void Hide()
    {
        renderer.enabled = false;
        collider.enabled = false;
        light.enabled = false;
    }

    public virtual void GrantPowerUp()
    {
        // Do nothing
    }
    public virtual void Reset()
    {
        // Do nothing
    }

}
