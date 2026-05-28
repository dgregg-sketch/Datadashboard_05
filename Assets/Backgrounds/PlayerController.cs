using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D Rigidbody2D;
    private float elapsedTime =0f;
    private float score = 0f;
    public float scoreMultiplier = 10f;
    public UIDocument uIDocument;
    private Label scoreText;
    private Label MenuScoreLabel;
    private Button restartButton;
    private VisualElement PanelContainer;
    public float GliderUpwardForce = 200f;


    void Awake()
    {
        restartButton = uIDocument.rootVisualElement.Q<Button>("RestartButton");
        PanelContainer = uIDocument.rootVisualElement.Q<VisualElement>("PanelContainer");
      
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //Gets the Rigidbody2D component of the ROV. The rigidbody component allows for collison detection and physics interactions with other objects in the game world.
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        scoreText = uIDocument.rootVisualElement.Q<Label>("ScoreLabel");
        MenuScoreLabel = uIDocument.rootVisualElement.Q<Label>("MenuScoreLabel");
        restartButton = uIDocument.rootVisualElement.Q<Button>("RestartButton");
        restartButton.clicked += ReloadScene;
        restartButton.style.display = DisplayStyle.None;
        PanelContainer.style.display = DisplayStyle.None;
    }

    // Update is called once per frame
    //Raises the ROV upwards whenr the left mouse button is pressed
    void Update()
    {
        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime * scoreMultiplier);
        Debug.Log("Score: " + score);
        scoreText.text = "DATA COLLECTED:" + score;
        MenuScoreLabel.text = "" + score;
        if(Mouse.current.leftButton.wasPressedThisFrame)
        {
          
            Rigidbody2D.AddForce(Vector2.up * GliderUpwardForce);
        }
    }

    //Destroys the ROV when it collides with an obstacle
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        restartButton.style.display = DisplayStyle.Flex;
        PanelContainer.style.display = DisplayStyle.Flex;
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
