using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class Transform__init__ : MonoBehaviour
{
    Animator animation;

    // torso
    public static Transform Head;
    public static Transform Neck;
    public static Transform Spine;
	public static Transform Hip;

    // Left hand
    public static Transform L_Shoulder;
    public static Transform L_Elbow;
    public static Transform L_Hand;
    public static Transform L_Toe;
    public static Transform L_Ring;
    public static Transform L_Index;

    // Left leg
    public static Transform L_Hip;
    public static Transform L_Knee;
    public static Transform L_Foot;

    // Right hand
    public static Transform R_Shoulder;
    public static Transform R_Elbow;
    public static Transform R_Hand;
    public static Transform R_Toe;
    public static Transform R_Ring;
    public static Transform R_Index;

    // Right leg
    public static Transform R_Hip;
    public static Transform R_Knee;
    public static Transform R_Foot;

    public void Bones_initialize()
    {
        animation = GetComponent<Animator>();

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