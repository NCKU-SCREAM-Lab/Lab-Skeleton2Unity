using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Bones_controller;
using static lab_skeleton;
using static Rotation_controller;

public class unity_humanbones : MonoBehaviour
{
    lab_skeleton Lab_skeleton = new lab_skeleton();
    Rotation_controller rotation_controller = new Rotation_controller();
    Bone_controller Controller = new Bone_controller();

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
    public static Transform L_Thumb_Proximal;
    public static Transform L_Thumb_Intermediate;
    public static Transform L_Thumb_Distal;
    public static Transform L_Index_Proximal;
    public static Transform L_Index_Intermediate;
    public static Transform L_Index_Distal;
    public static Transform L_Middle_Proximal;
    public static Transform L_Middle_Intermediate;
    public static Transform L_Middle_Distal;
    public static Transform L_Ring_Proximal;
    public static Transform L_Ring_Intermediate;
    public static Transform L_Ring_Distal;
    public static Transform L_Little_Proximal;
    public static Transform L_Little_Intermediate;
    public static Transform L_Little_Distal;

    // Left leg
    public static Transform L_Hip;
    public static Transform L_Knee;
    public static Transform L_Foot;
    public static Transform L_Toe;

    // Right hand
    public static Transform R_Shoulder;
    public static Transform R_Elbow;
    public static Transform R_Hand;
    public static Transform R_Thumb_Proximal;
    public static Transform R_Thumb_Intermediate;
    public static Transform R_Thumb_Distal;
    public static Transform R_Index_Proximal;
    public static Transform R_Index_Intermediate;
    public static Transform R_Index_Distal;
    public static Transform R_Middle_Proximal;
    public static Transform R_Middle_Intermediate;
    public static Transform R_Middle_Distal;
    public static Transform R_Ring_Proximal;
    public static Transform R_Ring_Intermediate;
    public static Transform R_Ring_Distal;
    public static Transform R_Little_Proximal;
    public static Transform R_Little_Intermediate;
    public static Transform R_Little_Distal;

    // Right leg
    public static Transform R_Hip;
    public static Transform R_Knee;
    public static Transform R_Foot;
    public static Transform R_Toe;

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Set FPS: 30
        Application.targetFrameRate = 10;

        // linking humanoid fbx bones
        animation = GetComponent<Animator>();

        Head = animation.GetBoneTransform(HumanBodyBones.Head);
        Neck = animation.GetBoneTransform(HumanBodyBones.Neck);
        Spine = animation.GetBoneTransform(HumanBodyBones.Spine);
		Hip = animation.GetBoneTransform(HumanBodyBones.Hips);

        L_Shoulder = animation.GetBoneTransform(HumanBodyBones.LeftUpperArm);
        L_Elbow = animation.GetBoneTransform(HumanBodyBones.LeftLowerArm);
        L_Hand = animation.GetBoneTransform(HumanBodyBones.LeftHand);
        L_Toe = animation.GetBoneTransform(HumanBodyBones.LeftToes);
        
        L_Thumb_Proximal = animation.GetBoneTransform(HumanBodyBones.LeftThumbProximal);
        L_Thumb_Intermediate = animation.GetBoneTransform(HumanBodyBones.LeftThumbIntermediate);
        L_Thumb_Distal = animation.GetBoneTransform(HumanBodyBones.LeftThumbDistal);
        L_Index_Proximal = animation.GetBoneTransform(HumanBodyBones.LeftIndexProximal);
        L_Index_Intermediate = animation.GetBoneTransform(HumanBodyBones.LeftIndexIntermediate);
        L_Index_Distal = animation.GetBoneTransform(HumanBodyBones.LeftIndexDistal);
        L_Middle_Proximal = animation.GetBoneTransform(HumanBodyBones.LeftMiddleProximal);
        L_Middle_Intermediate = animation.GetBoneTransform(HumanBodyBones.LeftMiddleIntermediate);
        L_Middle_Distal = animation.GetBoneTransform(HumanBodyBones.LeftMiddleDistal);
        L_Ring_Proximal = animation.GetBoneTransform(HumanBodyBones.LeftRingProximal);
        L_Ring_Intermediate = animation.GetBoneTransform(HumanBodyBones.LeftRingIntermediate);
        L_Ring_Distal = animation.GetBoneTransform(HumanBodyBones.LeftRingDistal);
        L_Little_Proximal = animation.GetBoneTransform(HumanBodyBones.LeftLittleProximal);
        L_Little_Intermediate = animation.GetBoneTransform(HumanBodyBones.LeftLittleIntermediate);
        L_Little_Distal = animation.GetBoneTransform(HumanBodyBones.LeftLittleDistal);

        L_Hip = animation.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
        L_Knee = animation.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
        L_Foot = animation.GetBoneTransform(HumanBodyBones.LeftFoot);

        R_Shoulder = animation.GetBoneTransform(HumanBodyBones.RightUpperArm);
        R_Elbow = animation.GetBoneTransform(HumanBodyBones.RightLowerArm);
        R_Hand = animation.GetBoneTransform(HumanBodyBones.RightHand);
        R_Toe = animation.GetBoneTransform(HumanBodyBones.RightToes);

        R_Thumb_Proximal = animation.GetBoneTransform(HumanBodyBones.RightThumbProximal);
        R_Thumb_Intermediate = animation.GetBoneTransform(HumanBodyBones.RightThumbIntermediate);
        R_Thumb_Distal = animation.GetBoneTransform(HumanBodyBones.RightThumbDistal);
        R_Index_Proximal = animation.GetBoneTransform(HumanBodyBones.RightIndexProximal);
        R_Index_Intermediate = animation.GetBoneTransform(HumanBodyBones.RightIndexIntermediate);
        R_Index_Distal = animation.GetBoneTransform(HumanBodyBones.RightIndexDistal);
        R_Middle_Proximal = animation.GetBoneTransform(HumanBodyBones.RightMiddleProximal);
        R_Middle_Intermediate = animation.GetBoneTransform(HumanBodyBones.RightMiddleIntermediate);
        R_Middle_Distal = animation.GetBoneTransform(HumanBodyBones.RightMiddleDistal);
        R_Ring_Proximal = animation.GetBoneTransform(HumanBodyBones.RightRingProximal);
        R_Ring_Intermediate = animation.GetBoneTransform(HumanBodyBones.RightRingIntermediate);
        R_Ring_Distal = animation.GetBoneTransform(HumanBodyBones.RightRingDistal);
        R_Little_Proximal = animation.GetBoneTransform(HumanBodyBones.RightLittleProximal);
        R_Little_Intermediate = animation.GetBoneTransform(HumanBodyBones.RightLittleIntermediate);
        R_Little_Distal = animation.GetBoneTransform(HumanBodyBones.RightLittleDistal);

        R_Hip = animation.GetBoneTransform(HumanBodyBones.RightUpperLeg);
        R_Knee = animation.GetBoneTransform(HumanBodyBones.RightLowerLeg);
        R_Foot = animation.GetBoneTransform(HumanBodyBones.RightFoot);

        // Initial data
        Lab_skeleton.txt_reader();
    }
    // Update is called once per frame
    void Update()
    {
        if (count < lab_skeleton.coordinate_list.Length)
        {   
            Hip.localEulerAngles = new Vector3(0, 0, 0);
            Hip.Rotate(Controller.Hip_rotation(lab_skeleton.coordinate_list[count, 12], lab_skeleton.coordinate_list[count, 9]).eulerAngles, Space.World);
            rotation_controller.Lab_Rotation(count);
        }
        count += 1;
    }
}
