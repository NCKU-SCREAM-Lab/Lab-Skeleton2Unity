import numpy as np
import math


class Unity_Rotation:
    def __init__(self):
        self.euler = []
        self.G = self.x_rotation_matrix(-90)
        self.T = self.x_rotation_matrix(-90)
        self.M = []
        self.f0 = ((-0.7196951-(-0.4613218)), 0.0, (-0.01788038-(-0.01788041)))
        self.f0 = [i/-0.2584 for i in self.f0]
    
    def rotation_matrix(self, theta1, theta2, theta3, order='xyz'):
        """
        input
            theta1, theta2, theta3 = rotation angles in rotation order (degrees)
            order = rotation order of x,y,z　e.g. XZY rotation -- 'xzy'
        output
            3x3 rotation matrix (numpy array)
        """
        c1 = np.cos(theta1 * np.pi / 180)
        s1 = np.sin(theta1 * np.pi / 180)
        c2 = np.cos(theta2 * np.pi / 180)
        s2 = np.sin(theta2 * np.pi / 180)
        c3 = np.cos(theta3 * np.pi / 180)
        s3 = np.sin(theta3 * np.pi / 180)

        if order == 'xzx':
            matrix=np.array([[c2, -c3*s2, s2*s3],
                            [c1*s2, c1*c2*c3-s1*s3, -c3*s1-c1*c2*s3],
                            [s1*s2, c1*s3+c2*c3*s1, c1*c3-c2*s1*s3]])
        elif order=='xyx':
            matrix=np.array([[c2, s2*s3, c3*s2],
                            [s1*s2, c1*c3-c2*s1*s3, -c1*s3-c2*c3*s1],
                            [-c1*s2, c3*s1+c1*c2*s3, c1*c2*c3-s1*s3]])
        elif order=='yxy':
            matrix=np.array([[c1*c3-c2*s1*s3, s1*s2, c1*s3+c2*c3*s1],
                            [s2*s3, c2, -c3*s2],
                            [-c3*s1-c1*c2*s3, c1*s2, c1*c2*c3-s1*s3]])
        elif order=='yzy':
            matrix=np.array([[c1*c2*c3-s1*s3, -c1*s2, c3*s1+c1*c2*s3],
                            [c3*s2, c2, s2*s3],
                            [-c1*s3-c2*c3*s1, s1*s2, c1*c3-c2*s1*s3]])
        elif order=='zyz':
            matrix=np.array([[c1*c2*c3-s1*s3, -c3*s1-c1*c2*s3, c1*s2],
                            [c1*s3+c2*c3*s1, c1*c3-c2*s1*s3, s1*s2],
                            [-c3*s2, s2*s3, c2]])
        elif order=='zxz':
            matrix=np.array([[c1*c3-c2*s1*s3, -c1*s3-c2*c3*s1, s1*s2],
                            [c3*s1+c1*c2*s3, c1*c2*c3-s1*s3, -c1*s2],
                            [s2*s3, c3*s2, c2]])
        elif order=='xyz':
            matrix=np.array([[c2*c3, -c2*s3, s2],
                            [c1*s3+c3*s1*s2, c1*c3-s1*s2*s3, -c2*s1],
                            [s1*s3-c1*c3*s2, c3*s1+c1*s2*s3, c1*c2]])
        elif order=='xzy':
            matrix=np.array([[c2*c3, -s2, c2*s3],
                            [s1*s3+c1*c3*s2, c1*c2, c1*s2*s3-c3*s1],
                            [c3*s1*s2-c1*s3, c2*s1, c1*c3+s1*s2*s3]])
        elif order=='yxz':
            matrix=np.array([[c1*c3+s1*s2*s3, c3*s1*s2-c1*s3, c2*s1],
                            [c2*s3, c2*c3, -s2],
                            [c1*s2*s3-c3*s1, c1*c3*s2+s1*s3, c1*c2]])
        elif order=='yzx':
            matrix=np.array([[c1*c2, s1*s3-c1*c3*s2, c3*s1+c1*s2*s3],
                            [s2, c2*c3, -c2*s3],
                            [-c2*s1, c1*s3+c3*s1*s2, c1*c3-s1*s2*s3]])
        elif order=='zyx':
            matrix=np.array([[c1*c2, c1*s2*s3-c3*s1, s1*s3+c1*c3*s2],
                            [c2*s1, c1*c3+s1*s2*s3, c3*s1*s2-c1*s3],
                            [-s2, c2*s3, c2*c3]])
        elif order=='zxy':
            matrix=np.array([[c1*c3-s1*s2*s3, -c2*s1, c1*s3+c3*s1*s2],
                            [c3*s1+c1*s2*s3, c1*c2, s1*s3-c1*c3*s2],
                            [-c2*s3, s2, c2*c3]])

        return matrix

    def rotation_angles(self, matrix, order):
        '''
        input
            matrix = 3x3 rotation matrix (numpy array)
            order(str) = rotation order of x, y, z : e.g, rotation XZY -- 'xzy'
        output
            theta1, theta2, theta3 = rotation angles in rotation order
        '''
        r11, r12, r13 = matrix[0]
        r21, r22, r23 = matrix[1]
        r31, r32, r33 = matrix[2]

        if order == 'xzx':
            theta1 = np.arctan(r31 / r21)
            theta2 = np.arctan(r21 / (r11 * np.cos(theta1)))
            theta3 = np.arctan(-r13 / r12)

        elif order == 'xyx':
            theta1 = np.arctan(-r21 / r31)
            theta2 = np.arctan(-r31 / (r11 *np.cos(theta1)))
            theta3 = np.arctan(r12 / r13)

        elif order == 'yxy':
            theta1 = np.arctan(r12 / r32)
            theta2 = np.arctan(r32 / (r22 *np.cos(theta1)))
            theta3 = np.arctan(-r21 / r23)

        elif order == 'yzy':
            theta1 = np.arctan(-r32 / r12)
            theta2 = np.arctan(-r12 / (r22 *np.cos(theta1)))
            theta3 = np.arctan(r23 / r21)

        elif order == 'zyz':
            theta1 = np.arctan(r23 / r13)
            theta2 = np.arctan(r13 / (r33 *np.cos(theta1)))
            theta3 = np.arctan(-r32 / r31)

        elif order == 'zxz':
            theta1 = np.arctan(-r13 / r23)
            theta2 = np.arctan(-r23 / (r33 *np.cos(theta1)))
            theta3 = np.arctan(r31 / r32)

        elif order == 'xzy':
            theta1 = np.arctan(r32 / r22)
            theta2 = np.arctan(-r12 * np.cos(theta1) / r22)
            theta3 = np.arctan(r13 / r11)

        elif order == 'xyz':
            theta1 = np.arctan(-r23 / r33)
            theta2 = np.arctan(r13 * np.cos(theta1) / r33)
            theta3 = np.arctan(-r12 / r11)

        elif order == 'yxz':
            if r23 == 1 or r23 == -1:
                theta1 = np.arctan2(-r31, r11)
                theta2 = -r23 * (math.pi / 2)
                theta3 = 0
            else:
                theta1 = np.arctan2(r13, r33)
                theta2 = np.arcsin(-r23)
                theta3 = np.arctan2(r21, r22)

        elif order == 'yzx':
            theta1 = np.arctan(-r31 / r11)
            theta2 = np.arctan(r21 * np.cos(theta1) / r11)
            theta3 = np.arctan(-r23 / r22)

        elif order == 'zyx':
            theta1 = np.arctan(r21 / r11)
            theta2 = np.arctan(-r31 * np.cos(theta1) / r11)
            theta3 = np.arctan(r32 / r33)

        elif order == 'zxy':
            theta1 = np.arctan(-r12 / r22)
            theta2 = np.arctan(r32 * np.cos(theta1) / r22)
            theta3 = np.arctan(-r31 / r33)

        theta1 = theta1 * 180 / np.pi
        theta2 = theta2 * 180 / np.pi
        theta3 = theta3 * 180 / np.pi

        return (theta1, theta2, theta3)

    def coordinate_to_Matrix(self, coordinate):
        x = coordinate[0]
        y = coordinate[1]
        z = coordinate[2]
        r = math.sqrt((x**2) + (y**2))

        matrix = np.zeros((3, 3), dtype=float)
        matrix[0][0] = x
        matrix[1][0] = y
        matrix[2][0] = z
        matrix[0][1] = y / r
        matrix[1][1] = -x / r
        matrix[2][1] = 0
        matrix[0][2] = (x*z) / r
        matrix[1][2] = (y*z) / r
        matrix[2][2] = -r

        return matrix.tolist()

    def x_rotation_matrix(self, angle):
        theta = angle * (math.pi/180)
        rotation_matrix = [[1, 0, 0],
                            [0, math.cos(theta), -math.sin(theta)],
                            [0, math.sin(theta), math.cos(theta)]]
        return rotation_matrix

    def matrix_mul(self, Matrix_1, Matrix_2):
        # print(Matrix_1)
        # print(Matrix_2)
        mul_matrix = [[0 for _ in range(3)] for _ in range(3)]
        for row in range(3): 
            for col in range(3):
                for elt in range(3):
                    mul_matrix[row][col] += Matrix_1[row][elt] * Matrix_2[elt][col]
        
        return mul_matrix

    def matrix_mul_vector(self, Matrix, vector):
        vector2 = [0 for _ in range(3)]
        for i in range(3):
            for j in range(3):
                vector2[i] += Matrix[i][j] * vector[j]
        return vector2

    def hand_process(self, origin, hand1_coor, hand2_coor):

        vector_old = (hand1_coor[0]-origin[0], hand1_coor[1]-origin[1], hand1_coor[2]-origin[2])
        vector_new = (hand2_coor[0]-origin[0], hand2_coor[1]-origin[1], hand2_coor[2]-origin[2])
        vector_old = [i/-0.2584 for i in vector_old]
        vector_new = [i/-0.2584 for i in vector_new]

        M = self.coordinate_to_Matrix(self.matrix_mul_vector(np.transpose(self.T), vector_new))
        r_y, r_x, r_z = self.rotation_angles(M, order="yxz")
        self.T = self.matrix_mul(self.T, self.coordinate_to_Matrix(self.matrix_mul_vector(np.transpose(self.T), vector_new)))
        print(f"pre_frame vector:{vector_old}\nnow_frame vector:{vector_new}")
        # v2 = self.matrix_mul_vector(self.T, self.f0)
        # print(f"turn to vector:{v2}")
        print(f"x: {r_x}, y: {r_y}, z: {r_z}")
        print("\n----------update----------")

        # theta = 0
        # vector_old = (hand1_coor[0]-origin[0], hand1_coor[1]-origin[1], hand1_coor[2]-origin[2])
        # vector_new = (hand2_coor[0]-origin[0], hand2_coor[1]-origin[1], hand2_coor[2]-origin[2])
        # vector_old = [i/0.2584 for i in vector_old]
        # vector_new = [i/0.2584 for i in vector_new]
        # R_x = self.x_rotation_matrix(theta)
        # M_old = self.coordinate_to_Matrix(vector_old)
        # M_new = self.coordinate_to_Matrix(vector_new)
        # if self.M == []:
        #     temp = self.matrix_mul(M_new, R_x)
        #     M = self.matrix_mul(temp, np.linalg.inv(M_old))
        #     self.M = M
        # else:
        #     temp = self.matrix_mul(M_new, R_x)
        #     M = self.matrix_mul(temp, np.linalg.inv(M_old))
        #     temp = self.matrix_mul(np.linalg.inv(self.M), M)
        #     M = self.matrix_mul(temp, self.M)
        #     self.M = M

        # v2 = self.matrix_mul_vector(M, vector_old)
        # print(f"pre_frame vector:{vector_old}\nnow_frame vector:{vector_new}")
        # print(f"turn to vector:{v2}")
        # # r_z, r_x, r_y = self.rotation_angles(M, order="zxy")
        # r_y, r_x, r_z = self.rotation_angles(M, order="yxz")
        # print(f"x: {r_x}, y: {r_y}, z: {r_z}")
        # print(" ")
        # print("----------update----------")
        # print(f"M = {M}")

        # ------------------- test -------------------
        # hand3_coor = (-0.5378515, 1.29344, 0.02630395)
        # v_o = vector_new 
        # v_n = (hand3_coor[0]-origin[0], hand3_coor[1]-origin[1], hand3_coor[2]-origin[2])
        # v_n = [i/0.2584 for i in v_n]
        # Mn_old = self.coordinate_to_Matrix(v_o)
        # Mn_new = self.coordinate_to_Matrix(v_n)
        # temp = self.matrix_mul(Mn_new, R_x)
        # Mn = self.matrix_mul(temp, np.linalg.inv(Mn_old))
        # temp = self.matrix_mul(np.linalg.inv(M), Mn)
        # Mn = self.matrix_mul(temp, M)

        # v3 = self.matrix_mul_vector(Mn, v_o)
        # print(" ")
        # print("----------update----------")
        # print(f"pre_frame vector:{v_o}\nnow_frame vector:{v_n}")
        # print(f"turn to vector:{v3}")

        # rn_z, rn_x, rn_y = self.rotation_angles(Mn, order="zxy")
        # # rn_y, rn_x, rn_z = self.rotation_angles(Mn, order="yxz")
        # print(f"---> x: {rn_x}, y: {rn_y}, z: {rn_z}")
        # print(f"M = {Mn}")
                

    
    # def coordinate2latitude_longitude(self, coordinate_1, coordinate_2):
