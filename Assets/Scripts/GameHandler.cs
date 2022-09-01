using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class GameHandler : MonoBehaviour
    {
        //camera variables
        public Transform cameraManualMovementTransform;
        public CameraFollow cameraFollow;
        private Vector3 cameraFollowPosition = new Vector3(-60, 120, 0);
        private float zoom = 10f;



        private void Start()
        {
            cameraFollow.Setup(() => cameraFollowPosition, () => zoom);
            

        }

        private void Update()
        {
            //camera functions
            HandleEdgeScrolling ();
            HandleZoom();

        }







        float zoomMax = 100f;
        private void HandleZoom()
        {
            float zoomChangeAmount = 30f;
            if (Input.mouseScrollDelta.y > 0) {
                zoom -= zoomChangeAmount * Time.deltaTime * 5f;
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                zoom += zoomChangeAmount * Time.deltaTime * 10f;
            }
            if (zoom < 5)
            {
                zoom = 5f;
            }
            if (zoom  > zoomMax)
            {
                zoom = zoomMax;
            }
        }

        
        private void HandleEdgeScrolling()
        {
            float zoomupLimit = 279f;
            float moveAmount = 5f;
            float edgesize = 30f;
            if (Input.mousePosition.x > Screen.width - edgesize)
            {
                //edgeright
                cameraFollowPosition.x += 10 * moveAmount * Time.deltaTime * zoom / zoomMax;
            }
            if (Input.mousePosition.x < edgesize)
            {
                //edgeleft
                cameraFollowPosition.x -= 10 * moveAmount * Time.deltaTime * zoom / zoomMax;
            }
            if (Input.mousePosition.y > Screen.height - edgesize && Camera.main.transform.position.y < zoomupLimit - zoom)
            {
                //edgeup
                cameraFollowPosition.y += 10 * moveAmount * Time.deltaTime * zoom / zoomMax;
            }
            if (Input.mousePosition.y < edgesize && Camera.main.transform.position.y > -zoomupLimit + zoom)
            {
                //edgedown
                cameraFollowPosition.y -= 10 * moveAmount * Time.deltaTime * zoom / zoomMax;
            }



            // camera limits updown and camera side moves
            if (Camera.main.transform.position.y < -zoomupLimit + zoom)
            {
                cameraFollowPosition.y = -(zoomupLimit - 1) + zoom;
            }
            if (Camera.main.transform.position.y > zoomupLimit - zoom)
            {
                cameraFollowPosition.y = (zoomupLimit - 1) - zoom;
            }
            if (Camera.main.transform.position.x < -34.73 * 16.66666)
            {
                cameraFollowPosition.x = 30f * 16.66666f;
            }
            if (Camera.main.transform.position.x > 30 * 16.66666)
            {
                cameraFollowPosition.x = -34.73f * 16.66666f;

            

            }
        }
    }
