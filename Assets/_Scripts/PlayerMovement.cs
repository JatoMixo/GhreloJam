using UnityEngine;
using System.Collections.Generic;
public class PlayerMovement : MonoBehaviour{

    [Header("Movement")]
    public float maxDistance;
    public float speedReduction;
    public float speedAmplification;
    private Rigidbody2D rb;
    [Space]
    [Header("Line drawing")]
    private LineRenderer lineRenderer;
    [Space]
    [Header("Light system")]
    public new float light;
    public float lightDrecementSpeed;
    public bool isOnTorch;
    public float maxLight;
    public Transform spriteMask;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.useWorldSpace = true;
        spriteMask = transform.GetChild(0);
        spriteMask.localScale = new Vector2(light, light);
        maxLight = light;
    }

    void FixedUpdate(){

        if (!isOnTorch){
            light -= Time.deltaTime * lightDrecementSpeed;
        } else if (isOnTorch && light <= maxLight){
            light += Time.deltaTime * lightDrecementSpeed/2;
        }
        if (light <= 0){
            Debug.Log("Yuo died lol");
            Die();
        }
        spriteMask.localScale = new Vector2(light, light);

        if (Input.GetMouseButton(0)){
            lineRenderer.enabled = true;
            Vector3[] pos = new Vector3[2];

            pos[0] = transform.position;
            pos[1] = GetMousePos();

            lineRenderer.SetPositions(pos);
        } else {
            lineRenderer.enabled = false;
        }


        if (Input.GetMouseButtonUp(0)){
            rb.velocity += new Vector2(TakeMouseDistance().x * Time.deltaTime * speedAmplification, TakeMouseDistance().y * Time.deltaTime * speedAmplification);
        }

        if (rb.velocity.x != 0 || rb.velocity.y != 0){
            rb.velocity -= new Vector2(rb.velocity.x/speedReduction, rb.velocity.y/speedReduction);
        }
    }

    public void Die(){
        Destroy(gameObject);
    }

    public Vector2 TakeMouseDistance(){
        Vector3 mousePos = GetMousePos();

        Vector2 rest;

        rest.x = transform.position.x - mousePos.x;
        rest.y = transform.position.y - mousePos.y;

        float distance = Mathf.Abs(Mathf.Sqrt(Mathf.Pow(rest.x, 2) + Mathf.Pow(rest.y, 2)));

        if (false){

        }

        return rest;
    }

    public Vector2 GetMousePos (){
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}