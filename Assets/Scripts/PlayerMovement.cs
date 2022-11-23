using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[SelectionBase]
public class PlayerMovement : MonoBehaviour
{
    #region Variables
    //Ref
    
    [SerializeField] private InputManager InputManager;
    [SerializeField] private Transform[] checkPoints;
    [SerializeField] private GameObject levelEndUi;
    [SerializeField] private GameObject gameplayUi;
    [SerializeField] private Transform pointAB;
    [SerializeField] private Transform pointBC;
    [SerializeField] private Camera secondCamera;
    private Transform inputManagerObj;
    private Transform target;
    private Transform pointA;
    private Transform pointB;
    private Transform pointC;

    //Config
    public float speed;
    private float interpolateAmount;
    private int index;

    //State 
    public bool isGameStart;
    public bool isLevelEnd;
    private bool isTurning;
    private bool isGoing;
    #endregion

    #region Methods
    private void Start()
    {
        isGoing = true;
        index = 0;
        target = checkPoints[index];
        inputManagerObj = InputManager.gameObject.transform;
        secondCamera.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isGameStart = true;
        }
        FollowPath();
        TurningHandler();
    }
    private void FollowPath()
    {
        if (isLevelEnd)
        {
            //TODO Level end things below here
            Destroy(InputManager);
            Invoke("ShowLevelEndUi", 1.5f);
            speed = 0;
        }

        if (isGoing && isGameStart)
        { transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime); }

        if (transform.position == target.position && !(index < checkPoints.Length))
        {
            SetCameraPos();
            isLevelEnd = true;
        }

        else if (transform.position == target.position)
        {
            if (target.CompareTag("Corner"))
            {
                pointA = target;
                index++;
                pointB = checkPoints[index];
                index++;
                pointC = checkPoints[index];
                isGoing = false;
                isTurning = true;
            }
            else
            {
                index++;
                target = checkPoints[index];
            }
        }
    }
    private void ShowLevelEndUi()
    {

        levelEndUi.SetActive(true);
        gameplayUi.SetActive(false);
        Destroy(this);
    }
    private void TurningHandler()
    {
        if (isTurning)
        {
            interpolateAmount = (interpolateAmount + Time.deltaTime) % 1f;
            pointAB.position = Vector3.Lerp(pointA.position, pointB.position, interpolateAmount);
            pointBC.position = Vector3.Lerp(pointB.position, pointC.position, interpolateAmount);
            transform.position = Vector3.Lerp(pointAB.position, pointBC.position, interpolateAmount);
            transform.LookAt(pointBC, Vector3.up);

            if (Vector3.Distance(transform.position, pointC.position) < 0.08f)
            {
                if (index < checkPoints.Length - 1) { index++; }
                interpolateAmount = 0;
                target = checkPoints[index];
                isTurning = false; isGoing = true;
                transform.rotation = Quaternion.Euler(0, checkPoints[index - 1].localRotation.eulerAngles.y, 0);
            }
        }
    }
    private void SetCameraPos()
    {
        secondCamera.gameObject.SetActive(true);
    }
    #endregion
}
