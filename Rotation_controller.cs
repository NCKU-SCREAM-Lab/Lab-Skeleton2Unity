using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bones_controller;
using static Transform__init__;
using static Torso_controller;
using static Left_hand_controller;
using static Left_leg_controller;
using static Right_hand_controller;
using static Right_leg_controller;
using static lab_skeleton;

public class Rotation_controller
{
    Torso_controller torso = new Torso_controller();
    Left_hand_controller l_hand_rotation = new Left_hand_controller();
    Right_hand_controller r_hand_rotation = new Right_hand_controller();
    Left_leg_controller l_leg_rotation = new Left_leg_controller();
    Right_leg_controller r_leg_rotation = new Right_leg_controller();


    // public void Rotation()
    // {
    //     // Torso
    //     torso.Torso_Rotation_controller();

    //     // Left hand
    //     l_hand_rotation.Left_hand_Rotation_controller();

    //     // Right hand
    //     r_hand_rotation.Right_hand_Rotation_controller();

    //     // Left foot
    //     l_leg_rotation.Left_leg_Rotation_controller();

    //     // Right foot
    //     r_leg_rotation.Right_leg_Rotation_controller();
    // }

    public void Lab_Rotation(int frame)
    {
        // Torso
        torso.Lab_Torso_Rotation_controller(frame);

        // Left hand
        l_hand_rotation.Lab_Left_hand_Rotation_controller(frame);

        // Right hand
        r_hand_rotation.Lab_Right_hand_Rotation_controller(frame);

        // Left foot
        l_leg_rotation.Lab_Left_leg_Rotation_controller(frame);

        // Right foot
        r_leg_rotation.Lab_Right_leg_Rotation_controller(frame);
    }
}