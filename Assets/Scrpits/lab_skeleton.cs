using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Bones_controller;


public class lab_skeleton : MonoBehaviour
{
    /*
    skeleton list define:
    {
        0: head, 1: neck, 2: R_shoulder, 3: R_Elbow, 4: R_hand,
        5: L_shoulder, 6: L_Elbow, 7: L_hand, 8: hip, 9: R_hip,
        10: R_knee, 11: R_foot, 12: L_hip, 13: L_knee, 14: L_foot,
        15: 'LeftToeBase', 16: 'RightToeBase',
        17: 'LeftHandThumb1', 18: 'LeftHandThumb2', 19: 'LeftHandThumb3', 
        20: 'LeftHandIndex1', 21: 'LeftHandIndex2', 22: 'LeftHandIndex3', 
        23: 'LeftHandMiddle1', 24: 'LeftHandMiddle2', 25: 'LeftHandMiddle3', 
        26: 'LeftHandRing1', 27: 'LeftHandRing2', 28: 'LeftHandRing3', 
        29: 'LeftHandPinky1', 30: 'LeftHandPinky2', 31: 'LeftHandPinky3', 
        32: 'RightHandThumb1', 33: 'RightHandThumb2', 34: 'RightHandThumb3', 
        35: 'RightHandIndex1', 36: 'RightHandIndex2', 37: 'RightHandIndex3', 
        38: 'RightHandMiddle1', 39: 'RightHandMiddle2', 40: 'RightHandMiddle3', 
        41: 'RightHandRing1', 42: 'RightHandRing2', 43: 'RightHandRing3', 
        44: 'RightHandPinky1', 45: 'RightHandPinky2', 46: 'RightHandPinky3'
    }
    */
    public static string coordinate_txt_path = @"/Lab_skeleton2unity_with_finger/Assets/Motion data/1075@014_withfinger.txt";
    public static string[] coordinate_lines = File.ReadAllLines(coordinate_txt_path);
    public static Vector3[,] coordinate_list = new Vector3[coordinate_lines.Length, 47];

    public void txt_reader()
    {
        int count = 0;
        int sub_count = 0;
        foreach (var item in coordinate_lines)
        {
            string[] subs = item.Split(',');
            sub_count = 0;
            foreach (var pos in subs)
            {
                string[] temp = pos.Split(' ');
                coordinate_list[count, sub_count] = new Vector3((float)Convert.ToDouble(temp[0]), (float)Convert.ToDouble(temp[1]), -(float)Convert.ToDouble(temp[2]));
                sub_count += 1;
            }
            count += 1;
        }
        count = 0;
    }
}