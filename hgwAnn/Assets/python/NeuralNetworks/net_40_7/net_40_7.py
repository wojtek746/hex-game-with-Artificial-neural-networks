import numpy as np
import math

class Net:
    def __init__(self, inputs, weights1, biases1, weights2, biases2, isPush, isGranade):
        self.inputs = inputs
        self.weights1 = weights1
        self.biases1 = biases1
        self.weights2 = weights2
        self.biases2 = biases2
        self.isPush = isPush
        self.isGranade = isGranade

    def sigmoid(self, x):
        return 1/(1+np.exp(-x))
  
    def sigmoid_derivative(self, x):
        return x * (1 - x)
  
    def feed_forward(self):
        layer1 = self.sigmoid(np.dot(self.inputs, self.weights1) + self.biases1)
        layer2 = self.sigmoid(np.dot(layer1, self.weights2) + self.biases2)
        return self.most_likely(layer2)

    def most_likely(self, tab):
        result = 6
        returning = self.inputs[38]
        for i in range(len(tab)):
            if tab[i] >= tab[result]:
                if self.isPush:
                    if self.inputs[38] == 1:
                        if i == 2 and self.inputs[2] == 0:
                            result = i
                            returning = 2
                        elif i == 3 and self.inputs[8] == 0:
                            result = i
                            returning = 5
                        elif i == 4 and self.inputs[4] == 0:
                            result = i
                            returning = 3
                    elif self.inputs[38] == 2:
                        if i == 2 and self.inputs[6] == 0:
                            result = i
                            returning = 4
                        elif i == 3 and self.inputs[12] == 0:
                            result = i
                            returning = 7
                        elif i == 4 and self.inputs[8] == 0:
                            result = i
                            returning = 5
                        elif i == 5 and self.inputs[0] == 0:
                            result = i
                            returning = 1
                    elif self.inputs[38] == 3:
                        if i == 1 and self.inputs[0] == 0:
                            result = i
                            returning = 1
                        elif i == 2 and self.inputs[8] == 0:
                            result = i
                            returning = 5
                        elif i == 3 and self.inputs[14] == 0:
                            result = i
                            returning = 8
                        elif i == 4 and self.inputs[10] == 0:
                            result = i
                            returning = 6
                    elif self.inputs[38] == 4:
                        if i == 3 and self.inputs[16] == 0:
                            result = i
                            returning = 9
                        elif i == 4 and self.inputs[12] == 0:
                            result = i
                            returning = 7
                        elif i == 5 and self.inputs[2] == 0:
                            result = i
                            returning = 2
                    elif self.inputs[38] == 5:
                        if i == 0 and self.inputs[0] == 0:
                            result = i
                            returning = 1
                        elif i == 1 and self.inputs[2] == 0:
                            result = i
                            returning = 2
                        elif i == 2 and self.inputs[12] == 0:
                            result = i
                            returning = 7
                        elif i == 3 and self.inputs[18] == 0:
                            result = i
                            returning = 10
                        elif i == 4 and self.inputs[14] == 0:
                            result = i
                            returning = 8
                        elif i == 5 and self.inputs[4] == 0:
                            result = i
                            returning = 3
                    elif self.inputs[38] == 6:
                        if i == 1 and self.inputs[4] == 0:
                            result = i
                            returning = 3
                        elif i == 2 and self.inputs[14] == 0:
                            result = i
                            returning = 8
                        elif i == 3 and self.inputs[20] == 0:
                            result = i
                            returning = 11
                    elif self.inputs[38] == 7:
                        if i == 0 and self.inputs[2] == 0:
                            result = i
                            returning = 2
                        elif i == 1 and self.inputs[6] == 0:
                            result = i
                            returning = 4
                        elif i == 2 and self.inputs[16] == 0:
                            result = i
                            returning = 9
                        elif i == 3 and self.inputs[22] == 0:
                            result = i
                            returning = 12
                        elif i == 4 and self.inputs[18] == 0:
                            result = i
                            returning = 10
                        elif i == 5 and self.inputs[8] == 0:
                            result = i
                            returning = 5
                    elif self.inputs[38] == 8:
                        if i == 0 and self.inputs[4] == 0:
                            result = i
                            returning = 3
                        elif i == 1 and self.inputs[8] == 0:
                            result = i
                            returning = 5
                        elif i == 2 and self.inputs[18] == 0:
                            result = i
                            returning = 10
                        elif i == 3 and self.inputs[24] == 0:
                            result = i
                            returning = 13
                        elif i == 4 and self.inputs[20] == 0:
                            result = i
                            returning = 11
                        elif i == 5 and self.inputs[10] == 0:
                            result = i
                            returning = 6
                    elif self.inputs[38] == 9:
                        if i == 0 and self.inputs[6] == 0:
                            result = i
                            returning = 4
                        elif i == 3 and self.inputs[26] == 0:
                            result = i
                            returning = 14
                        elif i == 4 and self.inputs[22] == 0:
                            result = i
                            returning = 12
                        elif i == 5 and self.inputs[12] == 0:
                            result = i
                            returning = 7
                    elif self.inputs[38] == 10:
                        if i == 0 and self.inputs[8] == 0:
                            result = i
                            returning = 5
                        elif i == 1 and self.inputs[12] == 0:
                            result = i
                            returning = 7
                        elif i == 2 and self.inputs[22] == 0:
                            result = i
                            returning = 12
                        elif i == 3 and self.inputs[28] == 0:
                            result = i
                            returning = 15
                        elif i == 4 and self.inputs[24] == 0:
                            result = i
                            returning = 13
                        elif i == 5 and self.inputs[14] == 0:
                            result = i
                            returning = 8
                    elif self.inputs[38] == 11:
                        if i == 0 and self.inputs[10] == 0:
                            result = i
                            returning = 6
                        elif i == 1 and self.inputs[14] == 0:
                            result = i
                            returning = 8
                        elif i == 2 and self.inputs[24] == 0:
                            result = i
                            returning = 13
                        elif i == 3 and self.inputs[30] == 0:
                            result = i
                            returning = 16
                    elif self.inputs[38] == 12:
                        if i == 0 and self.inputs[12] == 0:
                            result = i
                            returning = 7
                        elif i == 1 and self.inputs[16] == 0:
                            result = i
                            returning = 9
                        elif i == 2 and self.inputs[26] == 0:
                            result = i
                            returning = 14
                        elif i == 3 and self.inputs[32] == 0:
                            result = i
                            returning = 17
                        elif i == 4 and self.inputs[28] == 0:
                            result = i
                            returning = 15
                        elif i == 5 and self.inputs[18] == 0:
                            result = i
                            returning = 10
                    elif self.inputs[38] == 13:
                        if i == 0 and self.inputs[14] == 0:
                            result = i
                            returning = 8
                        elif i == 1 and self.inputs[18] == 0:
                            result = i
                            returning = 10
                        elif i == 2 and self.inputs[28] == 0:
                            result = i
                            returning = 15
                        elif i == 3 and self.inputs[34] == 0:
                            result = i
                            returning = 18
                        elif i == 4 and self.inputs[30] == 0:
                            result = i
                            returning = 16
                        elif i == 5 and self.inputs[20] == 0:
                            result = i
                            returning = 11
                    elif self.inputs[38] == 14:
                        if i == 0 and self.inputs[16] == 0:
                            result = i
                            returning = 9
                        elif i == 4 and self.inputs[32] == 0:
                            result = i
                            returning = 17
                        elif i == 5 and self.inputs[22] == 0:
                            result = i
                            returning = 12
                    elif self.inputs[38] == 15:
                        if i == 0 and self.inputs[14] == 0:
                            result = i
                            returning = 8
                        elif i == 1 and self.inputs[20] == 0:
                            result = i
                            returning = 12
                        elif i == 2 and self.inputs[30] == 0:
                            result = i
                            returning = 17
                        elif i == 3 and self.inputs[36] == 0:
                            result = i
                            returning = 19
                        elif i == 4 and self.inputs[34] == 0:
                            result = i
                            returning = 18
                        elif i == 5 and self.inputs[24] == 0:
                            result = i
                            returning = 13
                    elif self.inputs[38] == 16:
                        if i == 0 and self.inputs[20] == 0:
                            result = i
                            returning = 11
                        elif i == 1 and self.inputs[24] == 0:
                            result = i
                            returning = 13
                        elif i == 2 and self.inputs[34] == 0:
                            result = i
                            returning = 18
                    elif self.inputs[38] == 17:
                        if i == 0 and self.inputs[22] == 0:
                            result = i
                            returning = 12
                        elif i == 1 and self.inputs[26] == 0:
                            result = i
                            returning = 14
                        elif i == 4 and self.inputs[36] == 0:
                            result = i
                            returning = 19
                        elif i == 5 and self.inputs[28] == 0:
                            result = i
                            returning = 15
                    elif self.inputs[38] == 18:
                        if i == 0 and self.inputs[24] == 0:
                            result = i
                            returning = 13
                        elif i == 1 and self.inputs[28] == 0:
                            result = i
                            returning = 15
                        elif i == 2 and self.inputs[36] == 0:
                            result = i
                            returning = 19
                        elif i == 5 and self.inputs[30] == 0:
                            result = i
                            returning = 16
                    elif self.inputs[38] == 19:
                        if i == 0 and self.inputs[28] == 0:
                            result = i
                            returning = 15
                        elif i == 1 and self.inputs[32] == 0:
                            result = i
                            returning = 17
                        elif i == 5 and self.inputs[34] == 0:
                            result = i
                            returning = 18
