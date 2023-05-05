using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
 static int FinalScore;
int score;
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
public void SetFinalScore(int value){
    FinalScore = value;
}

}
