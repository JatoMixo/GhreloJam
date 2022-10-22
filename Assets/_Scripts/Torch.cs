using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public new float light;
    public bool canDissapear;
    public float dissapearSpeed;
    public PlayerMovement player;

    void Start (){
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other){
        TriggerInteraction(other, true);
    }
    private void OnTriggerExit2D(Collider2D other){
        TriggerInteraction(other, false);
    }

    private void TriggerInteraction(Collider2D _other, bool _onTorch){
        if (_other.tag == "Player"){
            player.isOnTorch = _onTorch;
            if (canDissapear && _onTorch){
                DecreaseLight();
            }
        }
    }

    void FixedUpdate(){
        if (player.isOnTorch && canDissapear){
            DecreaseLight();
        }
    }

    private void DecreaseLight(){
        Transform spriteMask = transform.GetChild(0);
        CircleCollider2D coll = GetComponent<CircleCollider2D>();

        light -= Time.deltaTime * dissapearSpeed;

        coll.radius = light;
        float dissapearSprite = light * 10;
        spriteMask.localScale = new Vector3(dissapearSprite, dissapearSprite, 0);

        if (light <= 0){
            KillLight();
        }
    }

    private void KillLight(){
        Destroy(gameObject);
    }
}
