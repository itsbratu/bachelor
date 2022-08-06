"""
Python file where we store our class "Console"(UI) for the app
"""

from Repository.Repository import PicturaRepository
from Service.Service import PicturaService
from Exceptions.Exceptii import InvalidChoice

class Console:

    def __init__(self , repo : PicturaRepository , service : PicturaService):
        self.repo = repo
        self.service = service

    def printmenu(self):
        """
        Functie care printeaza pe ecranul utilizatorului lista de optiuni ale aplicatiei
        """
        print()
        print("-------MENU-------")
        print()
        print("1.Afisare tuturor operelor de arta care contin un anumit sir de caractere!")
        print("2.Afisare autori care au opere expuse intr-o camera data!")
        print("3.Afisare list curenta de opere!")
        print()
        print("x.EXIT")

    def getchoice(self):
        """
        Functie care permite utilizatorului alegerea unei optiuni din cele din meniul de mai sus
        :return: True - in cazul in care se continua exectuia programului(utilizatorul nu a ales optiunea EXIT) , False - utilizatorul alege optiunea EXIT
        """
        self.printmenu()
        print()
        choice = input("Introduceti optiunea:")

        if choice == 'x':
            return False

        try:
            choice = int(choice)
            if choice not in range(1 , 4):
                raise InvalidChoice("Optiunea aleasa nu exista in meniu! Va rugam reincercati!")

        except ValueError:
            raise InvalidChoice("Optiunea aleasa nu este valida! Va rugam reincercati!")

        if choice == 1:
            self.printpicturi()
            return True

        if choice == 2:
            self.printpictori()
            return True

        if choice == 3:
            self.printobjects()
            return True

    def printpicturi(self):
        """
        Functie care afiseaza pe ecranul utilizatorului toate operele de arta care contin un anumit sir de caractere ordonate descrescator dupa autor
        """
        string = input("Va rugam introduceti un string:")
        print()
        list_print = self.service.picturistring(string)

        print("Lista de picturi care contine string-ul '{}' ordonate descrescator dupa autor este:".format(string))
        print()

        for p in list_print:
            print(str(p.getid()) + " " + p.getdenumire() + " " + p.getautor() + " " + str(p.getnr()))

    def printpictori(self):
        """
        Functie care afiseaza toti autorii care au picturi intr-o camera introdusa de catre utilizator
        """
        print()
        camera = input("Introduceti camera dorita:")
        print()

        list_print = self.service.autoricamera(camera)

        print("Camera {}:".format(camera))
        for p in list_print:
            print(p)

    def printobjects(self):
        """
        Functie care afiseaza toate obiecte din memorie, preluate din fisier
        :return:
        """
        list_print = self.service.getall()
        print("Picturile sunt:")
        for p in list_print:
            print(str(p.getid()) + " " + p.getdenumire() + " " + p.getautor() + " " + str(p.getnr()))
