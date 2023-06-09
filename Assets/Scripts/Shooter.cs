using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime =5f;
    [SerializeField] float firingRate = 0.2f;
    [SerializeField] bool useAI;

    AudioPlayer audioPlayer;
    public bool isFiring;
    Coroutine firingCoroutine;
    void Awake(){
        audioPlayer= FindObjectOfType<AudioPlayer>();
    }
    void Start()
    {
        if(useAI){
            isFiring = true;
        }
    }

       void Update()
    {
        Fire();
    }
    void Fire(){
        
        if(isFiring && firingCoroutine==null){
            firingCoroutine= StartCoroutine(FireContinuously());

        }
        else if (!isFiring && firingCoroutine != null){
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }
    IEnumerator FireContinuously(){
        while(true){
            GameObject instance= Instantiate(projectilePrefab,
                                             transform.position,
                                             Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb!= null && !useAI){
                rb.velocity= new Vector2(0, projectileSpeed);

            }
            else if (rb!= null && useAI){
                rb.velocity= new Vector2(0, -projectileSpeed);
            }
            Destroy(instance,projectileLifetime);
            audioPlayer.PlayShootingClip();
            yield return new WaitForSeconds(firingRate);
        }
         
    }
}
