using System;
using System.Collections.Generic;
using UnityEngine;

namespace Bones_controller
{
    public class Bone_controller
    {

        // spine
        public Quaternion Head_rotation(Vector3 mouth_l, Vector3 mouth_r, Vector3 nose, Vector3 shoulder_l, Vector3 shoulder_r)
        {
            var vec1 = shoulder_r - shoulder_l;
            var vec2 = mouth_r - mouth_l;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion Hip_rotation(Vector3 hip_l, Vector3 hip_r)
        {
            var vec1 = Vector3.right;
            var vec2 = hip_r - hip_l;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion Spine_rotation(Vector3 hip_l, Vector3 hip_r, Vector3 shoulder_l, Vector3 shoulder_r, Transform leftShoulder, Transform rightShoulder, Transform leftHip, Transform rightHip)
        {
            var hip_m = Vector3.Lerp(hip_l, hip_r, 1 / 2);
            var shoulder_m = Vector3.Lerp(shoulder_l, shoulder_r, 1 / 2);

            var vec1 = Vector3.Lerp(leftShoulder.position, rightShoulder.position, 1 / 2) - Vector3.Lerp(leftHip.position, rightHip.position, 1 / 2);
            var vec2 = shoulder_m - hip_m;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        // Right body
        public Quaternion R_Shoulder_rotation(Vector3 shoulder_r, Vector3 elbow_r, Transform rightElbow, Transform rightShoulder)
        {
            var vec1 = rightElbow.position - rightShoulder.position;
            var vec2 = elbow_r - shoulder_r;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion R_Elbow_rotation(Vector3 elbow_r, Vector3 wrist_r, Transform rightHand, Transform rightElbow)
        {
            var vec1 = rightHand.position - rightElbow.position;
            var vec2 = wrist_r - elbow_r;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion R_Hand_rotation(Vector3 wrist_r, Vector3 index_r, Vector3 pinky_r, Transform RightRingProximal, Transform rightHand, Transform RightIndexProximal)
        {
            var vec1 = Vector3.Cross((RightRingProximal.position - rightHand.position), (RightIndexProximal.position - rightHand.position));
            var vec2 = Vector3.Cross((pinky_r - wrist_r), (index_r - wrist_r));

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion R_UpperLeg_rotation(Vector3 hip_r, Vector3 knee_r, Transform rightKnee, Transform rightHip)
        {
            var vec1 = rightKnee.position - rightHip.position;
            var vec2 = knee_r - hip_r;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion R_Knee_rotation( Vector3 knee_r, Vector3 ankle_r, Transform rightFoot, Transform rightKnee)
        {
            var vec1 = rightFoot.position - rightKnee.position;
            var vec2 = ankle_r - knee_r;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion R_Foot_rotation(Vector3 knee_r, Vector3 ankle_r, Vector3 toe_r, Transform rightToe, Transform rightFoot, Transform rightKnee)
        {
            var vec1 = Vector3.Cross((rightToe.position - rightFoot.position), (rightKnee.position - rightFoot.position));
            var vec2 = Vector3.Cross((toe_r - ankle_r), (knee_r - ankle_r));

            return Quaternion.FromToRotation(vec1, vec2);
        }

        // Left body
        public Quaternion L_Shoulder_rotation(Vector3 shoulder_l, Vector3 elbow_l, Transform leftElbow, Transform leftShoulder)
        {
            var vec1 = leftElbow.position - leftShoulder.position;
            var vec2 = elbow_l - shoulder_l;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion L_Elbow_rotation(Vector3 elbow_l, Vector3 wrist_l, Transform leftHand, Transform leftElbow)
        {
            var vec1 = leftHand.position - leftElbow.position;
            var vec2 = wrist_l - elbow_l;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion L_Hand_rotation(Vector3 wrist_l, Vector3 index_l, Vector3 pinky_l, Transform LeftRingProximal, Transform leftHand, Transform LeftIndexProximal)
        {
            var vec1 = Vector3.Cross((LeftIndexProximal.position - leftHand.position), (LeftRingProximal.position - leftHand.position));
            var vec2 = Vector3.Cross((index_l - wrist_l), (pinky_l - wrist_l));

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion L_UpperLeg_rotation(Vector3 hip_l, Vector3 knee_l, Transform leftKnee, Transform leftHip)
        {
            var vec1 = leftKnee.position - leftHip.position;
            var vec2 = knee_l - hip_l;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion L_Knee_rotation(Vector3 knee_l, Vector3 ankle_l, Transform leftKnee, Transform leftFoot)
        {
            var vec1 = leftFoot.position - leftKnee.position;
            var vec2 = ankle_l - knee_l;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion L_Foot_rotation(Vector3 knee_l, Vector3 ankle_l, Vector3 toe_l, Transform leftToe, Transform leftFoot, Transform leftKnee)
        {
            var vec1 = Vector3.Cross((leftToe.position - leftFoot.position), (leftKnee.position - leftFoot.position));
            var vec2 = Vector3.Cross((toe_l - ankle_l), (knee_l - ankle_l));

            return Quaternion.FromToRotation(vec1, vec2);
        }
    }
}