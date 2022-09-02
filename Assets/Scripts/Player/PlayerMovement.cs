using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField] private float startSpeed;  //speed after game starts

   private Vector2 startPosition;
   private Vector2 direction;
   private Rigidbody rigidbody;
   private StartGame startGame;
   private float speed;

   private void Awake()
   {
      startGame = FindObjectOfType<StartGame>();
      rigidbody = GetComponent<Rigidbody>();
   }

   private void OnEnable()
   {
      startGame.GameStarted += OnStartMoving;
   }

   private void OnDisable()
   {
      startGame.GameStarted -= OnStartMoving;
   }

   private void FixedUpdate()
   {
      transform.position += Vector3.forward * speed * Time.fixedDeltaTime;
   }

   private void Update()
   {
      Move();
   }

   private void Move()
   {
      if (Input.GetKey(KeyCode.LeftArrow))
      {
         transform.position += Vector3.left * startSpeed * Time.deltaTime;
      }
      
      if (Input.GetKey(KeyCode.RightArrow))
      {
         transform.position += Vector3.right * startSpeed * Time.deltaTime;
      }

      
#if UNITY_ANDROID
      if (Input.touchCount > 0)
      {
         Touch touch = Input.GetTouch(0);

         if (touch.phase == TouchPhase.Moved)
         {
            rigidbody.velocity = new Vector3(touch.deltaPosition.x, rigidbody.velocity.y,
               rigidbody.velocity.z);
         }

         if (touch.phase == TouchPhase.Ended)
         {
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y,
               rigidbody.velocity.z);
         }
      }
#endif
   }

   private void OnStartMoving()
    {
      speed = startSpeed;
   }
}
