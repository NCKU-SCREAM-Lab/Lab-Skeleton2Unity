using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bones_controller;
// using static Transform__init__;
using static lab_skeleton;
using static unity_humanbones;

public class Right_hand_controller
{
    Bone_controller Controller = new Bone_controller();
    
    public void Lab_Right_hand_Rotation_controller(int frame)
    {
        // Right Shoulder Rotation
        unity_humanbones.R_Shoulder.Rotate(Controller.R_Shoulder_rotation(
            lab_skeleton.coordinate_list[frame, 2], 
            lab_skeleton.coordinate_list[frame, 3], 
            unity_humanbones.R_Elbow, 
            unity_humanbones.R_Shoulder
            ).eulerAngles, Space.World);

        // Right Elbow Rotation
        unity_humanbones.R_Elbow.Rotate(Controller.R_Elbow_rotation(
            lab_skeleton.coordinate_list[frame, 3], 
            lab_skeleton.coordinate_list[frame, 4], 
            unity_humanbones.R_Hand, 
            unity_humanbones.R_Elbow
            ).eulerAngles, Space.World);
    }
}