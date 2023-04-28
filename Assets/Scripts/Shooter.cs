using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime =5f;
    public bool isFiring;
    Coroutine firingCoroutine;
    void Start()
    {
        
    }

       void Update()
    {
        
    }
    void Fire(){
        
        if(isFiring){
            firingCoroutine= StartCoroutine(FireContinuously());

        }
        else{
            StopCoroutine(firingCoroutine)
        }
    }
    IEnumerator FireContinuously(){
         
    }
}
