using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skieur_Descente : MonoBehaviour
{

    public KeyCode StopRotation;
        private bool canRotate = true;
        public float RotationSpeed;
        public float MoveSpeed;
        private MeshRenderer _meshRenderer;
        private Rigidbody _body;
    // Start is called before the first frame update
    void Start()
    
    {
         _meshRenderer = GetComponent<MeshRenderer>();
            _body = GetComponent<Rigidbody>();
        
    }
    // Update is called once per frame
    void Update()
        {
            //    Vector3 destination = new Vector3();
            //    // vous pouvez aussi utiliser getAxis pour des mouvements plus lisses
            //    if (Input.GetKey(KeyCode.Z)) destination += transform.forward;
            //    if (Input.GetKey(KeyCode.S)) destination -= transform.forward;
            //    if (Input.GetKey(KeyCode.D)) destination += transform.right;
            //    if (Input.GetKey(KeyCode.Q)) destination -= transform.right;

            //    //Je normalise destination sinon le cube se déplacera plus vite en diagonale
            //    destination = destination.normalized * Time.deltaTime * MoveSpeed;

            //    transform.position += destination;

            if (Input.GetKeyDown(StopRotation)) canRotate = !canRotate;
            //    if (canRotate)
            //    {
            //        if (Input.GetKey(KeyCode.A)) transform.Rotate(Vector3.up, -RotationSpeed * Time.deltaTime);
            //        if (Input.GetKey(KeyCode.E)) transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);
        }


        //Le cube a un rigidboy, dans l'idéal il faudrai donc le déplacer uniquement avec celui-ci, et donc utiliser le fixedUpdate
        public void FixedUpdate()
        {
            Vector3 destination = new Vector3();
            if (Input.GetKey(KeyCode.Z)) destination += transform.forward;
            if (Input.GetKey(KeyCode.S)) destination -= transform.forward;
            if (Input.GetKey(KeyCode.D)) destination += transform.right;
            if (Input.GetKey(KeyCode.Q)) destination -= transform.right;

            destination = destination.normalized * (MoveSpeed / 100f);

            _body.MovePosition(_body.position + destination);

            //if (Input.GetKeyDown(StopRotation)) canRotate = !canRotate;
            if (canRotate)
            {
                if (Input.GetKey(KeyCode.A)) _body.MoveRotation(_body.rotation * Quaternion.AngleAxis(RotationSpeed / 100f, Vector3.up));
                if (Input.GetKey(KeyCode.E)) _body.MoveRotation(_body.rotation * Quaternion.AngleAxis(-RotationSpeed / 100f, Vector3.up));
            }
        }

        public void OnMouseDown()
        {
            float r = Random.Range(0f, 1f);
            float g = Random.Range(0f, 1f);
            float b = Random.Range(0f, 1f);
            _meshRenderer.material.color = new Color(r, g, b);
        }
    }
  
  

