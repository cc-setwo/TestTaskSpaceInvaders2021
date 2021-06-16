using System.Collections.Generic;
using SpaceInvaders.Data;
using SpaceInvaders.Utils;
using UnityEngine;

namespace SpaceInvaders.Movement
{
    public class MovementController : Singleton<MovementController>, IInitializable
    {
        public bool IsInitialized { get; set; }

        private List<MovementBaseComponent> movementComponents;
        private Bounds movementBounds;

        public void AddComponent(MovementBaseComponent baseComponent)
        {
            if (movementComponents.Contains(baseComponent))
            {
                return;
            }

            DataMovementBase data = DataGameHolder.Instance.GetData<DataMovementBase>(baseComponent.GetType());
            baseComponent.Initialize(movementBounds, data);
            movementComponents.Add(baseComponent);
        }

        public void RemoveComponent(MovementBaseComponent baseComponent)
        {
            movementComponents.Remove(baseComponent);
        }

        public void Initialize()
        {
            Camera mainCamera = Camera.main;
            
            if (mainCamera == null)
            {
                Debug.LogError("MovementController -> Initialize Please set main camera!");
                return;
            }

            movementComponents = new List<MovementBaseComponent>();
            
            float screenAspect = Screen.width / (float) Screen.height;
            float cameraHeight = mainCamera.orthographicSize * 2;
            movementBounds = new Bounds(mainCamera.transform.position, new Vector3(cameraHeight * screenAspect, cameraHeight, 0));

            IsInitialized = true;
        }

        private void Update()
        {
            for (int i = 0; i < movementComponents.Count; i++)
            {
                movementComponents[i].OnMovementUpdate(Time.deltaTime);
            }
        }
    }
}