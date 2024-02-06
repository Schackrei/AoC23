import numpy as np

file_path = 'input.txt'

with open(file_path, 'r') as file:
    all_lines = file.readlines()

def findS():
    for line in all_lines:
        for char in line:
            if char == 'S':
                return line.index(char), all_lines.index(line)
                break
        else:
            continue
        break
    else:
        print("The character '.' is not present in any line.")
s_pos,start_line = findS()


def walkPath():
    #right
    current_line_r = start_line
    current_pos_r = s_pos +1
    prev_line_r = start_line
    prev_pos_r = s_pos

    

    #down
    current_line_d = start_line +1
    current_pos_d = s_pos
    prev_line_d = start_line
    prev_pos_d = s_pos


    steps = 1
    while (current_line_r != current_line_d or current_pos_r != current_pos_d):
        temp_line = current_line_r
        temp_pos = current_pos_r
        current_line_r, current_pos_r = followDirection(prev_line_r, prev_pos_r, current_line_r, current_pos_r)
        prev_line_r = temp_line
        prev_pos_r = temp_pos



        temp_line = current_line_d
        temp_pos = current_pos_d
        current_line_d, current_pos_d = followDirection(prev_line_d, prev_pos_d, current_line_d,current_pos_d)
        prev_line_d = temp_line
        prev_pos_d = temp_pos

        steps += 1
    return steps



def followDirection(prev_line, prev_pos, current_line, current_pos):
    
    char = all_lines[current_line][current_pos]
    if char == '|':
        if prev_line < current_line:
            current_line += 1
        if current_line < prev_line:
            current_line -= 1
    elif char == '-':
        if prev_pos < current_pos:
            current_pos +=1
        if current_pos < prev_pos:
            current_pos -= 1
    elif char == 'L':
        if prev_line < current_line and prev_pos == current_pos:
            current_pos +=1
        if current_pos < prev_pos:
            current_line -= 1
    elif char == 'J':
        if prev_line < current_line and prev_pos == current_pos:
            current_pos -=1
        if current_pos > prev_pos:
            current_line -= 1
    elif char == '7':
        if prev_pos < current_pos:
            current_line +=1
        if prev_line > current_line and prev_pos == current_pos:
            current_pos -=1
    elif char == 'F':
        if prev_pos > current_pos:
            current_line +=1
        if prev_line > current_line and prev_pos == current_pos:
            current_pos += 1
    return current_line, current_pos

ans_1 = walkPath()

start = findS()
poly = [start]
#down
current_line_d = start_line +1
current_pos_d = s_pos
prev_line_d = start_line
prev_pos_d = s_pos

while (all_lines[current_line_d][current_pos_d] != 'S'):
    poly.append([current_line_d, current_pos_d])
    temp_line = current_line_d
    temp_pos = current_pos_d
    current_line_d, current_pos_d = followDirection(prev_line_d, prev_pos_d, current_line_d,current_pos_d)
    prev_line_d = temp_line
    prev_pos_d = temp_pos


from matplotlib.path import Path
ans_2 = 0
p = Path(poly)
for y in range(len(all_lines)):
    for x in range(len(all_lines[0])):
        if [x, y] in poly:
            continue
        if p.contains_point((x, y)):
            ans_2 += 1

print(f"Answer 1: {ans_1}")
print(f"Answer 2: {ans_2-1}")