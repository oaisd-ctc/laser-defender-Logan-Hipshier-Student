using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)] float shootingVolume= 1f;
    
    
    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f,1f)] float damageVolume= 1f;

    [Header("Explosion")]
    [SerializeField] AudioClip explosionClip;
    [SerializeField] [Range(0f,1f)] float explosionVolume= 1f;

    public void PlayShootingClip(){
        if(shootingClip!=null){

            AudioSource.PlayClipAtPoint(shootingClip,Camera.main.transform.position,shootingVolume);
        }
    }
    public void PlayDamageClip(){
        if(damageClip!=null){
            
            AudioSource.PlayClipAtPoint(damageClip,Camera.main.transform.position,damageVolume);
        }
    }
    public void PlayExplosionClip(){
        if(explosionClip!=null){
            
            AudioSource.PlayClipAtPoint(explosionClip,Camera.main.transform.position,explosionVolume);
        }
    }
}
