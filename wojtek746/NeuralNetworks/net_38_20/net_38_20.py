import numpy as np
import math

class Net:
    def __init__(self, inputs, weights1, biases1, weights2, biases2, weights3, biases3, weights4, biases4, isHQ, isMove, isPush):
        self.inputs = inputs
        self.weights1 = weights1
        self.biases1 = biases1
        self.weights2 = weights2
        self.biases2 = biases2
        self.weights3 = weights3
        self.biases3 = biases3
        self.weights4 = weights4
        self.biases4 = biases4
        self.isHQ = isHQ
        self.isMove = isMove
        self.isPush = isPush

    def sigmoid(self, x):
        return 1/(1+np.exp(-x))
  
    def sigmoid_derivative(self, x):
        return x * (1 - x)
  
    def feed_forward(self):
        layer1 = self.sigmoid(np.dot(self.inputs, self.weights1) + self.biases1)
        layer2 = self.sigmoid(np.dot(layer1, self.weights2) + self.biases2)
        layer3 = self.sigmoid(np.dot(layer2, self.weights3) + self.biases3)
        layer4 = self.sigmoid(np.dot(layer3, self.weights4) + self.biases4)
        return self.most_likely(layer4)

    def most_likely(self, tab):
        result = 19
        for i in range(len(tab)):
            if tab[i] >= tab[result]:
                if result != 19:
                    if self.isHQ:
                        if self.inputs[i * 2 - 1] == 0:
                            result = i
                    elif self.isMove:
                        if self.inputs[i * 2 - 1] > 0:
                            result = i
                    elif self.isPush:
                        if self.inputs[i * 2 - 1] < 0:
                            result = i
                    else:
                        result = i
                else:
                    if not self.isHQ:
                        result = i
        return result