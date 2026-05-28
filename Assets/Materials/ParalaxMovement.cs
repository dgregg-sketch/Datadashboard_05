using UnityEngine;

public class ParalaxMovement : MonoBehaviour
{
    public float animationSpeed = 0.5f;
    private MeshRenderer meshRenderer;
    private float offset;
    private float timeDeltaTime;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);
    }
}
