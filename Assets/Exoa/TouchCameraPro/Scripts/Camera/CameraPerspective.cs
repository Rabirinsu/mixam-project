using Codice.CM.Common.Serialization.Replication;
using Exoa.Common;
using Exoa.Designer;
using Exoa.Events;
using Exoa.Touch;
using System.Collections.Generic;
using UnityEngine;


namespace Exoa.Cameras
{
    public class CameraPerspective : CameraPerspBase, ITouchPerspCamera
    {
        /// <summary>
        /// Init some camera parameters
        /// </summary>
        [SerializeField] private GameObject model;
        [SerializeField] private Camera _cam;

        private void Awake()
        {
            _cam.rect = new Rect(0.5f, 0f, 0.5f, 1f);
        }
        override protected void Init()
        {
            base.Init();

            // Calculating the initial parameters based on camera's transform
            initialRotation = transform.rotation.eulerAngles;
            GetInitialRotation();
            initDistance = CalculateDistance(transform.position, transform.rotation);
            initOffset = CalculateOffset(transform.position, transform.rotation, initDistance, groundHeight);

            currentPitch = initialRotation.x;
            currentYaw = initialRotation.y;

            finalOffset = initOffset;
            finalDistance = CalculateClampedDistance(initDistance, minMaxDistance);
            finalRotation = GetRotationFromPitchYaw();
            finalPosition = CalculatePosition(finalOffset, finalRotation, finalDistance);


        }

        public void SetRotate()
        {
            oneFingerDrag = InputMapFingerDrag.RotateAround;
        } 
        public void SetPan()
        {
            oneFingerDrag = InputMapFingerDrag.Translate;
        } 
        public void SetZoom()
        {
            oneFingerDrag = InputMapFingerDrag.None;
        }
        public void SetFollowState()
        {
           // CameraEvents.OnRequestObjectFollow?.Invoke(model, false, false);
        }
        /// <summary>
        /// Gives the initial rotation of the camera to be able to reset it later
        /// </summary>
        /// <returns></returns>
        override protected Quaternion GetInitialRotation()
        {
            initRotation = Quaternion.Euler(initialRotation.x, initialRotation.y, 0);
            return initRotation;
        }

        /// <summary>
        /// Set the initial values for the reset function
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="rotation"></param>
        /// <param name="distanceOrSize"></param>
        override public void SetResetValues(Vector3 offset, Quaternion rotation, float distance)
        {
            initOffset = offset;
            initDistance = distance;
            initialRotation = rotation.eulerAngles;
            GetInitialRotation();
            //Log("SetResetValues initOffset:" + initOffset);
        }

        /// <summary>
        /// Reset the camera to initial values
        /// </summary>
        override public void ResetCamera()
        {
            StopFollow();
            FocusCamera(initOffset, initDistance, initRotation.eulerAngles);
        }
      

        #region EVENTS
        /// <summary>
        /// Called just before the perspective switch happens
        /// </summary>
        /// <param name="orthoMode"></param>
        override protected void OnBeforeSwitchPerspective(bool orthoMode)
        {
            if (!orthoMode)
            {
                currentPitch = initialRotation.x;
                currentYaw = initialRotation.y;
                finalRotation = GetRotationFromPitchYaw();
                finalPosition = CalculatePosition(finalOffset, finalRotation, finalDistance);
            }
        }

        #endregion




    }
}