#............................................................................................................
                elif self.isGranade:
                    if self.inputs[38] == 1:
                        if i == 2 and self.inputs[2] < -1:
                            result = i
                            returning = 2
                        elif i == 3 and self.inputs[8] < -1:
                            result = i
                            returning = 5
                        elif i == 4 and self.inputs[4] < -1:
                            result = i
                            returning = 3
                    elif self.inputs[38] == 2:
                        if i == 2 and self.inputs[6] < -1:
                            result = i
                            returning = 4
                        elif i == 3 and self.inputs[12] < -1:
                            result = i
                            returning = 7
                        elif i == 4 and self.inputs[8] < -1:
                            result = i
                            returning = 5
                        elif i == 5 and self.inputs[0] < -1:
                            result = i
                            returning = 1
                    elif self.inputs[38] == 3:
                        if i == 1 and self.inputs[0] < -1:
                            result = i
                            returning = 1
                        elif i == 2 and self.inputs[8] < -1:
                            result = i
                            returning = 5
                        elif i == 3 and self.inputs[14] < -1:
                            result = i
                            returning = 8
                        elif i == 4 and self.inputs[10] < -1:
                            result = i
                            returning = 6
                    elif self.inputs[38] == 4:
                        if i == 3 and self.inputs[16] < -1:
                            result = i
                            returning = 9
                        elif i == 4 and self.inputs[12] < -1:
                            result = i
                            returning = 7
                        elif i == 5 and self.inputs[2] < -1:
                            result = i
                            returning = 2
                    elif self.inputs[38] == 5:
                        if i == 0 and self.inputs[0] < -1:
                            result = i
                            returning = 1
                        elif i == 1 and self.inputs[2] < -1:
                            result = i
                            returning = 2
                        elif i == 2 and self.inputs[12] < -1:
                            result = i
                            returning = 7
                        elif i == 3 and self.inputs[18] < -1:
                            result = i
                            returning = 10
                        elif i == 4 and self.inputs[14] < -1:
                            result = i
                            returning = 8
                        elif i == 5 and self.inputs[4] < -1:
                            result = i
                            returning = 3
                    elif self.inputs[38] == 6:
                        if i == 1 and self.inputs[4] < -1:
                            result = i
                            returning = 3
                        elif i == 2 and self.inputs[14] < -1:
                            result = i
                            returning = 8
                        elif i == 3 and self.inputs[20] < -1:
                            result = i
                            returning = 11
                    elif self.inputs[38] == 7:
                        if i == 0 and self.inputs[2] < -1:
                            result = i
                            returning = 2
                        elif i == 1 and self.inputs[6] < -1:
                            result = i
                            returning = 4
                        elif i == 2 and self.inputs[16] < -1:
                            result = i
                            returning = 9
                        elif i == 3 and self.inputs[22] < -1:
                            result = i
                            returning = 12
                        elif i == 4 and self.inputs[18] < -1:
                            result = i
                            returning = 10
                        elif i == 5 and self.inputs[8] < -1:
                            result = i
                            returning = 5
                    elif self.inputs[38] == 8:
                        if i == 0 and self.inputs[4] < -1:
                            result = i
                            returning = 3
                        elif i == 1 and self.inputs[8] < -1:
                            result = i
                            returning = 5
                        elif i == 2 and self.inputs[18] < -1:
                            result = i
                            returning = 10
                        elif i == 3 and self.inputs[24] < -1:
                            result = i
                            returning = 13
                        elif i == 4 and self.inputs[20] < -1:
                            result = i
                            returning = 11
                        elif i == 5 and self.inputs[10] < -1:
                            result = i
                            returning = 6
                    elif self.inputs[38] == 9:
                        if i == 0 and self.inputs[6] < -1:
                            result = i
                            returning = 4
                        elif i == 3 and self.inputs[26] < -1:
                            result = i
                            returning = 14
                        elif i == 4 and self.inputs[22] < -1:
                            result = i
                            returning = 12
                        elif i == 5 and self.inputs[12] < -1:
                            result = i
                            returning = 7
                    elif self.inputs[38] == 10:
                        if i == 0 and self.inputs[8] < -1:
                            result = i
                            returning = 5
                        elif i == 1 and self.inputs[12] < -1:
                            result = i
                            returning = 7
                        elif i == 2 and self.inputs[22] < -1:
                            result = i
                            returning = 12
                        elif i == 3 and self.inputs[28] < -1:
                            result = i
                            returning = 15
                        elif i == 4 and self.inputs[24] < -1:
                            result = i
                            returning = 13
                        elif i == 5 and self.inputs[14] < -1:
                            result = i
                            returning = 8
                    elif self.inputs[38] == 11:
                        if i == 0 and self.inputs[10] < -1:
                            result = i
                            returning = 6
                        elif i == 1 and self.inputs[14] < -1:
                            result = i
                            returning = 8
                        elif i == 2 and self.inputs[24] < -1:
                            result = i
                            returning = 13
                        elif i == 3 and self.inputs[30] < -1:
                            result = i
                            returning = 16
                    elif self.inputs[38] == 12:
                        if i == 0 and self.inputs[12] < -1:
                            result = i
                            returning = 7
                        elif i == 1 and self.inputs[16] < -1:
                            result = i
                            returning = 9
                        elif i == 2 and self.inputs[26] < -1:
                            result = i
                            returning = 14
                        elif i == 3 and self.inputs[32] < -1:
                            result = i
                            returning = 17
                        elif i == 4 and self.inputs[28] < -1:
                            result = i
                            returning = 15
                        elif i == 5 and self.inputs[18] < -1:
                            result = i
                            returning = 10
                    elif self.inputs[38] == 13:
                        if i == 0 and self.inputs[14] < -1:
                            result = i
                            returning = 8
                        elif i == 1 and self.inputs[18] < -1:
                            result = i
                            returning = 10
                        elif i == 2 and self.inputs[28] < -1:
                            result = i
                            returning = 15
                        elif i == 3 and self.inputs[34] < -1:
                            result = i
                            returning = 18
                        elif i == 4 and self.inputs[30] < -1:
                            result = i
                            returning = 16
                        elif i == 5 and self.inputs[20] < -1:
                            result = i
                            returning = 11
                    elif self.inputs[38] == 14:
                        if i == 0 and self.inputs[16] < -1:
                            result = i
                            returning = 9
                        elif i == 4 and self.inputs[32] < -1:
                            result = i
                            returning = 17
                        elif i == 5 and self.inputs[22] < -1:
                            result = i
                            returning = 12
                    elif self.inputs[38] == 15:
                        if i == 0 and self.inputs[14] < -1:
                            result = i
                            returning = 8
                        elif i == 1 and self.inputs[20] < -1:
                            result = i
                            returning = 12
                        elif i == 2 and self.inputs[30] < -1:
                            result = i
                            returning = 17
                        elif i == 3 and self.inputs[36] < -1:
                            result = i
                            returning = 19
                        elif i == 4 and self.inputs[34] < -1:
                            result = i
                            returning = 18
                        elif i == 5 and self.inputs[24] < -1:
                            result = i
                            returning = 13
                    elif self.inputs[38] == 16:
                        if i == 0 and self.inputs[20] < -1:
                            result = i
                            returning = 11
                        elif i == 1 and self.inputs[24] < -1:
                            result = i
                            returning = 13
                        elif i == 2 and self.inputs[34] < -1:
                            result = i
                            returning = 18
                    elif self.inputs[38] == 17:
                        if i == 0 and self.inputs[22] < -1:
                            result = i
                            returning = 12
                        elif i == 1 and self.inputs[26] < -1:
                            result = i
                            returning = 14
                        elif i == 4 and self.inputs[36] < -1:
                            result = i
                            returning = 19
                        elif i == 5 and self.inputs[28] < -1:
                            result = i
                            returning = 15
                    elif self.inputs[38] == 18:
                        if i == 0 and self.inputs[24] < -1:
                            result = i
                            returning = 13
                        elif i == 1 and self.inputs[28] < -1:
                            result = i
                            returning = 15
                        elif i == 2 and self.inputs[36] < -1:
                            result = i
                            returning = 19
                        elif i == 5 and self.inputs[30] < -1:
                            result = i
                            returning = 16
                    elif self.inputs[38] == 19:
                        if i == 0 and self.inputs[28] < -1:
                            result = i
                            returning = 15
                        elif i == 1 and self.inputs[32] < -1:
                            result = i
                            returning = 17
                        elif i == 5 and self.inputs[34] < -1:
                            result = i
                            returning = 18

        return returning