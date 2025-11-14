fileName = input()
'''
if ".html" in fileName or ".htm" in fileName or ".php" in fileName: print("Это веб-страница!")
'''
if fileName[-4:] == ".htm" or fileName[-4:] == ".php" or fileName[-4:] == "html": print("Это веб-страница!")
else: print("Что-то другое")