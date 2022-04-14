using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingSphere : MonoBehaviour
{
    //Movement
    [SerializeField, Range(0f, 100f)] 
    float maxSpeed = 10f;
    
    [SerializeField, Range(0f, 100f)]
    float maxAcceleration = 10f;
    

    //Bounciness
    [SerializeField, Range(0f, 1f)]
    float bounciness = 0.5f;
    
    //Allowed Area
    [SerializeField]
    Rect allowedArea = new Rect(-5f, -5f, 10f, 10f);

    Vector3 velocity;
    private void Update()
    {
        //Player Input
        Vector2 playerInput;
        playerInput.x = Input.GetAxis("Horizontal");
        playerInput.y = Input.GetAxis("Vertical");
        playerInput = Vector2.ClampMagnitude(playerInput, 1f);

        //Movement
        Vector3 desiredVelocity = new Vector3(playerInput.x, 0f, playerInput.y) * maxSpeed;
       
        float maxSpeedChange = maxAcceleration * Time.deltaTime;
        
        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.z = Mathf.MoveTowards(velocity.z, desiredVelocity.z, maxSpeedChange);
        //Mathf.MoveTowards = Verilen değerden, hedeflenen değere doğru, belirttiğimiz artış miktarıyla değişim olmasını sağlar.
        Vector3 displacement = velocity * Time.deltaTime;
        Vector3 newPosition = transform.localPosition + displacement;
  
        
        // ALlowed Area && Bounciness
        
        if (newPosition.x < allowedArea.xMin) 
        {
            newPosition.x = allowedArea.xMin;
            velocity.x = -velocity.x * bounciness;
        }
        else if (newPosition.x > allowedArea.xMax) 
        {
            newPosition.x = allowedArea.xMax;
            velocity.x = -velocity.x * bounciness;
        }
       
        
        if (newPosition.z < allowedArea.yMin) 
        {
            newPosition.z = allowedArea.yMin;
            velocity.z = -velocity.z * bounciness;
        }
        else if (newPosition.z > allowedArea.yMax) 
        {
            newPosition.z = allowedArea.yMax;
            velocity.z = -velocity.z * bounciness;
        }

        transform.localPosition = newPosition;
        
        


    }
}
