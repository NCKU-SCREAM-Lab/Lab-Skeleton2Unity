using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanBodyTransform : MonoBehaviour
{

    // Animator animation;

    public Transform Head;
    public Transform Neck;
    public Transform Spine;
	public Transform Hip;

    // Left hand
    public Transform L_Shoulder;
    public Transform L_Elbow;
    public Transform L_Hand;
    public Transform L_Toe;
    public Transform L_Ring;
    public Transform L_Index;

    // Left leg
    public Transform L_Hip;
    public Transform L_Knee;
    public Transform L_Foot;

    // Right hand
    public Transform R_Shoulder;
    public Transform R_Elbow;
    public Transform R_Hand;
    public Transform R_Toe;
    public Transform R_Ring;
    public Transform R_Index;

    // Right leg
    public  Transform R_Hip;
    public  Transform R_Knee;
    public  Transform R_Foot;

    public HumanBodyTransform(Animator animations)
    {
        Application.targetFrameRate = 10;
        Animator animation = animations;

        Head = animation.GetBoneTransform(HumanBodyBones.Head);
        Neck = animation.GetBoneTransform(HumanBodyBones.Neck);
        Spine = animation.GetBoneTransform(HumanBodyBones.Spine);
		Hip = animation.GetBoneTransform(HumanBodyBones.Hips);

        L_Shoulder = animation.GetBoneTransform(HumanBodyBones.LeftUpperArm);
        L_Elbow = animation.GetBoneTransform(HumanBodyBones.LeftLowerArm);
        L_Hand = animation.GetBoneTransform(HumanBodyBones.LeftHand);
        L_Toe = animation.GetBoneTransform(HumanBodyBones.LeftToes);
        L_Ring = animation.GetBoneTransform(HumanBodyBones.LeftRingProximal);
        L_Index = animation.GetBoneTransform(HumanBodyBones.LeftIndexProximal);

        L_Hip = animation.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
        L_Knee = animation.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
        L_Foot = animation.GetBoneTransform(HumanBodyBones.LeftFoot);

        R_Shoulder = animation.GetBoneTransform(HumanBodyBones.RightUpperArm);
        R_Elbow = animation.GetBoneTransform(HumanBodyBones.RightLowerArm);
        R_Hand = animation.GetBoneTransform(HumanBodyBones.RightHand);
        R_Toe = animation.GetBoneTransform(HumanBodyBones.RightToes);
        R_Ring = animation.GetBoneTransform(HumanBodyBones.RightRingProximal);
        R_Index = animation.GetBoneTransform(HumanBodyBones.RightIndexProximal);

        R_Hip = animation.GetBoneTransform(HumanBodyBones.RightUpperLeg);
        R_Knee = animation.GetBoneTransform(HumanBodyBones.RightLowerLeg);
        R_Foot = animation.GetBoneTransform(HumanBodyBones.RightFoot);
    }
}