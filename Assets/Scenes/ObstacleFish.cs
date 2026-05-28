using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ObstacleFish : MonoBehaviour
{
    public float FishSpeed = 5;
    public float transformPosition = 0f;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
         transform.Translate(Vector3.left * FishSpeed * Time.deltaTime);
         if (transform.position.x < -18f)
         {
                Vector2 v = transform.position;
                v.x = 30f;
                transform.position = v;
         }
    }
}


