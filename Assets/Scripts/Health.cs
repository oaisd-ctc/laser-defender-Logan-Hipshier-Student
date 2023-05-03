using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int score=50;
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;

    void Awake(){
        cameraShake=Camera.main.GetComponent<CameraShake>();
        audioPlayer= FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

    }

    void OnTriggerEnter2D(Collider2D other){
        DamageDealer damageDealer= other.GetComponent<DamageDealer>();
        if(damageDealer!= null){
            
            TakeDamage(damageDealer.GetDamage());
            playHitEffect();
            ShakeCamera();
            audioPlayer.PlayDamageClip();

        }
    }
    public int GetHealth(){
        return health;
    }
    void TakeDamage(int damage){
        health-= damage;
        if(health<=0){
            audioPlayer.PlayExplosionClip();
            if(!isPlayer){
                scoreKeeper.ModifyScore(score);
            }
            Destroy(gameObject);
        }
    }
    void playHitEffect(){
        if(hitEffect!=null){
            ParticleSystem instance = Instantiate(hitEffect, transform.position,Quaternion.identity);
            Destroy(instance.gameObject,instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
    void ShakeCamera(){
        if(cameraShake != null && applyCameraShake){
            cameraShake.Play();
        }
    }
}
