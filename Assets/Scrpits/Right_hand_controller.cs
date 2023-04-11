using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bones_controller;
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
    
        // Right Hand was rotated to face the same orientation
        unity_humanbones.R_Hand.Rotate(Controller.R_Hand_rotation(
            lab_skeleton.coordinate_list[frame, 4], 
            lab_skeleton.coordinate_list[frame, 35], 
            lab_skeleton.coordinate_list[frame, 41], 
            unity_humanbones.R_Ring_Proximal, 
            unity_humanbones.R_Hand, 
            unity_humanbones.R_Index_Proximal
            ).eulerAngles, Space.World);

        // Right Hand was rotated to same position 
        unity_humanbones.R_Hand.Rotate(Controller.R_Hand_rotation2(
            lab_skeleton.coordinate_list[frame, 4], 
            lab_skeleton.coordinate_list[frame, 35], 
            unity_humanbones.R_Hand, 
            unity_humanbones.R_Index_Proximal
            ).eulerAngles, Space.World);

        // Right Finger Rotation
        // Thumb
        unity_humanbones.R_Thumb_Proximal.Rotate(Controller.R_Thumb_Proximal_rotation(
            lab_skeleton.coordinate_list[frame, 32], 
            lab_skeleton.coordinate_list[frame, 33], 
            unity_humanbones.R_Thumb_Proximal, 
            unity_humanbones.R_Thumb_Intermediate
            ).eulerAngles, Space.World);

        unity_humanbones.R_Thumb_Intermediate.Rotate(Controller.R_Thumb_Intermediate_rotation(
            lab_skeleton.coordinate_list[frame, 33], 
            lab_skeleton.coordinate_list[frame, 34], 
            unity_humanbones.R_Thumb_Intermediate, 
            unity_humanbones.R_Thumb_Distal
            ).eulerAngles, Space.World);

        // Index
        unity_humanbones.R_Index_Proximal.Rotate(Controller.R_Index_Proximal_rotation(
            lab_skeleton.coordinate_list[frame, 35], 
            lab_skeleton.coordinate_list[frame, 36], 
            unity_humanbones.R_Index_Proximal, 
            unity_humanbones.R_Index_Intermediate
            ).eulerAngles, Space.World);

        unity_humanbones.R_Index_Intermediate.Rotate(Controller.R_Index_Intermediate_rotation(
            lab_skeleton.coordinate_list[frame, 36], 
            lab_skeleton.coordinate_list[frame, 37], 
            unity_humanbones.R_Index_Intermediate, 
            unity_humanbones.R_Index_Distal
            ).eulerAngles, Space.World);
            
        // Middle
        unity_humanbones.R_Middle_Proximal.Rotate(Controller.R_Middle_Proximal_rotation(
            lab_skeleton.coordinate_list[frame, 38], 
            lab_skeleton.coordinate_list[frame, 39], 
            unity_humanbones.R_Middle_Proximal, 
            unity_humanbones.R_Middle_Intermediate
            ).eulerAngles, Space.World);

        unity_humanbones.R_Middle_Intermediate.Rotate(Controller.R_Middle_Intermediate_rotation(
            lab_skeleton.coordinate_list[frame, 39], 
            lab_skeleton.coordinate_list[frame, 40], 
            unity_humanbones.R_Middle_Intermediate, 
            unity_humanbones.R_Middle_Distal
            ).eulerAngles, Space.World);

        // Ring
        unity_humanbones.R_Ring_Proximal.Rotate(Controller.R_Ring_Proximal_rotation(
            lab_skeleton.coordinate_list[frame, 41], 
            lab_skeleton.coordinate_list[frame, 42], 
            unity_humanbones.R_Ring_Proximal, 
            unity_humanbones.R_Ring_Intermediate
            ).eulerAngles, Space.World);

        unity_humanbones.R_Ring_Intermediate.Rotate(Controller.R_Ring_Intermediate_rotation(
            lab_skeleton.coordinate_list[frame, 42], 
            lab_skeleton.coordinate_list[frame, 43], 
            unity_humanbones.R_Ring_Intermediate, 
            unity_humanbones.R_Ring_Distal
            ).eulerAngles, Space.World);

        // Little
        unity_humanbones.R_Little_Proximal.Rotate(Controller.R_Little_Proximal_rotation(
            lab_skeleton.coordinate_list[frame, 44], 
            lab_skeleton.coordinate_list[frame, 45], 
            unity_humanbones.R_Little_Proximal, 
            unity_humanbones.R_Little_Intermediate
            ).eulerAngles, Space.World);

        unity_humanbones.R_Little_Intermediate.Rotate(Controller.R_Little_Intermediate_rotation(
            lab_skeleton.coordinate_list[frame, 45], 
            lab_skeleton.coordinate_list[frame, 46], 
            unity_humanbones.R_Little_Intermediate, 
            unity_humanbones.R_Little_Distal
            ).eulerAngles, Space.World);
    }
}