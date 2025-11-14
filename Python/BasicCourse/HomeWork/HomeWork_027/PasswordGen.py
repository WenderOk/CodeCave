import random, string
adjectivesRU = ['смешных', 'полосатых', 'маленьких', 'хрустальных', 'черных', 'радостных', 'медленных', 'фиолетовых']
nounsRU = ['слонов', 'бегемотов', 'крокодилов', 'обезьян', 'драконов', 'котиков', 'единорогов', 'пегасов', 'лягушек']
verbsRU = ['бегут', 'летят', 'прыгают', 'читают', 'хрюкают']

adjectivesEN = ['funny', 'cozy', 'little', 'stony', 'big', 'black', 'slow', 'purple', 'pretty', 'poor', 'adorable']
nounsEN = ['elephants', 'hippos', 'crocodiles', 'monkeys', 'dragons', 'kittens', 'unicorns', 'simga', 'frogs']
verbsEN = ['running', 'flying', 'jumping', 'reading', 'biting', 'walking', 'dancing', 'flexing', 'driving']

language = 'ru'
orderType = 'случайный'
order = [0, 1, 2, 3, 4]
print('''
=======================<>-/\-<>==========================
       Вас приветсвует генератор паролей версии 1.1
=======================<>-\/-<>==========================
    Вы можете указать слудующие параметры пароля:
        - Язык слов пароля (английский/русский)
        - Порядок элементов пароля (случайный/ручной)
        
        Примичание:
            При ручном порядке элементов пароля нужно ввести последовательность цифр где:
            0 - числовой элемент
            1 - прилагательное 
            2 - существительное
            3 - глагол
            4 - специальный символ
      ''')
language = input("Укажите язык пароля (ru или en): ")
order = [int(n) for n in input("Введите порядок элементов: ").split()]
N = int(input('Введите количество паролей, которое необходимо сгенерировать: '))

def genPswd():
    for i in range(N):
        if language == 'ru':
            verb = random.choice(verbsRU)
            noun = random.choice(nounsRU)
            adjective = random.choice(adjectivesRU)
        elif language == 'en':
            verb = random.choice(verbsEN)
            noun = random.choice(nounsEN)
            adjective = random.choice(adjectivesEN)
        number = str(random.randrange(2, 100))
        symbol = random.choice(string.punctuation)
        
        pswdElem = [number, adjective, noun, verb, symbol]
        password = ''
        
        if order == 'случайный':
            for _ in range(5): password += random.choice([number, adjective, noun, verb, symbol])
        else: 
            for j in range(5): password += pswdElem[order[j]]
        print(f'{i+1} пароль: {password}')
genPswd()
input("Нажмите ENTER чтобы продолжить:")