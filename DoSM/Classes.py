import tkinter as tk

class Student:
    def __init__(self, name: str, grade: int, student_id: int):
        self.name = name
        self.grade = grade
        self.student_id = student_id
    def upgrade_grade(self):
        if self.grade + 1 <= 12: 
            self.grade += 1
        else:
            return "Max grade"
        
    def print_info(self):
        print(  
            "Name:",self.name, "\n",
            "Grade:",self.grade, "\n",
            "ID:",self.student_id)
        
# print("Student")       
# stud = Student("asd", 3, 1)
# stud.print_info()

class BankAccout:
    def __init__(self, owner: str, account_number: int, balance: int):
        self.owner = owner
        self.account_number = account_number
        self._balance = balance
    def deposit(self, amount):
        self._balance += amount
    def withdraw(self, amount):
        if self._balance - amount >= 0:
            self._balance -= amount
        else:
            return "Not enough money"
    def get_balance(self):
        return self._balance
    
# print("\nBank account")       
# acc = BankAccout("das", 12, 12345)
# print("Your balance:",acc.get_balance())

class GameCharacter:
    def __init__(self, name: str, health: int, attack_power: int):
        self.name = name
        self.health = health
        self.attack_power = attack_power
    def attack(self, target):
        target.health -= self.attack_power
    def is_dead(self):
        True if self.health <= 0 else 1

class Hero(GameCharacter):
    def __init__(self, name, health, attack_power):
        super().__init__(name, health, attack_power)
    def heal(self):
        self.health += 1

class Enemy(GameCharacter):
    def __init__(self, name, health, attack_power):
        super().__init__(name, health, attack_power)
        
# player = Hero("aboba", 100, 20)
# goblin = Enemy("boba", 50, 10)
# dragon = Enemy("Diagon", 9999, 100)

# print("\nPlayer and goblin")

# print("Goblin HP:",goblin.health)
# print("Player attacks goblin!")

# dragon.attack(goblin)

# print("Goblin HP:",goblin.health)
