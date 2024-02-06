import numpy as np

placeholders = []
placeholders2 = []

def findsequence(sequence):
    sequences = []


    sequences.append(sequence)
    differences = np.diff(sequence)
    sequences.append(differences)
    while any(differences) != 0:
        sequence = differences
        differences = np.diff(sequence)
        sequences.append(differences)
    process_sequences(sequences)
    process_sequences2(sequences)


def process_sequences(sequences):
    previous_result = 0
    for i in range(len(sequences) - 1, 0, -1):
        current_element = sequences[i-1][len(sequences[i-1])-1]
        result = current_element + previous_result
        previous_result = result
    placeholders.append(result)


def process_sequences2(sequences):
    previous_result = 0
    for i in range(len(sequences) - 1, 0, -1):
        current_element = sequences[i-1][0]
        result = current_element - previous_result
        previous_result = result
    placeholders2.append(result)       

file_path = 'input.txt'
with open(file_path, 'r') as file:
    all_lines = file.readlines()


for line in all_lines:
    values = line.strip().split()
    values_as_int = [int(value) for value in values]
    findsequence(values_as_int)
sum = 0
for p in placeholders:
    sum += p
sum2 = 0    
for p in placeholders2:
    sum2 += p
print("Placeholders sum: ", sum)
print("Placeholders2 sum2: ", sum2)