using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;// 

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private ProgressBarFill progressBarFill;
    [SerializeField] private GamePlayLevelUI gamePlayLevelUI; //

    [SerializeField] float speedToTheSides;
    [SerializeField] float rightBoundary;
    [SerializeField] float leftBoundary;
    [SerializeField] float startPosition;
    [SerializeField] float moveForwardSpeed = 0.5f;

    WinConditon winConditonScript;
    PlayerScore playerScoreScript;
    Rigidbody playerRigidBody;
    public bool keyHasPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        transform.position = new Vector3(startPosition, 1f, -96.7f);
        winConditonScript = FindObjectOfType<WinConditon>();
        playerScoreScript = FindObjectOfType<PlayerScore>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovment();
        IsAnyKeyPressed();
        MovePlayerForward();


    }

    private void MovePlayerForward()
    {
        if (keyHasPressed)
        {
            playerRigidBody.velocity = new Vector3(0f, 0f, moveForwardSpeed);
            progressBarFill.CalcProgressBarValue();
            gamePlayLevelUI.OnGameStarted(); // call for the UI method
        }
        else
        {
            playerRigidBody.velocity = new Vector3(0f, 0f, 0f);
        }

        if (winConditonScript.playerEndedLevel || playerScoreScript.playerLost)
        {
            playerRigidBody.velocity = new Vector3(0f, 0f, 0f);
        }



        //if (keyHasPressed && (!winConditonScript.playerEndedLevel) || (!playerScoreScript.playerLost))
        //{
        //    playerRigidBody.velocity = new Vector3(0f, 0f, moveForwardSpeed);
        //    progressBarFill.CalcProgressBarValue();
        //}
        //else
        //{
        //    playerRigidBody.velocity = new Vector3(0f, 0f, 0f);
        //}
    }

    private void IsAnyKeyPressed()
    {
        if (Input.anyKey && EventSystem.current.currentSelectedGameObject == null) // 
        {
            keyHasPressed = true;
        }
    }

    private void PlayerMovment()
    {
        if (winConditonScript.playerEndedLevel || playerScoreScript.playerLost) 
        {
           return;
        }
        else
        {
            PlayerBoundaries();

            float horizontalInput = Input.GetAxisRaw("Horizontal");

            Vector3 direction = new Vector3(horizontalInput, 0, 0).normalized;
            transform.Translate(direction * speedToTheSides * Time.deltaTime);
        }



        //this can be good for Touch movement
        /*Vector3 deltaPosition = transform.forward * forwardSpeed;
        if (Input.touchCount > 0)
        {
            Vector3 touchPosition = Input.GetTouch(0).position;
            if (touchPosition.x > Screen.width * 0.5f)
                deltaPosition += transform.right * sideSpeed;
            else
                deltaPosition -= transform.right * sideSpeed;
        }*/
    }

    private void PlayerBoundaries()
    {

        float xMovementClamp = Mathf.Clamp(transform.position.x, leftBoundary, rightBoundary);
        Vector3 limitPlayerMovement = new Vector3(xMovementClamp, transform.position.y, transform.position.z);
        transform.position = limitPlayerMovement;
    }
}