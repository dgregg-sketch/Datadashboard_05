using UnityEngine;

public class ObstacleScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the M
    //True Obstacle Script
    Rigidbody2D rb;
    [SerializeField] private float _speedObstacleWorkPlease = 10f;
    public float minSpeed = 5f;
    public float maxSpeed = 3f;
   
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
      transform.position += Vector3.left * _speedObstacleWorkPlease * Time.deltaTime;
      if (transform.position.x < -118.21f)
      {
          Vector2 v = transform.position;
          v.x = -1.67f;
          transform.position = v;
      }
    }
}
