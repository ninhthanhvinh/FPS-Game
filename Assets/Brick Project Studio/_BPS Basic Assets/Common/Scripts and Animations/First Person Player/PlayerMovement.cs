using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SojaExiles

{
    public class PlayerMovement : MonoBehaviour
    {

        public float Speed = 5f;
        public float JumpHeight = 2f;
        public float GroundDistance = 0.2f;
        public float DashDistance = 5f;
        public LayerMask Ground;

        private Vector3 PlayerMovementInput;
        private Rigidbody _body;
        private bool _isGrounded = true;
        private Transform _groundChecker;

        void Start()
        {
            _body = GetComponent<Rigidbody>();
            _groundChecker = transform.GetChild(0);
        }

        void Update()
        {
            PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            
            
            _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                _body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            }
            if (Input.GetButtonDown("Dash"))
            {
                Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime)));
                _body.AddForce(dashVelocity, ForceMode.VelocityChange);
            }

           
        }


        void FixedUpdate()
        {
            //_body.MovePosition(_body.position + _inputs * Speed * Time.fixedDeltaTime);
            MoveCharacter();

        }

        public void MoveCharacter()
        {
            Vector3 moveVector = Speed  * transform.TransformDirection(PlayerMovementInput);
            _body.velocity = new(moveVector.x, _body.velocity.y, moveVector.z);
        }
    }
}