using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    public float maxDistance;

    void Start(){
        GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 0));
    }

    void Update(){
        if (Input.GetMouseButtonUp(0)){
            GetComponent<Rigidbody2D>().AddForce(TakeMouseDistance());
        }
    }

    public Vector2 TakeMouseDistance(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 rest;

        rest.x = transform.position.x - mousePos.x;
        rest.y = transform.position.y - mousePos.y;

        float distance = Mathf.Abs(Mathf.Sqrt(Mathf.Pow(rest.x, 2) + Mathf.Pow(rest.y, 2)));

        if (distance >= maxDistance){
                
            //GetComponent<Rigidbody2D>().AddForce(rest);
        }

        return rest;
    }
}