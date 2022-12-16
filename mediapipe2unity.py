import numpy as np
import pickle
import math

class Mediapipe_to_Unity:
    def __init__(self):
        self.T_pose_local_angle = [[0,0,0]]
        
    def Data_loader(self, path):
        # read pickle data
        # combines 15 unity bones coordinates to string
        # return all of bones string list by combines string of every frame data in pickle
        dataset = []
        with open(path, 'rb')as fpick:
            data = pickle.load(fpick)
            dataset.append(data)
        world_positions_list = []
        for frame in dataset[0]:
            temp_str = ""
            for idx, skeletons in enumerate(frame):
                if idx % 3 == 2:
                    temp_str += (str(skeletons) + ",")
                else:
                    temp_str += (str(skeletons) + " ")
            temp_str = temp_str[:len(temp_str)-1]
            world_positions_list.append(temp_str)
        return world_positions_list
    
    def Pos_loader(self, path):
        pos = []
        with open(path, 'rb') as f:
            data = pickle.load(f)
            for hips in data:
                x = (hips[0][0] - hips[1][0]) / 2
                y = (hips[0][1] - hips[1][1]) / 2
                pos.append(str(str(x) + ',' + str(y)))
        return pos

    def Angle_loader(self, path):
        ang_list = []
        with open(path, 'rb') as f:
            data = pickle.load(f)
        for frame in data:
            temp = ""
            for idx, ang in enumerate(frame):
                if idx % 3 == 2:
                    temp += (str(ang) + ",")
                else:
                    temp += (str(ang) + " ")
            temp = temp[:len(temp)-1]
            ang_list.append(temp)
        return ang_list

    def write_to_txtfile(self, datas, path):
        with open(path, 'w') as f:
            for data in datas:
                f.write(data)
                f.write("\n")

    def world_position_to_dict(self, world_position):
        bones_list = ['head', 'spine', 'r_upperarm', 'r_lowerarm', 'r_hand', 'l_upperarm', 'l_lowerarm', 
                    'l_hand', 'hip', 'r_upperleg', 'r_lowerleg', 'r_foot', 'l_upperleg', 'l_lowerleg',
                    'l_foot', 'r_pinky', 'l_pinky', 'r_index', 'l_index', 'r_mouth', 'l_mouth', 'r_toe', 'l_toe']
        bones_dict = {}
        skeleton = world_position.split(",")
        for idx, sub in enumerate(skeleton):
            coordinate = sub.split(" ")
            bones_dict[bones_list[idx]] = (float(coordinate[0]), float(coordinate[1]), float(coordinate[2]))
        # print(bones_dict)
        return bones_dict

    def Rotation_calc(self, point_1, point_2, point_3):
        # calculate included angle of point_2 to point_1 and point_3
        def two_dim_angle(v1, v2):
            dot_product = (v1[0]*v2[0]) + (v1[1]*v2[1])
            scale = (math.sqrt(v1[0]**2 + v1[1]**2)) * (math.sqrt(v2[0]**2 + v2[1]**2))
            if scale == 0:
                theta = 0
            else:
                theta = math.degrees(math.acos(dot_product/scale))
            return theta
        
        # projection to xy-plane
        vector_1 = ((point_1[0] - point_2[0]), (point_1[1] - point_2[1]))
        vector_2 = ((point_3[0] - point_2[0]), (point_3[1] - point_2[1]))
        z_rotation = two_dim_angle(vector_1, vector_2)
        rotation_matrix = [[math.cos(z_rotation*(math.pi/180)), math.sin(z_rotation*(math.pi/180)), 0],
                            [-math.sin(z_rotation*(math.pi/180)), math.cos(z_rotation*(math.pi/180)), 0],
                            [0, 0, 1]]
        # print(rotation_matrix)
        # new_point_1 = [0 for _ in range(3)]
        # new_point_2 = [0 for _ in range(3)]
        # new_point_3 = [0 for _ in range(3)]
        vector_1 = ((point_1[0] - point_2[0]), (point_1[1] - point_2[1]), (point_1[2] - point_2[2]))
        new_vector = [0 for _ in range(3)]
        for i in range(3):
            for j in range(3):
                new_vector[i] += rotation_matrix[i][j] * vector_1[j]
                # new_point_1[i] += rotation_matrix[i][j] * point_1[j]
                # new_point_2[i] += rotation_matrix[i][j] * point_2[j]
                # new_point_3[i] += rotation_matrix[i][j] * point_3[j]
        # projection to xz-plane
        vector_1 = (new_vector[0], new_vector[2])
        vector_2 = ((point_3[0] - point_2[0]), (point_3[2] - point_2[2]))
        y_rotation = two_dim_angle(vector_1, vector_2)

        return z_rotation, y_rotation

    def Euler_to_Quaternion(self, z, y):
        
        def Quaternion_multiply(quaternion0, quaternion1):
            w0, x0, y0, z0 = quaternion0
            w1, x1, y1, z1 = quaternion1
            return np.array([-x1 * x0 - y1 * y0 - z1 * z0 + w1 * w0,
                            x1 * w0 + y1 * z0 - z1 * y0 + w1 * x0,
                            -x1 * z0 + y1 * w0 + z1 * x0 + w1 * y0,
                            x1 * y0 - y1 * x0 + z1 * w0 + w1 * z0], dtype=np.float64)

        # calculate quaternion of first rotation(z)
        qx1 = np.sin(0/2) * np.cos(0/2) * np.cos(z/2) - np.cos(0/2) * np.sin(0/2) * np.sin(z/2)
        qy1 = np.cos(0/2) * np.sin(0/2) * np.cos(z/2) + np.sin(0/2) * np.cos(0/2) * np.sin(z/2)
        qz1 = np.cos(0/2) * np.cos(0/2) * np.sin(z/2) - np.sin(0/2) * np.sin(0/2) * np.cos(z/2)
        qw1 = np.cos(0/2) * np.cos(0/2) * np.cos(z/2) + np.sin(0/2) * np.sin(0/2) * np.sin(z/2)
        quaternion0 = [qw1, qx1, qy1, qz1]
        # calculate quaternion of first rotation(y)
        qx2 = np.sin(0/2) * np.cos(y/2) * np.cos(0/2) - np.cos(0/2) * np.sin(y/2) * np.sin(0/2)
        qy2 = np.cos(0/2) * np.sin(y/2) * np.cos(0/2) + np.sin(0/2) * np.cos(y/2) * np.sin(0/2)
        qz2 = np.cos(0/2) * np.cos(y/2) * np.sin(0/2) - np.sin(0/2) * np.sin(y/2) * np.cos(0/2)
        qw2 = np.cos(0/2) * np.cos(y/2) * np.cos(0/2) + np.sin(0/2) * np.sin(y/2) * np.sin(0/2)
        quaternion1 = [qw2, qx2, qy2, qz2]

        result_quaternion = Quaternion_multiply(quaternion0, quaternion1).tolist()
        print(result_quaternion)
        return result_quaternion
    
    def Quaternion_to_Euler(self, quaternion):
        w, x, y, z = quaternion[0], quaternion[1], quaternion[2], quaternion[3]
        t0 = +2.0 * (w * x + y * z)
        t1 = +1.0 - 2.0 * (x * x + y * y)
        roll_x = math.degrees(math.atan2(t0, t1))
    
        t2 = +2.0 * (w * y - z * x)
        t2 = +1.0 if t2 > +1.0 else t2
        t2 = -1.0 if t2 < -1.0 else t2
        pitch_y = math.degrees(math.asin(t2))
    
        t3 = +2.0 * (w * z + x * y)
        t4 = +1.0 - 2.0 * (y * y + z * z)
        yaw_z = math.degrees(math.atan2(t3, t4))
    
        return (roll_x, pitch_y, yaw_z)
        


    def hip_to_Lfoot(self, hip, L_upperleg, L_lowerleg, L_foot):
        L_upperleg_rotation_z, L_upperleg_rotation_y = self.Rotation_calc(hip, L_upperleg, L_lowerleg)
        L_lowerleg_rotation_z, L_lowerleg_rotation_y = self.Rotation_calc(L_upperleg, L_lowerleg, L_foot)
        return [L_upperleg_rotation_z, L_upperleg_rotation_y, L_lowerleg_rotation_z, L_lowerleg_rotation_y]
    
    def hip_to_Rfoot(self, hip, R_upperleg, R_lowerleg, R_foot):
        R_upperleg_rotation_z, R_upperleg_rotation_y = self.Rotation_calc(hip, R_upperleg, R_lowerleg)
        R_lowerleg_rotation_z, R_lowerleg_rotation_y = self.Rotation_calc(R_upperleg, R_lowerleg, R_foot)
        return [R_upperleg_rotation_z, R_upperleg_rotation_y, R_lowerleg_rotation_z, R_lowerleg_rotation_y]

    def spine_to_Lhand(self, spine, L_upperarm, L_lowerarm, L_hand):
        L_upperarm_rotation_z, L_upperarm_rotation_y = self.Rotation_calc(spine, L_upperarm, L_lowerarm)
        L_lowerarm_rotation_z, L_lowerarm_rotation_y = self.Rotation_calc(L_upperarm, L_lowerarm, L_hand)
        return [(L_upperarm_rotation_z), (L_upperarm_rotation_y), (L_lowerarm_rotation_z), (L_lowerarm_rotation_y)]

    def spine_to_Rhand(self, spine, R_upperarm, R_lowerarm, R_hand):
        R_upperarm_rotation_z, R_upperarm_rotation_y = self.Rotation_calc(spine, R_upperarm, R_lowerarm)
        R_lowerarm_rotation_z, R_lowerarm_rotation_y = self.Rotation_calc(R_upperarm, R_lowerarm, R_hand)
        return [(R_upperarm_rotation_z), (R_upperarm_rotation_y), (R_lowerarm_rotation_z), (R_lowerarm_rotation_y)]
    