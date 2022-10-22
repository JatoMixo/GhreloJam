using UnityEngine;

public class Hoyo : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player"){
            GameObject.Find("GameManager").GetComponent<GameManager>().CompleteLevel();
        }
    }
}
