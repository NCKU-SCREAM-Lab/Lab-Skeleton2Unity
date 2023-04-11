using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bones_controller;
using static lab_skeleton;
using static unity_humanbones;

public class Left_hand_controller
{
    Bone_controller Controller = new Bone_controller();

    public void Lab_Left_hand_Rotation_controller(int frame)
    {
        // Left Shoulder Rotation
        unity_humanbones.L_Shoulder.Rotate(Controller.L_Shoulder_rotation(
            lab_skeleton.coordinate_list[frame, 5], 
            lab_skeleton.coordinate_list[frame, 6], 
            unity_humanbones.L_Elbow, 
            unity_humanbones.L_Shoulder
            ).eulerAngles, Space.World);

        // Left Elbow Rotation
        unity_humanbones.L_Elbow.Rotate(Controller.L_Elbow_rotation(
            lab_skeleton.coordinate_list[frame, 6], 
            lab_skeleton.coordinate_list[frame, 7], 
            unity_humanbones.L_Hand, 
            unity_humanbones.L_Elbow
            ).eulerAngles, Space.World);
    
        // Left Hand Rotation
        unity_humanbones.L_Hand.Rotate(Controller.L_Hand_rotation(
            lab_skeleton.coordinate_list[frame, 7], 
            lab_skeleton.coordinate_list[frame, 15],
            lab_skeleton.coordinate_list[frame, 16],
            unity_humanbones.L_Ring, 
            unity_humanbones.L_Hand, 
            unity_humanbones.L_Index
            ).eulerAngles, Space.World);

        unity_humanbones.L_Hand.Rotate(Controller.L_Hand_rotation2(
            lab_skeleton.coordinate_list[frame, 7], 
            lab_skeleton.coordinate_list[frame, 15], 
            unity_humanbones.L_Hand, 
            unity_humanbones.L_Index
            ).eulerAngles, Space.World);
    }
}