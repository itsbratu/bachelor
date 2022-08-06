from Repository.repo import Repository
from Service.service import Service
from UIcontroller.UI import UI

repo = Repository("test.txt")
service =Service(repo)
ui = UI(repo , service)

import unittest

unittest.main(module="Unitttest.TestElev" , exit=False)

while True:
    try:
        choice = ui.getchoice()
        if not choice:
            break
    except Exception as e:
        print(str(e) + "\n")

print("Multumim ca ati utilizat aplicatia!")