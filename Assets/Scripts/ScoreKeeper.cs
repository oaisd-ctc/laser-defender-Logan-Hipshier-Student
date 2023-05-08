using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{

int score;
    static ScoreKeeper instance;
    void Awake(){
        ManageSingleton();
    }
    void ManageSingleton(){
        if(instance!= null){
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else{
            instance=this;
            DontDestroyOnLoad(gameObject);
        }
    }

void Start(){
    ResetScore();
    
}


public int GetScore(){
    return score;
}
public void ModifyScore(int value){
    score+= value;
    Mathf.Clamp(score,0,int.MaxValue);
}
public void ResetScore(){
    score = 0;
}




}
