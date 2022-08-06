"""
Python file where we store our custom classes for the app exceptions raised
"""

class InvalidElev(Exception):
    def __init__(self , msg):
        super().__init__(msg)

class ExistentElev(Exception):
    def __init__(self , msg):
        super().__init__(msg)

class InvalidChoice(Exception):
    def __init__(self , msg):
        super().__init__(msg)

