def create():
    pass
def delete():
    pass
def search():
    pass
def close():
    pass
def show():
    pass
def interface():
    while True:
        print('''Дорогой пользователь, добро пожаловать в Manager Of Projects
         Что Вы хотите сделать:
         1 - Создать заметку
         2 - Удалить заметку
         3 - Найти заметку
         4 - Закрыть заметку
         5 - Показать заметку
         Для выбора команды напишите номер команды.''')
        answer = input()
        match answer:
            case "1":
               create() 
            case "2":
                delete()
            case "3":
                search()
            case "4":
                close()
            case "5":
                show()
            case _:
                print("Такой команды нету, введите число 1-5")
                continue
            
