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

        public Quaternion R_Hand_rotation2(Vector3 wrist_r, Vector3 index_r, Transform rightHand, Transform RightIndexProximal)
        {
            var vec1 = RightIndexProximal.position - rightHand.position;
            var vec2 = index_r - wrist_r;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion R_Thumb_Proximal_rotation(Vector3 thumb1_r, Vector3 thumb2_r, Transform RightThumb1, Transform RightThumb2)
        {
            var vec1 = RightThumb2.position - RightThumb1.position;
            var vec2 = thumb2_r - thumb1_r;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion R_Thumb_Intermediate_rotation(Vector3 thumb2_r, Vector3 thumb3_r, Transform RightThumb2, Transform RightThumb3)
        {
            var vec1 = RightThumb3.position - RightThumb2.position;
            var vec2 = thumb3_r - thumb2_r;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion R_Index_Proximal_rotation(Vector3 index1_r, Vector3 index2_r, Transform RightIndex1, Transform RightIndex2)
        {
            var vec1 = RightIndex2.position - RightIndex1.position;
            var vec2 = index2_r - index1_r;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion R_Index_Intermediate_rotation(Vector3 index2_r, Vector3 index3_r, Transform RightIndex2, Transform RightIndex3)
        {
            var vec1 = RightIndex3.position - RightIndex2.position;
            var vec2 = index3_r - index2_r;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion R_Middle_Proximal_rotation(Vector3 middle1_r, Vector3 middle2_r, Transform RightMiddle1, Transform RightMiddle2)
        {
            var vec1 = RightMiddle2.position - RightMiddle1.position;
            var vec2 = middle2_r - middle1_r;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion R_Middle_Intermediate_rotation(Vector3 middle2_r, Vector3 middle3_r, Transform RightMiddle2, Transform RightMiddle3)
        {
            var vec1 = RightMiddle3.position - RightMiddle2.position;
            var vec2 = middle3_r - middle2_r;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion R_Ring_Proximal_rotation(Vector3 ring1_r, Vector3 ring2_r, Transform RightRing1, Transform RightRing2)
        {
            var vec1 = RightRing2.position - RightRing1.position;
            var vec2 = ring2_r - ring1_r;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion R_Ring_Intermediate_rotation(Vector3 ring2_r, Vector3 ring3_r, Transform RightRing2, Transform RightRing3)
        {
            var vec1 = RightRing3.position - RightRing2.position;
            var vec2 = ring3_r - ring2_r;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion R_Little_Proximal_rotation(Vector3 little1_r, Vector3 little2_r, Transform RightLittle1, Transform RightLittle2)
        {
            var vec1 = RightLittle2.position - RightLittle1.position;
            var vec2 = little2_r - little1_r;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion R_Little_Intermediate_rotation(Vector3 little2_r, Vector3 little3_r, Transform RightLittle2, Transform RightLittle3)
        {
            var vec1 = RightLittle3.position - RightLittle2.position;
            var vec2 = little3_r - little2_r;

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

        public Quaternion L_Hand_rotation2(Vector3 wrist_l, Vector3 index_l, Transform LeftHand, Transform LeftIndexProximal)
        {
            var vec1 = LeftIndexProximal.position - LeftHand.position;
            var vec2 = index_l - wrist_l;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion L_Thumb_Proximal_rotation(Vector3 thumb1_l, Vector3 thumb2_l, Transform LeftThumb1, Transform LeftThumb2)
        {
            var vec1 = LeftThumb2.position - LeftThumb1.position;
            var vec2 = thumb2_l - thumb1_l;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion L_Thumb_Intermediate_rotation(Vector3 thumb2_l, Vector3 thumb3_l, Transform LeftThumb2, Transform LeftThumb3)
        {
            var vec1 = LeftThumb3.position - LeftThumb2.position;
            var vec2 = thumb3_l - thumb2_l;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion L_Index_Proximal_rotation(Vector3 index1_l, Vector3 index2_l, Transform LeftIndex1, Transform LeftIndex2)
        {
            var vec1 = LeftIndex2.position - LeftIndex1.position;
            var vec2 = index2_l - index1_l;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion L_Index_Intermediate_rotation(Vector3 index2_l, Vector3 index3_l, Transform LeftIndex2, Transform LeftIndex3)
        {
            var vec1 = LeftIndex3.position - LeftIndex2.position;
            var vec2 = index3_l - index2_l;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion L_Middle_Proximal_rotation(Vector3 middle1_l, Vector3 middle2_l, Transform LeftMiddle1, Transform LeftMiddle2)
        {
            var vec1 = LeftMiddle2.position - LeftMiddle1.position;
            var vec2 = middle2_l - middle1_l;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion L_Middle_Intermediate_rotation(Vector3 middle2_l, Vector3 middle3_l, Transform LeftMiddle2, Transform LeftMiddle3)
        {
            var vec1 = LeftMiddle3.position - LeftMiddle2.position;
            var vec2 = middle3_l - middle2_l;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion L_Ring_Proximal_rotation(Vector3 ring1_l, Vector3 ring2_l, Transform LeftRing1, Transform LeftRing2)
        {
            var vec1 = LeftRing2.position - LeftRing1.position;
            var vec2 = ring2_l - ring1_l;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion L_Ring_Intermediate_rotation(Vector3 ring2_l, Vector3 ring3_l, Transform LeftRing2, Transform LeftRing3)
        {
            var vec1 = LeftRing3.position - LeftRing2.position;
            var vec2 = ring3_l - ring2_l;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion L_Little_Proximal_rotation(Vector3 little1_l, Vector3 little2_l, Transform LeftLittle1, Transform LeftLittle2)
        {
            var vec1 = LeftLittle2.position - LeftLittle1.position;
            var vec2 = little2_l - little1_l;

            return Quaternion.FromToRotation(vec1, vec2);
        }

        public Quaternion L_Little_Intermediate_rotation(Vector3 little2_l, Vector3 little3_l, Transform LeftLittle2, Transform LeftLittle3)
        {
            var vec1 = LeftLittle3.position - LeftLittle2.position;
            var vec2 = little3_l - little2_l;

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