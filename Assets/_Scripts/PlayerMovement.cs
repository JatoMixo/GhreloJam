using UnityEngine;
using System.Collections.Generic;
public class PlayerMovement : MonoBehaviour{

    public float maxDistance;
    public float speedReduction;
    public float speedAmplification;
    private Rigidbody2D rb;
    private LineRenderer lineRenderer;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.useWorldSpace = true;
    }

    void FixedUpdate(){
        if (Input.GetMouseButton(0)){
            lineRenderer.enabled = true;
            Vector3[] pos = new Vector3[2];

            pos[0] = transform.position;
            pos[1] = TakeMouseDistance();

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

    public Vector2 TakeMouseDistance(){
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 rest;

        rest.x = transform.position.x - mousePos.x;
        rest.y = transform.position.y - mousePos.y;

        float distance = Mathf.Abs(Mathf.Sqrt(Mathf.Pow(rest.x, 2) + Mathf.Pow(rest.y, 2)));

        if (false){

        }

        return rest;
    }
}