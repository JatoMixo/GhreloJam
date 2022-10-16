using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public PlayerMovement player;
    public Transform hoyo;
    public bool levelComplete;
    public float increaseLightSpeed;
    public float animationSpeed;
    private bool ballDestroyed;
    [Header("level system")]
    public Scene mainMenu;
    public GameObject winPanel;

    void Start(){
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
        hoyo = GameObject.Find("Hoyo").transform;
    }

    void Update(){
        if (levelComplete){
            player.transform.GetChild(0).localScale += new Vector3(Time.deltaTime * increaseLightSpeed, Time.deltaTime * increaseLightSpeed, 0);
            Animation();
        }
    }

    public void CompleteLevel (){
        Debug.Log("Level completed :)");
        player.isOnTorch = true;
        levelComplete = true;
        player.enabled = false;

        Animation();

        LevelMenu();
    }

    private void Animation (){
        player.transform.position = new Vector2(hoyo.position.x + Random.Range(-0.02f, 0.03f), hoyo.position.y + Random.Range(-0.02f, 0.03f));
        if (player.transform.localScale.x > 0) player.transform.localScale -= new Vector3(Time.deltaTime * animationSpeed, Time.deltaTime * animationSpeed);
        hoyo.GetChild(0).localScale += new Vector3(Time.deltaTime * increaseLightSpeed, Time.deltaTime * increaseLightSpeed);
    }

    private void LevelMenu(){
        winPanel.SetActive(true);
    }    

    public void NextButton (){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void MenuButton(){
        SceneManager.LoadScene(mainMenu.buildIndex);
    }
}
