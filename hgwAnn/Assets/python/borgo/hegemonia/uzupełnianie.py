import sys
import json

# wei = {
#     "hq": {
#         "weights1": [[0.1 for j in range(57)] for i in range(38)],
#         "biases1": [0.1 for i in range(57)],
#         "weights2": [[0.1 for j in range(85)] for i in range(57)],
#         "biases2": [0.1 for i in range(85)],
#         "weights3": [[0.1 for j in range(115)] for i in range(85)],
#         "biases3": [0.1 for i in range(115)]
#     }, 
#     "netFlighter": {
#         "weights1": [[0.1 for j in range(57)] for i in range(38)],
#         "biases1": [0.1 for i in range(57)],
#         "weights2": [[0.1 for j in range(85)] for i in range(57)],
#         "biases2": [0.1 for i in range(85)],
#         "weights3": [[0.1 for j in range(115)] for i in range(85)],
#         "biases3": [0.1 for i in range(115)]
#     }, 
#     "theBoss": {
#         "weights1": [[0.1 for j in range(57)] for i in range(38)],
#         "biases1": [0.1 for i in range(57)],
#         "weights2": [[0.1 for j in range(85)] for i in range(57)],
#         "biases2": [0.1 for i in range(85)],
#         "weights3": [[0.1 for j in range(115)] for i in range(85)],
#         "biases3": [0.1 for i in range(115)]
#     }, 
#     "officerI": {
#         "weights1": [[0.1 for j in range(57)] for i in range(38)],
#         "biases1": [0.1 for i in range(57)],
#         "weights2": [[0.1 for j in range(85)] for i in range(57)],
#         "biases2": [0.1 for i in range(85)],
#         "weights3": [[0.1 for j in range(115)] for i in range(85)],
#         "biases3": [0.1 for i in range(115)]
#     }, 
#     "officerII": {
#         "weights1": [[0.1 for j in range(57)] for i in range(38)],
#         "biases1": [0.1 for i in range(57)],
#         "weights2": [[0.1 for j in range(85)] for i in range(57)],
#         "biases2": [0.1 for i in range(85)],
#         "weights3": [[0.1 for j in range(115)] for i in range(85)],
#         "biases3": [0.1 for i in range(115)]
#     }, 
#     "runner": {
#         "weights1": [[0.1 for j in range(57)] for i in range(38)],
#         "biases1": [0.1 for i in range(57)],
#         "weights2": [[0.1 for j in range(85)] for i in range(57)],
#         "biases2": [0.1 for i in range(85)],
#         "weights3": [[0.1 for j in range(115)] for i in range(85)],
#         "biases3": [0.1 for i in range(115)]
#     }, 
#     "guard": {
#         "weights1": [[0.1 for j in range(57)] for i in range(38)],
#         "biases1": [0.1 for i in range(57)],
#         "weights2": [[0.1 for j in range(85)] for i in range(57)],
#         "biases2": [0.1 for i in range(85)],
#         "weights3": [[0.1 for j in range(115)] for i in range(85)],
#         "biases3": [0.1 for i in range(115)]
#     }, 
#     "quartermaster": {
#         "weights1": [[0.1 for j in range(57)] for i in range(38)],
#         "biases1": [0.1 for i in range(57)],
#         "weights2": [[0.1 for j in range(85)] for i in range(57)],
#         "biases2": [0.1 for i in range(85)],
#         "weights3": [[0.1 for j in range(115)] for i in range(85)],
#         "biases3": [0.1 for i in range(115)]
#     }, 
#     "transport": {
#         "weights1": [[0.1 for j in range(57)] for i in range(38)],
#         "biases1": [0.1 for i in range(57)],
#         "weights2": [[0.1 for j in range(85)] for i in range(57)],
#         "biases2": [0.1 for i in range(85)],
#         "weights3": [[0.1 for j in range(115)] for i in range(85)],
#         "biases3": [0.1 for i in range(115)]
#     }, 
#     "thug": {
#         "weights1": [[0.1 for j in range(57)] for i in range(38)],
#         "biases1": [0.1 for i in range(57)],
#         "weights2": [[0.1 for j in range(85)] for i in range(57)],
#         "biases2": [0.1 for i in range(85)],
#         "weights3": [[0.1 for j in range(115)] for i in range(85)],
#         "biases3": [0.1 for i in range(115)]
#     }, 
#     "netMaster": {
#         "weights1": [[0.1 for j in range(57)] for i in range(38)],
#         "biases1": [0.1 for i in range(57)],
#         "weights2": [[0.1 for j in range(85)] for i in range(57)],
#         "biases2": [0.1 for i in range(85)],
#         "weights3": [[0.1 for j in range(115)] for i in range(85)],
#         "biases3": [0.1 for i in range(115)]
#     }, 
#     "ganger": {
#         "weights1": [[0.1 for j in range(57)] for i in range(38)],
#         "biases1": [0.1 for i in range(57)],
#         "weights2": [[0.1 for j in range(85)] for i in range(57)],
#         "biases2": [0.1 for i in range(85)],
#         "weights3": [[0.1 for j in range(115)] for i in range(85)],
#         "biases3": [0.1 for i in range(115)]
#     },
#     "gladiator": {
#         "weights1": [[0.1 for j in range(57)] for i in range(38)],
#         "biases1": [0.1 for i in range(57)],
#         "weights2": [[0.1 for j in range(85)] for i in range(57)],
#         "biases2": [0.1 for i in range(85)],
#         "weights3": [[0.1 for j in range(115)] for i in range(85)],
#         "biases3": [0.1 for i in range(115)]
#     },
#     "universalSoldier": {
#         "weights1": [[0.1 for j in range(57)] for i in range(38)],
#         "biases1": [0.1 for i in range(57)],
#         "weights2": [[0.1 for j in range(85)] for i in range(57)],
#         "biases2": [0.1 for i in range(85)],
#         "weights3": [[0.1 for j in range(115)] for i in range(85)],
#         "biases3": [0.1 for i in range(115)]
#     },
#     "scout": {
#         "weights1": [[0.1 for j in range(57)] for i in range(38)],
#         "biases1": [0.1 for i in range(57)],
#         "weights2": [[0.1 for j in range(85)] for i in range(57)],
#         "biases2": [0.1 for i in range(85)],
#         "weights3": [[0.1 for j in range(115)] for i in range(85)],
#         "biases3": [0.1 for i in range(115)]
#     },
#     "move": {
#         "weights1": [[0.1 for j in range(57)] for i in range(38)],
#         "biases1": [0.1 for i in range(57)],
#         "weights2": [[0.1 for j in range(85)] for i in range(57)],
#         "biases2": [0.1 for i in range(85)],
#         "weights3": [[0.1 for j in range(115)] for i in range(85)],
#         "biases3": [0.1 for i in range(115)]
#     }
# }
# wei["hq"]["biases3"][114] = -0.1
# wei["netFlighter"]["biases3"][114] = -0.1
# wei["theBoss"]["biases3"][114] = -0.1
# wei["officerI"]["biases3"][114] = -0.1
# wei["officerII"]["biases3"][114] = -0.1
# wei["runner"]["biases3"][114] = -0.1
# wei["guard"]["biases3"][114] = -0.1
# wei["quartermaster"]["biases3"][114] = -0.1
# wei["transport"]["biases3"][114] = -0.1
# wei["thug"]["biases3"][114] = -0.1
# wei["netMaster"]["biases3"][114] = -0.1
# wei["ganger"]["biases3"][114] = -0.1
# wei["gladiator"]["biases3"][114] = -0.1
# wei["universalSoldier"]["biases3"][114] = -0.1
# wei["scout"]["biases3"][114] = -0.1
# wei["move"]["biases3"][114] = -0.1

