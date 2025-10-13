import copy

rang_matr=int(input("input rang of matrix: "))
numer_of_unKnown_perem=int(input("input the number of unknown variables: "))
#plus svobodnye chleny
cols = numer_of_unKnown_perem + 1 
matrix = []
for i in range(rang_matr):
    row = list(map(int, input(f"input {cols} numbers separated by space for row {i+1}: ").split()))
    if len(row) != cols: 
        print(f"Error: you must enter exactly {cols} numbers!")  
        exit(1)
    matrix.append(row)


max_len = max(len(str(x)) for row in matrix for x in row)

def my_input(rang, comment):
    a=0
    while True:        
        flag=0
        try:
            str_a=input(comment)
            a=int(str_a)            
        except:
            print("validation error")
            flag=1
        
        if flag==0:
            if a>=1 and a<=rang:
                break           
            else:
                print("error of array size")
    return a
        
     


def print_augmented_matrix(matrix, num_vars):
    # ���������� ������ �� ������ �������� �����
    max_len = max(len(str(x)) for row in matrix for x in row)

    for row in matrix:
        # ������������ ��� ����������
        for elem in row[:num_vars]:
            print(f"{elem:>{max_len}}", end="\t")

        # ������������ �����
        print("|", end="\t")

        # ��������� ����
        print(f"{row[num_vars]:>{max_len}}")

# стек состояний для отката
history = []

def save_state():
    # Сохраняет копию текущей матрицы в историю
    history.append(copy.deepcopy(matrix))

def undo():
    # Откатывает матрицу на один шаг назад
    global matrix
    if history:
        matrix = history.pop()
        print("✅ Matrix restored to previous state.")
    else:
        print("⚠️ No previous state to undo.")

print_augmented_matrix(matrix, numer_of_unKnown_perem)
flag=1
while flag:
    print ("M E N U")
    print ("1. change rows")
    print ("2. substract Koeff * row number VEDYSH_ROW from row number ANOTHER_ROW  ")
    print ("3. multiply row on number")
    print ("4. devide row on number")
    print ("5. undo last action")
    print ("6. exit")
    menu_item=int(input("enter choise: "))
    if menu_item==1:
        save_state()
        #a = int(input("input the numbers of first row: "))
        a=my_input(rang_matr, "input the numbers of first row: ")
        #b = int(input("input the numbers of another row: "))
        b = my_input(rang_matr, "input the numbers of another row: ")       
        matrix[a-1],matrix[b-1]=matrix[b-1],matrix[a-1]       
        print_augmented_matrix(matrix, numer_of_unKnown_perem)

    if menu_item==2:
        save_state()       
        #numer_of_vedush_str=int(input("input the number of vedushei stroki: "))-1
        #number_of_another_str=int(input("input the number of another stroki: "))-1
        numer_of_vedush_str=my_input(rang_matr, "input the number of vedushei stroki: ")-1
        number_of_another_str=my_input(rang_matr, "input the number of another stroki: ")-1
        koef=int(input("input koeff: "))        
        vedush_str=matrix[numer_of_vedush_str]
        another_str=matrix[number_of_another_str]

        for i in range(cols):            
            another_str[i]-=koef*vedush_str[i]            

        print_augmented_matrix(matrix, numer_of_unKnown_perem)

    if menu_item==3:
        save_state()
        #number_of_string=int(input("input the number of string: "))-1
        number_of_string=my_input(rang_matr, "input the number of string: ")-1
        k=int(input("input koeff: "))
        new_string=matrix[number_of_string]

        for i in range(cols):
            new_string[i]*=k

        print_augmented_matrix(matrix, numer_of_unKnown_perem)

    if menu_item==4:
        save_state()
        #number_of_string=int(input("input the number of string: "))-1
        number_of_string=my_input(rang_matr, "input the number of string: ")-1
        k=int(input("input koeff: "))
        new_string=matrix[number_of_string]

        for i in range(cols):
            new_string[i]/=k 

        print_augmented_matrix(matrix, numer_of_unKnown_perem)

    elif menu_item == 5:
        undo()
        print_augmented_matrix(matrix, numer_of_unKnown_perem)

    elif menu_item==6:
        flag=0
    else:
        print("There is no such menu item")

print("end")