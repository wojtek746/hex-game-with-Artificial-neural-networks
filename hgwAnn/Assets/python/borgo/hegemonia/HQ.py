import sys
import json
sys.path.append("C:/wojtek746/NeuralNetworks/net")
import net_38_115 as NN
import numpy as np

inputs = [0] * 38
for i in range(38):
    inputs[i] = int(sys.argv[i + 1])
    #inputs[i] = 0

with open("C:/wojtek746/borgo/hegemonia.json", "r") as file:
    hq = json.loads(file.read())["hq"]
    nn = NN.Net(inputs, hq["weights1"], hq["biases1"], hq["weights2"], hq["biases2"], hq["weights3"], hq["biases3"])
    print(nn.feed_forward())