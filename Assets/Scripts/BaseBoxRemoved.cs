using UnityEngine;

public class BaseBoxRemoved : MonoBehaviour
{
    
    [SerializeField] GameObject LevelLoseUi;
    [SerializeField] GameObject gameplayUi;
    private PlayerMovement playerMovement;
    private Animator characterAnimator;
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        characterAnimator = GetComponentInChildren<Animator>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Obstacle") || collision.transform.CompareTag("GroundObstacle"))
        {
            
            playerMovement.speed = 0;
            characterAnimator.enabled = false;
            Invoke("ShowLevelEndUi", 1.5f);
        }
        else if (collision.transform.CompareTag("FinalObstacle"))
        {
            //Todo Make it LevelEnd True on Player Movement.cs
            playerMovement.isLevelEnd = true;
        }
    }

    void ShowLevelEndUi()
    {
        LevelLoseUi.SetActive(true);
        gameplayUi.SetActive(false);
    }
}
