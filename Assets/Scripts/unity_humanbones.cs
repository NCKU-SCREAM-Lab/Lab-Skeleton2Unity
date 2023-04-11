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

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Set FPS: 30
        Application.targetFrameRate = 10;

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

        // Initial data
        Lab_skeleton.txt_reader();
    }
    // Update is called once per frame
    void Update()
    {
        if (count < lab_skeleton.coordinate_list.Length)
        {   
            Hip.localEulerAngles = new Vector3(0, 0, 0);
            Hip.Rotate(Controller.Hip_rotation(lab_skeleton.coordinate_list[count, 12], lab_skeleton.coordinate_list[count, 9]).eulerAngles);
            rotation_controller.Lab_Rotation(count);
        }
        count += 1;
    }
}
