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
    
        // Left Hand was rotated to face the same orientation
        unity_humanbones.L_Hand.Rotate(Controller.L_Hand_rotation(
            lab_skeleton.coordinate_list[frame, 7], 
            lab_skeleton.coordinate_list[frame, 20],
            lab_skeleton.coordinate_list[frame, 26], 
            unity_humanbones.L_Ring_Proximal, 
            unity_humanbones.L_Hand, 
            unity_humanbones.L_Index_Proximal
            ).eulerAngles, Space.World);

        // Left Hand was rotated to same position 
        unity_humanbones.L_Hand.Rotate(Controller.L_Hand_rotation2(
            lab_skeleton.coordinate_list[frame, 7], 
            lab_skeleton.coordinate_list[frame, 20], 
            unity_humanbones.L_Hand, 
            unity_humanbones.L_Index_Proximal
            ).eulerAngles, Space.World);

        // left Finger Rotation
        // Thumb
        unity_humanbones.L_Thumb_Proximal.Rotate(Controller.L_Thumb_Proximal_rotation(
            lab_skeleton.coordinate_list[frame, 17], 
            lab_skeleton.coordinate_list[frame, 18], 
            unity_humanbones.L_Thumb_Proximal, 
            unity_humanbones.L_Thumb_Intermediate
            ).eulerAngles, Space.World);

        unity_humanbones.L_Thumb_Intermediate.Rotate(Controller.L_Thumb_Intermediate_rotation(
            lab_skeleton.coordinate_list[frame, 18], 
            lab_skeleton.coordinate_list[frame, 19], 
            unity_humanbones.L_Thumb_Intermediate, 
            unity_humanbones.L_Thumb_Distal
            ).eulerAngles, Space.World);

        unity_humanbones.L_Index_Proximal.Rotate(Controller.L_Index_Proximal_rotation(
            lab_skeleton.coordinate_list[frame, 20], 
            lab_skeleton.coordinate_list[frame, 21], 
            unity_humanbones.L_Index_Proximal, 
            unity_humanbones.L_Index_Intermediate
            ).eulerAngles, Space.World);

        // Index
        unity_humanbones.L_Index_Intermediate.Rotate(Controller.L_Index_Intermediate_rotation(
            lab_skeleton.coordinate_list[frame, 21], 
            lab_skeleton.coordinate_list[frame, 22], 
            unity_humanbones.L_Index_Intermediate, 
            unity_humanbones.L_Index_Distal
            ).eulerAngles, Space.World);

        unity_humanbones.L_Middle_Proximal.Rotate(Controller.L_Middle_Proximal_rotation(
            lab_skeleton.coordinate_list[frame, 23], 
            lab_skeleton.coordinate_list[frame, 24], 
            unity_humanbones.L_Middle_Proximal, 
            unity_humanbones.L_Middle_Intermediate
            ).eulerAngles, Space.World);

        // Middle
        unity_humanbones.L_Middle_Intermediate.Rotate(Controller.L_Middle_Intermediate_rotation(
            lab_skeleton.coordinate_list[frame, 24], 
            lab_skeleton.coordinate_list[frame, 25], 
            unity_humanbones.L_Middle_Intermediate, 
            unity_humanbones.L_Middle_Distal
            ).eulerAngles, Space.World);

        unity_humanbones.L_Ring_Proximal.Rotate(Controller.L_Ring_Proximal_rotation(
            lab_skeleton.coordinate_list[frame, 26], 
            lab_skeleton.coordinate_list[frame, 27], 
            unity_humanbones.L_Ring_Proximal, 
            unity_humanbones.L_Ring_Intermediate
            ).eulerAngles, Space.World);

        // Ring
        unity_humanbones.L_Ring_Intermediate.Rotate(Controller.L_Ring_Intermediate_rotation(
            lab_skeleton.coordinate_list[frame, 27], 
            lab_skeleton.coordinate_list[frame, 28], 
            unity_humanbones.L_Ring_Intermediate, 
            unity_humanbones.L_Ring_Distal
            ).eulerAngles, Space.World);

        // Little
        unity_humanbones.L_Little_Proximal.Rotate(Controller.L_Little_Proximal_rotation(
            lab_skeleton.coordinate_list[frame, 29], 
            lab_skeleton.coordinate_list[frame, 30], 
            unity_humanbones.L_Little_Proximal, 
            unity_humanbones.L_Little_Intermediate
            ).eulerAngles, Space.World);

        unity_humanbones.L_Little_Intermediate.Rotate(Controller.L_Little_Intermediate_rotation(
            lab_skeleton.coordinate_list[frame, 30], 
            lab_skeleton.coordinate_list[frame, 31], 
            unity_humanbones.L_Little_Intermediate,
            unity_humanbones.L_Little_Distal
            ).eulerAngles, Space.World);
    }
}