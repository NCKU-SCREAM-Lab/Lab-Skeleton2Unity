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
        15: L_handIndex, 16: L_handPinky, 17: R_handIndex, 18: R_handPinky, 19: L_toeBase, 20: R_toeBase
    }
    */
    public static string coordinate_txt_path = @"Assets/Motion data/act_1_ca_o1.txt";
    public static string[] coordinate_lines = File.ReadAllLines(coordinate_txt_path);
    public static Vector3[,] coordinate_list = new Vector3[coordinate_lines.Length, 21];

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
                coordinate_list[count, sub_count] = new Vector3((float)Convert.ToDouble(temp[0]), (float)Convert.ToDouble(temp[1]), (float)Convert.ToDouble(temp[2]));
                sub_count += 1;
            }
            count += 1;
        }
        count = 0;
    }
}
