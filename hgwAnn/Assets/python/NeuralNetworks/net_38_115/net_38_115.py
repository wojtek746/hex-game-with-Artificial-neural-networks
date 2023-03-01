import numpy as np
import math

class Net:
    def __init__(self, inputs, weights1, biases1, weights2, biases2, weights3, biases3):
        self.inputs = inputs
        self.weights1 = weights1
        self.biases1 = biases1
        self.weights2 = weights2
        self.biases2 = biases2
        self.weights3 = weights3
        self.biases3 = biases3

    def sigmoid(self, x):
        return 1/(1+np.exp(-x))
  
    def sigmoid_derivative(self, x):
        return x * (1 - x)
    
    def feed_forward(self):
        layer1 = self.sigmoid(np.dot(self.inputs, self.weights1) + self.biases1)
        layer2 = self.sigmoid(np.dot(layer1, self.weights2) + self.biases2)
        layer3 = self.sigmoid(np.dot(layer2, self.weights3) + self.biases3)
        return self.most_likely(layer3)

    def most_likely(self, tab):
        result = 114
        for i in range(len(tab)):
            if i < 114:
                if tab[i] >= tab[result] and self.inputs[(math.floor(i / 6)) * 2] == 0:
                    result = i
            else:
                if tab[114] >= tab[result]:
                    result = 114
        return result