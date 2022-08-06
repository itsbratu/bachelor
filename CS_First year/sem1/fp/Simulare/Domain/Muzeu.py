"""
Python file where we store our class "Pictura" for our application
"""

class Pictura:

    def __init__(self , id , denumire , autor , nr):
        self.id = id
        self.denumire = denumire
        self.autor = autor
        self.nr = nr

    def getid(self):
        """
        Functie care returneaza id-ul unui obiect "Pictura"
        :return: self.id - integer number > 0
        """
        return self.id

    def getdenumire(self):
        """
        Functie care retunreaza denumirea unui obiect "Pictura"
        :return: self.denumire - string
        """
        return self.denumire

    def getautor(self):
        """
        Functie care returneaza autorul unui obiect "Pictura"
        :return: self.autor
        """
        return self.autor

    def getnr(self):
        """
        Functie care returneaza nr. camera unui obiect de tip "Pictura"
        :return: self.nr
        """
        return self.nr