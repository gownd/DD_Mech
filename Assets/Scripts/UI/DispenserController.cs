using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispenserController : MonoBehaviour
{
    [SerializeField] Camera mainCamera = null;
    [SerializeField] float startYPos = 1f;
    [SerializeField] float endYPos = 5f;
    [SerializeField] float posValue = 0f;
    [SerializeField] Transform gear = null;
    [SerializeField] float maxRotation = -360f;
    // [SerializeField] float moveSpeed = 10f;

    Rigidbody2D rb;

    bool isMoving = false;
    // float timePassed;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {  
        Move();
    }

    private void OnMouseDown() 
    {
        isMoving = true;
    }

    private void OnMouseUp() 
    {
        isMoving = false;  
    }

    void Move()
    {
        if(!isMoving) return;

        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        float yPosToMove = Mathf.Clamp(mousePos.y, startYPos, endYPos);
        this.transform.position = new Vector3(transform.position.x, yPosToMove, transform.position.z);

        posValue = ( transform.position.y - startYPos ) / (endYPos - startYPos);  

        gear.eulerAngles = new Vector3(0f, 0f, posValue * maxRotation);
    }

    public float GetPosValue()
    {
        return posValue;
    }

    // void MoveAuto()
    // {
    //     timePassed += Time.deltaTime;
    //     transform.position = new Vector2(transform.position.x, ((Mathf.Sin(timePassed * moveSpeed) + 1f)/2f * (endYPos - startYPos)) + 1);
    //     posValue = ( transform.position.y - startYPos ) / (endYPos - startYPos);  
    //     gear.eulerAngles = new Vector3(0f, 0f, posValue * maxRotation);
    // }
}