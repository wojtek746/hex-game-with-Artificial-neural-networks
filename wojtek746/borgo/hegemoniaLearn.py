import sys
import json
import random

def ran(i):
    if random.random() < 0.01:
        j = random.choice([0, 1])
        if j == 0:
            return i - 0.1
        return i + 0.1
    return i

wei = {}
with open("C:/wojtek746/borgo/hegemonia.json", "r") as file:
    wei = json.loads(file.read())

for i in wei:
    for j in wei[i]:
        for idx, k in enumerate(wei[i][j]):
            if isinstance(k, (int, float)):
                wei[i][j][idx] = ran(k)
            else:
                for lidx, l in enumerate(k):
                    wei[i][j][idx][lidx] = ran(l)
            #for l in k:
                #print(l)

json_obj = json.dumps(wei, indent = 4)
with open("C:/wojtek746/borgo/hegemonia.json", "w") as file:
    file.write(json_obj)