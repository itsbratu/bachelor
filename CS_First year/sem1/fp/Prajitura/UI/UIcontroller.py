"""
Python file where we store our class for the UI in the app
"""

from Domain.prajitura import Prajitura
from Domain.exceptii import InvalidCommand
from Repository.Repository import Repository
from Service.Service import Service
from Domain.exceptii import InvalidID

class UI:

    def __init__(self , repo:Repository , service:Service):
        self.Repository = repo
        self.Service = service

    def printmenu(self):
        """
        Functie care printeaza pe ecranul utilizatorului meniul de optiuni
        """
        print("----------------------MENU----------------------")
        print()
        print("0.Afisare prajituri din lista!")
        print("1.Adaugare prajitura in lista!")
        print("2.Stergere prajitura din lista!")
        print("3.Raport ordonare dupa pret descending")
        print("4.EXIT")
        print()

    def getchoice(self):
        """
        Functie care preia comanda utilizatorului si indeplineste anumite functionalitati pe baza acesteia
        """

        self.printmenu()
        choice = input("Introduceti comanda va rugam:")
        print()

        try:
            choice = int(choice)
        except ValueError:
            raise InvalidCommand("Comanda introdusa invalida!")

        if choice not in range(0,5):
            raise InvalidCommand("Comanda pe care o doriti nu exista!")

        if choice == 0:
            self.printprajituri()
            return True
        if choice == 1:
            self.addprajitura()
            return True
        if choice == 2:
            self.deleteprajitura()
            return True
        if choice == 3:
            self.ordonarepret()
            return True
        if choice == 4:
            return False

    def printprajituri(self):
        """
        Functie care afiseaza pe ecranul utilizatorului list de prajituri din memoria curenta
        """
        list_prajituri = self.Service.getall()
        print("Lista de prajituri este:")
        print()
        for p in list_prajituri:
            print(str(p.getid()) + " " + p.getnume() + " " + str(p.getpret()) + " " + str(p.getcantitate()))

    def addprajitura(self):
        """
        Functie care permite utilizatorului introducerea de la tastatura a atributiilor unei prajituri si adaugarea acesteia in Repository
        """
        nume = input("Introduceti nume prajitura:")
        pret = input("Introduceti pret prajitura:")
        cantitate = input("Introduceti cantitate prajitura:")

        prajitura = Prajitura(nume , pret , cantitate)
        self.Service.addprajitura(prajitura)

    def deleteprajitura(self):
        """
        Functie care permite utilizatorului introducerea de la tastatura unui id al unei prajituri pentru a da delete din lista
        """
        id = input("Introduceti ID prajitura:")
        try:
            id = int(id)
        except ValueError:
            raise InvalidID("ID introdus invalid!")

        self.Service.deleteprajitura(id)

    def ordonarepret(self):
        """
        Functie care perminte utilizatorului ordonarea listei de prajituri si afisarea acesteia
        """
        print_list = self.Service.ordonarepret()
        print("Lista prajiturilor ordonate dupa pret este:")
        print()

        for p in print_list:
            print(str(p.getid()) + " " + p.getnume() + " " + str(p.getpret()) + " " + str(p.getcantitate()))
