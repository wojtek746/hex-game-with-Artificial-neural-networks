import sys
import json
sys.path.append("C:/wojtek746/NeuralNetworks/net")
import net_38_115 as NN
import numpy as np

input = int(sys.argv[1])
inputs = []

if input == 1:
    inputs = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]

with open("C:/wojtek746/borgo/hegemonia.json", "r") as file:
    hq = json.loads(file.read())["hq"]
    nn = NN.Net(inputs, hq["weights1"], hq["biases1"], hq["weights2"], hq["biases2"], hq["weights3"], hq["biases3"])
    print(nn.feed_forward())