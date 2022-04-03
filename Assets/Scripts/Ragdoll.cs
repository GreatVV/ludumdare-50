using System;
using System.Collections.Generic;
using UnityEngine;

namespace Client
{
    internal class Ragdoll : MonoBehaviour
    {
        public Animator Animator;
        public Rigidbody[] Rigidbodies;
        public Collider[] Colliders;
        public Collider[] TurnOffColliders;

        public struct RigidbodyStartPosition
        {
            public Rigidbody Rigidbody;
            public Vector3 Position;
            public Quaternion Rotation;
        }

        public List<RigidbodyStartPosition> _start = new List<RigidbodyStartPosition>();

        public void Start()
        {
            foreach (var r in Rigidbodies)
            {
                var position = new RigidbodyStartPosition();
                position.Rigidbody = r;
                position.Position = r.transform.localPosition;
                position.Rotation = r.transform.localRotation;
                _start.Add(position);
            }
        }

        public void TurnOnRagdoll(bool state)
        {
            Animator.enabled = !state;

            foreach (var r in Rigidbodies)
            {
                r.isKinematic = !state;
            }
                                                      
            foreach (var c in Colliders)
            {
                c.enabled = state;
            }

            foreach (var turnOffCollider in TurnOffColliders)
            {
                turnOffCollider.enabled = !state;
            }

            if (!state)
            {
                foreach (var rigidbodyStartPosition in _start)
                {
                    var rr = rigidbodyStartPosition.Rigidbody;
                    rr.transform.localPosition = rigidbodyStartPosition.Position;
                    rr.transform.localRotation = rigidbodyStartPosition.Rotation;
                }
            }
        }
    }
}