wei = {}
with open("C:/wojtek746/hegemonia/borgo.json", "r") as file:
    wei = json.loads(file.read())

# wei["pushing"] = {
#     "weights1": [[0.1 for j in range(23)] for i in range(39)], 
#     "biases1": [0.1 for i in range(23)],
#     "weights2": [[0.1 for j in range(7)] for i in range(23)], 
#     "biases2": [0.1 for i in range(7)]
# }

# wei["hq"] = {
#     "weights1": [[0.1 for j in range(32)] for i in range(38)], 
#     "biases1": [0.1 for i in range(32)],
#     "weights2": [[0.1 for j in range(26)] for i in range(32)], 
#     "biases2": [0.1 for i in range(26)],
#     "weights3": [[0.1 for j in range(22)] for i in range(26)], 
#     "biases3": [0.1 for i in range(22)],
#     "weights4": [[0.1 for j in range(20)] for i in range(22)], 
#     "biases4": [0.1 for i in range(20)]
# }

wei["grenade"] = {
    "weights1": [[0.1 for j in range(23)] for i in range(39)], 
    "biases1": [0.1 for i in range(23)],
    "weights2": [[0.1 for j in range(7)] for i in range(23)], 
    "biases2": [0.1 for i in range(7)]
}

# wei["move"] = {
#     "weights1": [[0.1 for j in range(32)] for i in range(38)], 
#     "biases1": [0.1 for i in range(32)],
#     "weights2": [[0.1 for j in range(26)] for i in range(32)], 
#     "biases2": [0.1 for i in range(26)],
#     "weights3": [[0.1 for j in range(22)] for i in range(26)], 
#     "biases3": [0.1 for i in range(22)],
#     "weights4": [[0.1 for j in range(20)] for i in range(22)], 
#     "biases4": [0.1 for i in range(20)]
# }

# wei["battle"] = {
#     "weights1": [[0.1 for j in range(25)] for i in range(38)], 
#     "biases1": [0.1 for i in range(25)],
#     "weights2": [[0.1 for j in range(16)] for i in range(25)], 
#     "biases2": [0.1 for i in range(16)],
#     "weights3": [[0.1 for j in range(10)] for i in range(16)], 
#     "biases3": [0.1 for i in range(10)],
#     "weights4": [[0.1 for j in range(6)] for i in range(10)], 
#     "biases4": [0.1 for i in range(6)], 
#     "weights5": [[0.1 for j in range(4)] for i in range(6)], 
#     "biases5": [0.1 for i in range(4)], 
#     "weights6": [[0.1 for j in range(2)] for i in range(4)], 
#     "biases6": [0.1 for i in range(2)]
# }

json_obj = json.dumps(wei, indent = 4)
with open("../hegemonia/borgo.json", "w") as file:
    file.write(json_obj)