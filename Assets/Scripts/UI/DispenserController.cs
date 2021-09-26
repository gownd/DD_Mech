using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.NiceVibrations;

public class DispenserController : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] Camera mainCamera = null;

    [Header("Config")]
    [SerializeField] float startYPos = 1f;
    [SerializeField] float endYPos = 5f;
    [SerializeField] float moveSpeed = 10f;
    
    [Header("Gear")]
    [SerializeField] Transform gear = null;
    [SerializeField] float maxRotation = -360f;

    float posValue = 0f;

    bool isMoving = false;
    bool isUpPressed = false;
    bool isDownPressed = false;

    Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {  
        MoveByGear();
        Move();
    }

    void Move()
    {
        if(isUpPressed && posValue < 1f)
        {
            rb.velocity = new Vector2(rb.velocity.x, moveSpeed * Time.deltaTime);
        }
        else if(isDownPressed && posValue > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, -moveSpeed * Time.deltaTime);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
        }

        posValue = ( transform.position.y - startYPos ) / (endYPos - startYPos);  
        gear.eulerAngles = new Vector3(0f, 0f, posValue * maxRotation);
    }

    private void OnMouseDown() 
    {
        isMoving = true;
    }

    private void OnMouseUp() 
    {
        isMoving = false;  
    }

    void MoveByGear()
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

    public void PressUpButton()
    {
        if(isUpPressed == false) FindObjectOfType<HapticPlayer>().PlayHaptic(HapticTypes.Selection);
        isUpPressed = true;
        isDownPressed = false;
    }

    public void PressDownButton()
    {
        if(isDownPressed == false) FindObjectOfType<HapticPlayer>().PlayHaptic(HapticTypes.Selection);
        isUpPressed = false;
        isDownPressed = true;
    }

    public void UnpressButtons()
    {
        isUpPressed = false;
        isDownPressed = false;
    }
}
