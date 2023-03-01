import numpy as np
import math

class Net:
    def __init__(self, inputs, weights1, biases1, weights2, biases2, weights3, biases3, weights4, biases4, weights5, biases5, weights6, biases6):
        self.inputs = inputs
        self.weights1 = weights1
        self.biases1 = biases1
        self.weights2 = weights2
        self.biases2 = biases2
        self.weights3 = weights3
        self.biases3 = biases3
        self.weights4 = weights4
        self.biases4 = biases4
        self.weights5 = weights5
        self.biases5 = biases5
        self.weights6 = weights6
        self.biases6 = biases6

    def sigmoid(self, x):
        return 1/(1+np.exp(-x))
  
    def sigmoid_derivative(self, x):
        return x * (1 - x)
  
    def feed_forward(self):
        layer1 = self.sigmoid(np.dot(self.inputs, self.weights1) + self.biases1)
        layer2 = self.sigmoid(np.dot(layer1, self.weights2) + self.biases2)
        layer3 = self.sigmoid(np.dot(layer2, self.weights3) + self.biases3)
        layer4 = self.sigmoid(np.dot(layer3, self.weights4) + self.biases4)
        layer5 = self.sigmoid(np.dot(layer4, self.weights5) + self.biases5)
        layer6 = self.sigmoid(np.dot(layer5, self.weights6) + self.biases6)
        return self.most_likely(layer6)

    def most_likely(self, tab):
        result = 1
        if tab[0] >= tab[1]:
            result = 0
        return result