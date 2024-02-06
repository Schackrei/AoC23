file_path = 'grid.txt'
with open(file_path, 'r') as file:
    grid = [list(line.strip()) for line in file]

grid_rows = len(grid)
grid_cols = len(grid[0])

grid[0][0] = 'X'

for row in range(grid_rows):
    for col in range(grid_cols):
        pos = (row, col)
        if grid[row][col] == '0':
            if row - 1 >= 0 and grid[row - 1][col] == 'X':
                grid[row][col] = 'X'
            if row + 1 < grid_rows and grid[row + 1][col] == 'X':
                grid[row][col] = 'X'
            if col - 1 >= 0 and grid[row][col - 1] == 'X':
                grid[row][col] = 'X'
            if col + 1 < grid_cols and grid[row][col + 1] == 'X':
                grid[row][col] = 'X'

for row in range(grid_rows - 1, -1, -1):
    for col in range(grid_cols - 1, -1, -1):
        pos = (row, col)
        if grid[row][col] == '0':
            if row - 1 >= 0 and grid[row - 1][col] == 'X':
                grid[row][col] = 'X'
            if row + 1 < grid_rows and grid[row + 1][col] == 'X':
                grid[row][col] = 'X'
            if col - 1 >= 0 and grid[row][col - 1] == 'X':
                grid[row][col] = 'X'
            if col + 1 < grid_cols and grid[row][col + 1] == 'X':
                grid[row][col] = 'X'

for row in range(grid_rows):
    for col in range(grid_cols):
        pos = (row, col)
        if grid[row][col] == '0':
            if row - 1 >= 0 and grid[row - 1][col] == 'X':
                grid[row][col] = 'X'
            if row + 1 < grid_rows and grid[row + 1][col] == 'X':
                grid[row][col] = 'X'
            if col - 1 >= 0 and grid[row][col - 1] == 'X':
                grid[row][col] = 'X'
            if col + 1 < grid_cols and grid[row][col + 1] == 'X':
                grid[row][col] = 'X'

for row in range(grid_rows - 1, -1, -1):
    for col in range(grid_cols - 1, -1, -1):
        pos = (row, col)
        if grid[row][col] == '0':
            if row - 1 >= 0 and grid[row - 1][col] == 'X':
                grid[row][col] = 'X'
            if row + 1 < grid_rows and grid[row + 1][col] == 'X':
                grid[row][col] = 'X'
            if col - 1 >= 0 and grid[row][col - 1] == 'X':
                grid[row][col] = 'X'
            if col + 1 < grid_cols and grid[row][col + 1] == 'X':
                grid[row][col] = 'X'

for row in range(grid_rows):
    for col in range(grid_cols):
        if grid[row][col] == 'X':
            print('.', end='')
        else:
            print(grid[row][col], end='')
    print('')

answer = 0
for row in range(grid_rows):
    for col in range(grid_cols):
        if grid[row][col] == '0':
            answer += 1
print(answer)