using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerMovement player;
    public bool levelComplete;
    public float increaseLightSpeed;

    void Start(){
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void Update(){
        if (levelComplete){
            player.light += Time.deltaTime * increaseLightSpeed;
        }
    }

    public void CompleteLevel (){
        Debug.Log("Level completed :)");
        player.isOnTorch = true;
        levelComplete = true;

        LevelMenu();
    }

    private void LevelMenu(){
        Debug.Log("The menu of the level appears");
    }    
}
