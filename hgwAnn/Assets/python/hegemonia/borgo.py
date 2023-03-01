import sys
import json
import os
os.chdir(os.path.dirname(os.path.abspath(__file__)))
sys.path.append("../NeuralNetworks/net_38_115")
import net_38_115 as NN_38_115
sys.path.append("../NeuralNetworks/net_38_20")
import net_38_20 as NN_38_20
sys.path.append("../NeuralNetworks/net_40_7")
import net_40_7 as NN_40_7
sys.path.append("../NeuralNetworks/net_38_2")
import net_38_2 as NN_38_2
import numpy as np

inputs = [0] * 38
name = ""
name = sys.argv[39]
for i in range(38):
    inputs[i] = int(sys.argv[i + 1])

if name == "pushing":
    inputs = [0] * 39
    for i in range(38):
        inputs[i] = int(sys.argv[i + 1])
    inputs[38] = int(sys.argv[40])
    with open("C:/wojtek746/hegemonia/borgo.json", "r") as file:
        hq = json.loads(file.read())["pushing"]
        if name == "pushing":
            p = True
        else:
            p = False
        nn = NN_40_7.Net(inputs, hq["weights1"], hq["biases1"], hq["weights2"], hq["biases2"], p, False)
        print(nn.feed_forward())
else:
    if name != "battle" and name != "hq" and name != "sniper" and name != "pushBack" and name != "move":
        with open("C:/wojtek746/hegemonia/borgo.json", "r") as file:
            hq = json.loads(file.read())[name]
            nn = NN_38_115.Net(inputs, hq["weights1"], hq["biases1"], hq["weights2"], hq["biases2"], hq["weights3"], hq["biases3"])
            print(nn.feed_forward())
    elif name != "battle":
        with open("C:/wojtek746/hegemonia/borgo.json", "r") as file:
            hq = json.loads(file.read())[name]
            if name == "hq":
                h = True
            else:
                h = False
            if name == "move":
                m = True
            else:
                m = False
            if name == "pushBack":
                p = True
            else:
                p = False
            nn = NN_38_20.Net(inputs, hq["weights1"], hq["biases1"], hq["weights2"], hq["biases2"], hq["weights3"], hq["biases3"], hq["weights4"], hq["biases4"], h, m, p)
            print(nn.feed_forward())
    else:
        with open("C:/wojtek746/hegemonia/borgo.json", "r") as file:
            hq = json.loads(file.read())["battle"]
            nn = NN_38_2.Net(inputs, hq["weights1"], hq["biases1"], hq["weights2"], hq["biases2"], hq["weights3"], hq["biases3"], hq["weights4"], hq["biases4"], hq["weights5"], hq["biases5"], hq["weights6"], hq["biases6"])
            print(nn.feed_forward())