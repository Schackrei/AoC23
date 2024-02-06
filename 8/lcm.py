from math import lcm

file_path = 'cycles'
with open(file_path, 'r') as file:
    lines = file.readlines()


numbers = [int(line.strip()) for line in lines]

print(lcm(*numbers))